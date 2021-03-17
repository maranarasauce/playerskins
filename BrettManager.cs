using StressLevelZero.SFX;
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
        public static HeadSFX storedSFX;
        public static HeadSFX activeSFX;

        public static void FindParts()
        {
            brett_body = Brett_neutral.Find("geoGrp/brett_body").GetComponent<SkinnedMeshRenderer>();
            brett_l_hand = Brett_neutral.Find("geoGrp/brett_l_hand").GetComponent<SkinnedMeshRenderer>();
            brett_r_hand = Brett_neutral.Find("geoGrp/brett_r_hand").GetComponent<SkinnedMeshRenderer>();
            belt_mesh = Brett_neutral.Find("geoGrp/brett_accessories_belt_mesh").GetComponent<SkinnedMeshRenderer>();
            shoulderStraps = Brett_neutral.Find("geoGrp/brett_accessories_shoulderStraps").GetComponent<SkinnedMeshRenderer>();
            shadowCastFace = Brett_neutral.Find("geoGrp/brett_shadowCast_face").GetComponent<SkinnedMeshRenderer>();
            shadowCastHair = Brett_neutral.Find("geoGrp/brett_shadowCast_hair").GetComponent<SkinnedMeshRenderer>();
            activeSFX = PlayerModels.rigmanager.physicsRig.m_head.GetComponent<HeadSFX>();
            storedSFX = PlayerModels.rigmanager.physicsRig.m_pelvis.gameObject.AddComponent<HeadSFX>();
            MatchSFX(activeSFX, storedSFX);
        }

        public static void MatchSFX(HeadSFX template, HeadSFX copyTo)
        {
            if (template.jumpEffort.Count != 0)
                copyTo.jumpEffort = template.jumpEffort;
            if (template.smallDamage.Count != 0)
                copyTo.smallDamage = template.smallDamage;
            if (template.bigDamage.Count != 0)
                copyTo.bigDamage = template.bigDamage;
            if (template.dying.Count != 0)
                copyTo.dying = template.dying;
            if (template.dead.Count != 0)
                copyTo.dead = template.dead;
            if (template.recovery.Count != 0)
                copyTo.recovery = template.recovery;
            if (template.headbuttClips.Count != 0)
                copyTo.headbuttClips = template.headbuttClips;
            if (template.windBuffetClip != null)
                copyTo.windBuffetClip = template.windBuffetClip;
        }
    }
}
