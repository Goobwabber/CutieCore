using HarmonyLib;
using TMPro;
using UnityEngine.UI;

namespace CutieCore.HarmonyPatches
{
	[HarmonyPatch(typeof(StandardLevelDetailView), nameof(StandardLevelDetailView.RefreshContent), MethodType.Normal)]
	internal class ActionButtonTextRefreshPatch
	{
		static void Prefix(TextMeshProUGUI ____actionButtonText)
		{
			____actionButtonText.text = $"{Plugin.Config.Cutie} Cute";
		}
	}

	[HarmonyPatch(typeof(StandardLevelDetailView), nameof(StandardLevelDetailView.actionButtonText), MethodType.Setter)]
	internal class ActionButtonTextSetPatch
	{
		static void Prefix(ref string value)
		{
			value = $"{Plugin.Config.Cutie} Cute";
		}
	}
}
