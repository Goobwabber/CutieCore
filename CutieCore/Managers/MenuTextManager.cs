using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using Zenject;

namespace CutieCore.Managers
{
	class MenuTextManager : IInitializable
	{
		public void Initialize()
		{
			YeetText();
			SetColors(Plugin.Config.GetColor(), Plugin.Config.GetAltColor());
			SetText(Plugin.Config.Cutie, "Cute");
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void YeetText()
		{
			CustomMenuText.Plugin.defaultLogo.SetActive(false);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetText(string mainText, string bottomText)
		{
			CustomMenuText.Plugin.setText(new[] { mainText, bottomText });
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetColors(Color mainColor, Color bottomColor)
		{
			CustomMenuText.Plugin.MainColor = mainColor;
			CustomMenuText.Plugin.BottomColor = bottomColor;
		}
	}
}
