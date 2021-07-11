using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

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

	[HarmonyPatch(typeof(RankModel), nameof(RankModel.GetRankName), MethodType.Normal)]
	internal class RankNamePatch
	{
		static bool Prefix(RankModel.Rank rank, ref string __result)
		{
			if (rank == RankModel.Rank.SSS || rank == RankModel.Rank.SS)
			{
				__result = "Cute";
				return false;
			}
			return true;
		}
	}

	[HarmonyPatch(typeof(ImmediateRankUIPanel), nameof(ImmediateRankUIPanel.RefreshUI), MethodType.Normal)]
	internal class RankColorPatch
	{
		static void Postfix(RelativeScoreAndImmediateRankCounter ____relativeScoreAndImmediateRankCounter, TextMeshProUGUI ____rankText)
		{
			____rankText.color = ____rankText.text == "Cute" ? Plugin.Config.GetColor() : Plugin.Config.GetAltColor();
		}
	}

	[HarmonyPatch(typeof(GameplayCoreInstaller), nameof(GameplayCoreInstaller.InstallBindings), MethodType.Normal)]
	internal class ColorSchemePatch
	{
		private static readonly MethodInfo _colorSchemeMethod = typeof(FromBinderGeneric<ColorScheme>).GetMethod(nameof(FromBinderGeneric<ColorScheme>.FromInstance));
		//private static readonly FieldInfo _sceneSetupDataField = typeof(GameplayCoreInstaller).GetField("_sceneSetupData", BindingFlags.Instance | BindingFlags.NonPublic);

		private static readonly MethodInfo _colorSchemeAttacher = SymbolExtensions.GetMethodInfo(() => ColorSchemeAttacher(null, null));

		static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
		{
			var codes = instructions.ToList();
			for (int i = 0; i < codes.Count; i++)
			{
				if (codes[i].opcode == OpCodes.Callvirt && codes[i].Calls(_colorSchemeMethod))
				{
					CodeInstruction newCode = new CodeInstruction(OpCodes.Callvirt, _colorSchemeAttacher);
					codes[i] = newCode;
				}
			}

			return codes.AsEnumerable();
		}

		private static ScopeConcreteIdArgConditionCopyNonLazyBinder ColorSchemeAttacher(FromBinderGeneric<ColorScheme> contract, ColorScheme instance)
		{
			Color mainColor = Plugin.Config.GetColor();
			Color altColor = Plugin.Config.GetAltColor();
			ColorScheme newColorScheme = new ColorScheme(instance, mainColor, altColor, mainColor, altColor, false, mainColor, altColor, mainColor);
			return contract.FromInstance(newColorScheme);
		}
	}
}
