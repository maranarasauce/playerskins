[Harmony.HarmonyPatch(typeof(StressLevelZero.VRMK.SLZ_BodyBlender), "Brett")] 
static class CancelPatch
{
    static bool Prefix()
    {
        return false;
    }
}