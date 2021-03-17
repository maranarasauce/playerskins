[Harmony.HarmonyPatch(typeof(StressLevelZero.VRMK.SLZ_BodyBlender), "Brett")] 
static class BrettPatch
{
    //This patches out all of brandon's hard work on blend shapes for the wrists and fingers. //TODO, add support for bringing all that back
    static bool Prefix()
    {
        return false;
    }
}