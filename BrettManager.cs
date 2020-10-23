using UnityEngine;

namespace PlayerModels
{
    public static class BrettManager
    {
        //Skinned mesh renderers
        public static SkinnedMeshRenderer brett_body;
        public static SkinnedMeshRenderer brett_l_hand;
        public static SkinnedMeshRenderer brett_r_hand;
        public static SkinnedMeshRenderer shoulderStraps;
        public static SkinnedMeshRenderer belt_mesh;
        public static SkinnedMeshRenderer shadowCastHair;
        public static SkinnedMeshRenderer shadowCastFace;
        public static Transform Brett_neutral;

        public static void FindParts()
        {
            brett_body = Brett_neutral.Find("geoGrp/brett_body").GetComponent<SkinnedMeshRenderer>();
            brett_l_hand = Brett_neutral.Find("geoGrp/brett_l_hand").GetComponent<SkinnedMeshRenderer>();
            brett_r_hand = Brett_neutral.Find("geoGrp/brett_r_hand").GetComponent<SkinnedMeshRenderer>();
            belt_mesh = Brett_neutral.Find("geoGrp/brett_accessories_belt_mesh").GetComponent<SkinnedMeshRenderer>();
            shoulderStraps = Brett_neutral.Find("geoGrp/brett_accessories_shoulderStraps").GetComponent<SkinnedMeshRenderer>();
            shadowCastFace = Brett_neutral.Find("geoGrp/brett_shadowCast_face").GetComponent<SkinnedMeshRenderer>();
            shadowCastHair = Brett_neutral.Find("geoGrp/brett_shadowCast_hair").GetComponent<SkinnedMeshRenderer>();
        }
    }
}
