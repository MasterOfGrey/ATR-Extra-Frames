using System;
using System.Text;
using HarmonyLib;
using RimWorld;
using Verse;

namespace ATR_Extra_Frames
{
	[StaticConstructorOnStartup]
	public static class ATR_EF_HarmonyPatch
	{
		// Define the harmony patch and what it's called.
		static ATR_EF_HarmonyPatch()
		{
			// Note: needs to be in Postfix slot of the harmony.Patch method.
			Harmony harmony = new Harmony("ExtraFrames.CaravanCap");
			harmony.Patch(AccessTools.Method(typeof(MassUtility), nameof(MassUtility.Capacity), null, null), null, new HarmonyMethod(typeof(ATR_EF_HarmonyPatch), "FrameCarryWeight", null), null, null);

			Log.Message("Frames Reforged patch engaged!");
		}

		// Method to append value of EF_CaravanCapacity applied by the HediffDef to MassUtility.Capacity
		public static void FrameCarryWeight(Pawn p, StringBuilder explanation, ref float __result)
        {
            // 300 tick recache used so that if the status of the pawn's framework changes it takes effect somewhat reasonably, and because someone told me >100 was ok for performance. 
			__result += p.GetStatValue(ATR_Extra_Frames_StatDefOf.EF_CaravanCapacity, true, 300);
        }
     }
}
