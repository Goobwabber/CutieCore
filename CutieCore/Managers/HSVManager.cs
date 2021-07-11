using HitScoreVisualizer.Services;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Zenject;

namespace CutieCore.Managers
{
	class HSVManager : IInitializable
	{
		protected ConfigProvider _configProvider = null!;

		[Inject]
		internal void Inject(ConfigProvider configProvider)
		{
			_configProvider = configProvider;
		}

		public void Initialize()
		{
			HitScoreVisualizer.Settings.Configuration? hsvConfig = _configProvider.GetCurrentConfig();
			if (hsvConfig != null && hsvConfig.Judgments != null)
			{
				for (int i = 0; i < hsvConfig.Judgments.Count; i++)
				{
					if (hsvConfig.Judgments[i].Threshold == 115)
						hsvConfig.Judgments.RemoveAt(i);
				}

				Color color = Plugin.Config.GetColor();
				ConstructorInfo judgementCtor = typeof(HitScoreVisualizer.Settings.Judgment).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance)[0];
				object newJudgement = judgementCtor.Invoke(new object[] { 115, $"<size=150%>{Plugin.Config.Cutie} Cute</size>", new List<float> { color.r, color.g, color.b, color.a }, false });
				hsvConfig.Judgments.Insert(0, (HitScoreVisualizer.Settings.Judgment)newJudgement);
			}
		}
	}
}
