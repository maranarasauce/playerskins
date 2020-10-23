using MelonLoader;
using static UnityEngine.Object;
using UnityEngine;
using StressLevelZero.Player;
using StressLevelZero.VRMK;
using StressLevelZero.SFX;

namespace PlayerModels
{
    public static class SkinLoading
    {
        static public GameObject currentLoadedSkin;
        static public AssetBundle currentLoadedBundle;

        public static void ResetSkin()
        {
            if (PlayerModels.skinned == true && currentLoadedSkin != null)
            {
                GameObject.Destroy(currentLoadedSkin);
                if (currentLoadedBundle)
                {
                    currentLoadedBundle.Unload(true);
                }
                BrettManager.brett_body.enabled = true;
                BrettManager.brett_l_hand.enabled = true;
                BrettManager.brett_r_hand.enabled = true;
                BrettManager.shoulderStraps.enabled = false;
                BrettManager.belt_mesh.enabled = true;
                BrettManager.shadowCastFace.enabled = true;
                BrettManager.shadowCastHair.enabled = true;

                CharacterAnimationManager originalManager = BrettManager.Brett_neutral.GetComponent<CharacterAnimationManager>();
                SLZ_BodyBlender originalBodyBlender = BrettManager.Brett_neutral.GetComponent<SLZ_BodyBlender>();
                SLZ_Body originalBody = GameObject.Find("[RigManager (Default Brett)]/[SkeletonRig (GameWorld Brett)]/Body").GetComponent<SLZ_Body>();
                Animator originalAnimator = BrettManager.Brett_neutral.GetComponent<Animator>();
                originalManager.animator = originalAnimator;

                originalManager.leftHandTransform = BrettManager.Brett_neutral.transform.Find("SHJntGrp/MAINSHJnt/ROOTSHJnt/Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/l_Arm_ClavicleSHJnt/l_AC_AuxSHJnt/l_Arm_ShoulderSHJnt/l_Arm_Elbow_CurveSHJnt/l_WristSHJnt/l_Hand_1SHJnt/l_Hand_2SHJnt");
                originalManager.leftHandleTransform = originalManager.leftHandTransform.Find("l_GripPoint_AuxSHJnt");

                originalManager.rightHandTransform = BrettManager.Brett_neutral.transform.Find("SHJntGrp/MAINSHJnt/ROOTSHJnt/Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/r_Arm_ClavicleSHJnt/r_AC_AuxSHJnt/r_Arm_ShoulderSHJnt/r_Arm_Elbow_CurveSHJnt/r_WristSHJnt/r_Hand_1SHJnt/r_Hand_2SHJnt");

                originalManager.rightHandleTransform = originalManager.rightHandTransform.Find("r_GripPoint_AuxSHJnt");

                originalManager.leftOpenHandTransform = BrettManager.Brett_neutral.transform.Find("SHJntGrp/MAINSHJnt/ROOTSHJnt/Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/l_Arm_ClavicleSHJnt/l_AC_AuxSHJnt/l_Arm_ShoulderSHJnt/l_Arm_Elbow_CurveSHJnt/l_WristSHJnt/l_Hand_1SHJnt/l_Hand_2SHJnt_open");

                originalManager.leftClosedHandTransform = BrettManager.Brett_neutral.transform.Find("SHJntGrp/MAINSHJnt/ROOTSHJnt/Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/l_Arm_ClavicleSHJnt/l_AC_AuxSHJnt/l_Arm_ShoulderSHJnt/l_Arm_Elbow_CurveSHJnt/l_WristSHJnt/l_Hand_1SHJnt/l_Hand_2SHJnt");

                originalManager.rightOpenHandTransform = BrettManager.Brett_neutral.transform.Find("SHJntGrp/MAINSHJnt/ROOTSHJnt/Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/r_Arm_ClavicleSHJnt/r_AC_AuxSHJnt/r_Arm_ShoulderSHJnt/r_Arm_Elbow_CurveSHJnt/r_WristSHJnt/r_Hand_1SHJnt/r_Hand_2SHJnt_open");

                originalManager.rightClosedHandTransform = BrettManager.Brett_neutral.transform.Find("SHJntGrp/MAINSHJnt/ROOTSHJnt/Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/r_Arm_ClavicleSHJnt/r_AC_AuxSHJnt/r_Arm_ShoulderSHJnt/r_Arm_Elbow_CurveSHJnt/r_WristSHJnt/r_Hand_1SHJnt/r_Hand_2SHJnt");

                originalBody.ArtToBlender = originalBodyBlender;
                originalBody.OnStart();
                MelonCoroutines.Start(MiscFunctions.RefreshManager(PlayerModels.rigmanager, originalManager, originalBody));
                MelonLogger.Log("Skin applied");
            }
            PlayerModels.skinned = false;
        }
        public static void LoadSkin(string path)
        {
            if (currentLoadedBundle != null)
            {
                currentLoadedBundle.Unload(true);
                currentLoadedBundle = null;
            }

            if (currentLoadedSkin != null)
            {
                Destroy(currentLoadedSkin);
            }

            BrettManager.brett_body.enabled = false;
            BrettManager.brett_l_hand.enabled = false;
            BrettManager.brett_r_hand.enabled = false;
            BrettManager.shoulderStraps.enabled = false;
            BrettManager.belt_mesh.enabled = false;
            BrettManager.shadowCastFace.enabled = false;
            BrettManager.shadowCastHair.enabled = false;

            currentLoadedBundle = AssetBundle.LoadFromFile(path);
            if (currentLoadedBundle != null)
            {
                GameObject asset = currentLoadedBundle.LoadAsset("Assets/PlayerSkin.prefab").Cast<GameObject>();

                currentLoadedSkin = Instantiate(asset);

                BoneworksModdingToolkit.SimpleFixes.FixObjectShader(currentLoadedSkin);

                CharacterAnimationManager originalManager = BrettManager.Brett_neutral.GetComponent<CharacterAnimationManager>();
                SLZ_BodyBlender originalBodyBlender = BrettManager.Brett_neutral.GetComponent<SLZ_BodyBlender>();
                SLZ_Body originalBody = GameObject.Find("[RigManager (Default Brett)]/[SkeletonRig (GameWorld Brett)]/Body").GetComponent<SLZ_Body>();
                Animator originalAnimator = BrettManager.Brett_neutral.GetComponent<Animator>();
                Animator newAnimator = currentLoadedSkin.gameObject.GetComponent<Animator>();
                newAnimator.enabled = true;
                newAnimator.runtimeAnimatorController = originalAnimator.runtimeAnimatorController;
                SLZ_BodyBlender newBodyBlender = currentLoadedSkin.AddComponent<SLZ_BodyBlender>();
                originalManager.animator = newAnimator;

                originalManager.leftHandTransform = currentLoadedSkin.transform.Find("SHJntGrp/MAINSHJnt/ROOTSHJnt/Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/l_Arm_ClavicleSHJnt/l_AC_AuxSHJnt/l_Arm_ShoulderSHJnt/l_Arm_Elbow_CurveSHJnt/l_WristSHJnt/l_Hand_1SHJnt/l_Hand_2SHJnt");
                originalManager.leftHandleTransform = originalManager.leftHandTransform.Find("l_GripPoint_AuxSHJnt");

                originalManager.rightHandTransform = currentLoadedSkin.transform.Find("SHJntGrp/MAINSHJnt/ROOTSHJnt/Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/r_Arm_ClavicleSHJnt/r_AC_AuxSHJnt/r_Arm_ShoulderSHJnt/r_Arm_Elbow_CurveSHJnt/r_WristSHJnt/r_Hand_1SHJnt/r_Hand_2SHJnt");

                originalManager.rightHandleTransform = originalManager.rightHandTransform.Find("r_GripPoint_AuxSHJnt");

                originalManager.leftOpenHandTransform = currentLoadedSkin.transform.Find("SHJntGrp/MAINSHJnt/ROOTSHJnt/Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/l_Arm_ClavicleSHJnt/l_AC_AuxSHJnt/l_Arm_ShoulderSHJnt/l_Arm_Elbow_CurveSHJnt/l_WristSHJnt/l_Hand_1SHJnt/l_Hand_2SHJnt_open");

                originalManager.leftClosedHandTransform = currentLoadedSkin.transform.Find("SHJntGrp/MAINSHJnt/ROOTSHJnt/Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/l_Arm_ClavicleSHJnt/l_AC_AuxSHJnt/l_Arm_ShoulderSHJnt/l_Arm_Elbow_CurveSHJnt/l_WristSHJnt/l_Hand_1SHJnt/l_Hand_2SHJnt");

                originalManager.rightOpenHandTransform = currentLoadedSkin.transform.Find("SHJntGrp/MAINSHJnt/ROOTSHJnt/Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/r_Arm_ClavicleSHJnt/r_AC_AuxSHJnt/r_Arm_ShoulderSHJnt/r_Arm_Elbow_CurveSHJnt/r_WristSHJnt/r_Hand_1SHJnt/r_Hand_2SHJnt_open");

                originalManager.rightClosedHandTransform = currentLoadedSkin.transform.Find("SHJntGrp/MAINSHJnt/ROOTSHJnt/Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/r_Arm_ClavicleSHJnt/r_AC_AuxSHJnt/r_Arm_ShoulderSHJnt/r_Arm_Elbow_CurveSHJnt/r_WristSHJnt/r_Hand_1SHJnt/r_Hand_2SHJnt");

                MiscFunctions.CopyComponent(originalBodyBlender, newBodyBlender);

                newBodyBlender.elbowBlendShape = 1;
                newBodyBlender.shoulderBlendShape = 1;
                newBodyBlender.wristBlendShape = 1;
                newBodyBlender.twistPosWeight = 0.33f;
                newBodyBlender.twistRotWeight = 0.5f;
                newBodyBlender.twistUpperArmWeight = 0.5f;
                newBodyBlender.characterHeight = 1.76f;
                newBodyBlender.charSpecific = SLZ_BodyBlender.CharSpecific.Brett;
                newBodyBlender.FingerBlendCurve = originalBodyBlender.FingerBlendCurve;
                newBodyBlender.offsetsDirty = true;
                newBodyBlender.posOffs = originalBodyBlender.posOffs;
                newBodyBlender.posOff = originalBodyBlender.posOff;
                newBodyBlender.rotOffs = originalBodyBlender.rotOffs;
                newBodyBlender.rotOff = originalBodyBlender.rotOff;
                newBodyBlender.mkbody = originalBodyBlender.mkbody;
                newBodyBlender.mkRefs = originalBody;
                newBodyBlender.mkTransformPos = originalBodyBlender.mkTransformPos;
                newBodyBlender.mkTransformRot = originalBodyBlender.mkTransformRot;
                newBodyBlender.bodyMesh01 = currentLoadedSkin.transform.Find("geoGrp/brett_body").GetComponent<SkinnedMeshRenderer>();
                newBodyBlender.lfHandMesh = currentLoadedSkin.transform.Find("geoGrp/brett_l_hand").GetComponent<SkinnedMeshRenderer>();
                newBodyBlender.rtHandMesh = currentLoadedSkin.transform.Find("geoGrp/brett_r_hand").GetComponent<SkinnedMeshRenderer>();
                newBodyBlender.AutoFillBones();
                newBodyBlender.AutoFillMkrefs();

                HeadSFX newHSFX = currentLoadedSkin.GetComponent<HeadSFX>();
                if (newHSFX != null)
                {
                    HeadSFX originalHSFX = PlayerModels.rigmanager.physicsRig.m_head.GetComponent<HeadSFX>();

                    if (newHSFX.jumpEffort.Count != 0)
                        originalHSFX.jumpEffort = newHSFX.jumpEffort;
                    if (newHSFX.smallDamage.Count != 0)
                        originalHSFX.smallDamage = newHSFX.smallDamage;
                    if (newHSFX.bigDamage.Count != 0)
                        originalHSFX.bigDamage = newHSFX.bigDamage;
                    if (newHSFX.dying.Count != 0)
                        originalHSFX.dying = newHSFX.dying;
                    if (newHSFX.dead.Count != 0)
                        originalHSFX.dead = newHSFX.dead;
                    if (newHSFX.recovery.Count != 0)
                        originalHSFX.recovery = newHSFX.recovery;
                    if (newHSFX.headbuttClips.Count != 0)
                        originalHSFX.headbuttClips = newHSFX.headbuttClips;
                    if (newHSFX.windBuffetClip != null)
                        originalHSFX.windBuffetClip = newHSFX.windBuffetClip;
                }
                PlayerModels.skinned = true;

                originalBody.ArtToBlender = newBodyBlender;
                originalBody.OnStart();
                MelonCoroutines.Start(MiscFunctions.RefreshManager(PlayerModels.rigmanager, originalManager, originalBody));
                MelonLogger.Log("Skin applied");
            }
            else
            {
                MelonLogger.LogError("No skin found");
            }
        }
    }
}
