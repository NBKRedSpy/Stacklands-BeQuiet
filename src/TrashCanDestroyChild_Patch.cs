using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using HarmonyLib;
using UnityEngine;

namespace Stacklands_BeQuiet
{

    [HarmonyPatch(typeof(TrashCan), nameof(TrashCan.DestroyChild))]
    public static class TrashCanDestroyChild_Patch
    {
		public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
		{


			if (Plugin.MuteDustBinCardDestroy.Value == false)
			{
				return instructions;
			}

			//change the Play Sound argument to false.

			//Target IL
			//// childCard.DestroyCard(spawnSmoke: false, playSound: false);  
			//IL_0035: nop
			//IL_0036: ldloc.2
			//IL_0037: ldc.i4.0
			//IL_0038: ldc.i4.1   <---------- Here
			//IL_0039: callvirt instance void GameCard::DestroyCard(bool, bool)

			//Goal:
			//IL_0038: ldc.i4.0

			MethodInfo destroyCardMethod = AccessTools.Method(typeof(GameCard), nameof(GameCard.DestroyCard), 
				new Type[] {typeof(bool), typeof(bool)});

			//Used for debugging only
			var instructionList = new List<CodeInstruction>(instructions);


			//Plugin.Log.Log("------ Original Code");

			//foreach (var instruction in instructions) {
			//	Plugin.Log.Log(instruction.ToString());	
			//}


			List<CodeInstruction> result = new CodeMatcher(instructionList)
				.MatchForward(true,
					new CodeMatch(OpCodes.Ldc_I4_0),
					new CodeMatch(OpCodes.Ldc_I4_1),
					new CodeMatch(OpCodes.Callvirt, destroyCardMethod)
				)
				.ThrowIfNotMatch("Destroy card call missing")

				//Move back one op to the lst false
				.Advance(-1)
				.SetOpcodeAndAdvance(OpCodes.Ldc_I4_0)
				.Advance(1)
				.InstructionEnumeration()
				.ToList();


			//Plugin.Log.Log("---------- Code results");

			//foreach (var instruction in result)
			//{
			//	Plugin.Log.Log(instruction.ToString());
			//}

			return result;
		}
	}
}
