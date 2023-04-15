using RimWorld;

namespace ATR_Extra_Frames
{
    [DefOf]
    public static class ATR_Extra_Frames_StatDefOf
    {
        static ATR_Extra_Frames_StatDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(ATR_Extra_Frames_StatDefOf));
        }

        public static StatDef EF_CaravanCapacity;
    }
}
