using DiColors.Services;
using System.Collections.Generic;
using Zenject;
using static DiColors.Config;

namespace CutieCore.Managers
{
	class DiColorsManager : IInitializable
	{
		protected MenuColorSwapper _menuColorSwapper = null!;
		protected DiColors.Config.Menu _menuConfig = null!;

		[Inject]
		internal void Inject(MenuColorSwapper menuColorSwapper)
		{
			_menuColorSwapper = menuColorSwapper;
		}

		public void Initialize()
		{
			_menuConfig = new DiColors.Config.Menu();
			foreach(KeyValuePair<string, ColorPair> color in _menuConfig.ColorPairs)
			{
				color.Value.Enabled = true;
				color.Value.Color = color.Key == "Saber" ? Plugin.Config.GetAltColor() : Plugin.Config.GetColor();
			}
			_menuColorSwapper.UpdateColors(_menuConfig);
		}
	}
}
