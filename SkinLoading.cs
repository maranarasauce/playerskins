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

        public static void ClearPlayerModel()
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
                BrettManager.MatchSFX(BrettManager.storedSFX, BrettManager.activeSFX);
                originalBody.OnStart();
                MelonCoroutines.Start(MiscFunctions.RefreshManager(PlayerModels.rigmanager, originalManager, originalBody));
            }
            PlayerModels.skinned = false;
            PlayerModels.currentskinPath = null;
            MelonPrefs.SetString("Player Models", "Skin", "");
            UIGeneration.DisableCanvas();
        }
        public static void ApplyPlayerModel(string path)
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

            PlayerModels.currentskinPath = path;

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
                int i = 92;
                try
                {
                    UIGeneration.CheckText(); i++; i++;

                    GameObject asset = currentLoadedBundle.LoadAsset("Assets/PlayerModels/PlayerModel.prefab").Cast<GameObject>(); i++; i++;

                    currentLoadedSkin = Instantiate(asset); i++; i++;
                    BoneworksModdingToolkit.Shaders.ReplaceDummyShaders(currentLoadedSkin);

                    CharacterAnimationManager originalManager = BrettManager.Brett_neutral.GetComponent<CharacterAnimationManager>(); i++;
                    SLZ_BodyBlender originalBodyBlender = BrettManager.Brett_neutral.GetComponent<SLZ_BodyBlender>(); i++;
                    SLZ_Body originalBody = GameObject.Find("[RigManager (Default Brett)]/[SkeletonRig (GameWorld Brett)]/Body").GetComponent<SLZ_Body>(); i++;
                    Animator originalAnimator = BrettManager.Brett_neutral.GetComponent<Animator>(); i++;
                    Animator newAnimator = currentLoadedSkin.gameObject.GetComponent<Animator>(); i++;
                    newAnimator.enabled = true; i++;
                    newAnimator.runtimeAnimatorController = originalAnimator.runtimeAnimatorController; i++;
                    SLZ_BodyBlender newBodyBlender = currentLoadedSkin.AddComponent<SLZ_BodyBlender>(); i++;
                    originalManager.animator = newAnimator; i++; i++;

                    originalManager.leftHandTransform = currentLoadedSkin.transform.Find("SHJntGrp/MAINSHJnt/ROOTSHJnt/Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/l_Arm_ClavicleSHJnt/l_AC_AuxSHJnt/l_Arm_ShoulderSHJnt/l_Arm_Elbow_CurveSHJnt/l_WristSHJnt/l_Hand_1SHJnt/l_Hand_2SHJnt"); i++;
                    originalManager.leftHandleTransform = originalManager.leftHandTransform.Find("l_GripPoint_AuxSHJnt"); i++; i++;

                    originalManager.rightHandTransform = currentLoadedSkin.transform.Find("SHJntGrp/MAINSHJnt/ROOTSHJnt/Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/r_Arm_ClavicleSHJnt/r_AC_AuxSHJnt/r_Arm_ShoulderSHJnt/r_Arm_Elbow_CurveSHJnt/r_WristSHJnt/r_Hand_1SHJnt/r_Hand_2SHJnt"); i++; i++;

                    originalManager.rightHandleTransform = originalManager.rightHandTransform.Find("r_GripPoint_AuxSHJnt"); i++; i++;

                    originalManager.leftOpenHandTransform = currentLoadedSkin.transform.Find("SHJntGrp/MAINSHJnt/ROOTSHJnt/Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/l_Arm_ClavicleSHJnt/l_AC_AuxSHJnt/l_Arm_ShoulderSHJnt/l_Arm_Elbow_CurveSHJnt/l_WristSHJnt/l_Hand_1SHJnt/l_Hand_2SHJnt_open"); i++; i++;

                    originalManager.leftClosedHandTransform = currentLoadedSkin.transform.Find("SHJntGrp/MAINSHJnt/ROOTSHJnt/Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/l_Arm_ClavicleSHJnt/l_AC_AuxSHJnt/l_Arm_ShoulderSHJnt/l_Arm_Elbow_CurveSHJnt/l_WristSHJnt/l_Hand_1SHJnt/l_Hand_2SHJnt"); i++; i++;

                    originalManager.rightOpenHandTransform = currentLoadedSkin.transform.Find("SHJntGrp/MAINSHJnt/ROOTSHJnt/Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/r_Arm_ClavicleSHJnt/r_AC_AuxSHJnt/r_Arm_ShoulderSHJnt/r_Arm_Elbow_CurveSHJnt/r_WristSHJnt/r_Hand_1SHJnt/r_Hand_2SHJnt_open"); i++; i++;

                    originalManager.rightClosedHandTransform = currentLoadedSkin.transform.Find("SHJntGrp/MAINSHJnt/ROOTSHJnt/Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/r_Arm_ClavicleSHJnt/r_AC_AuxSHJnt/r_Arm_ShoulderSHJnt/r_Arm_Elbow_CurveSHJnt/r_WristSHJnt/r_Hand_1SHJnt/r_Hand_2SHJnt"); i++; i++;

                    MiscFunctions.CopyComponent(originalBodyBlender, newBodyBlender); i++; i++;
                    newBodyBlender.elbowBlendShape = 1; i++;
                    newBodyBlender.shoulderBlendShape = 1; i++;
                    newBodyBlender.wristBlendShape = 1; i++;
                    newBodyBlender.twistPosWeight = 0.33f; i++;
                    newBodyBlender.twistRotWeight = 0.5f; i++;
                    newBodyBlender.twistUpperArmWeight = 0.5f; i++;
                    newBodyBlender.characterHeight = 1.76f; i++;
                    newBodyBlender.charSpecific = SLZ_BodyBlender.CharSpecific.Brett; i++;
                    newBodyBlender.FingerBlendCurve = originalBodyBlender.FingerBlendCurve; i++;
                    newBodyBlender.offsetsDirty = true; i++;
                    newBodyBlender.posOffs = originalBodyBlender.posOffs; i++;
                    newBodyBlender.posOff = originalBodyBlender.posOff; i++;
                    newBodyBlender.rotOffs = originalBodyBlender.rotOffs; i++;
                    newBodyBlender.rotOff = originalBodyBlender.rotOff; i++;
                    newBodyBlender.mkbody = originalBodyBlender.mkbody; i++;
                    newBodyBlender.mkRefs = originalBody; i++;
                    newBodyBlender.mkTransformPos = originalBodyBlender.mkTransformPos; i++;
                    newBodyBlender.mkTransformRot = originalBodyBlender.mkTransformRot; i++;
                    newBodyBlender.bodyMesh01 = currentLoadedSkin.transform.Find("geoGrp/brett_body").GetComponent<SkinnedMeshRenderer>(); i++;
                    newBodyBlender.lfHandMesh = currentLoadedSkin.transform.Find("geoGrp/brett_l_hand").GetComponent<SkinnedMeshRenderer>(); i++;
                    newBodyBlender.rtHandMesh = currentLoadedSkin.transform.Find("geoGrp/brett_r_hand").GetComponent<SkinnedMeshRenderer>(); i++;
                    newBodyBlender.AutoFillBones(); i++;

                    BrettManager.MatchSFX(BrettManager.storedSFX, BrettManager.activeSFX); i++;
                    HeadSFX newHSFX = currentLoadedSkin.GetComponent<HeadSFX>(); i++; i++; i++; i++; i++; i++;
                    if (newHSFX != null)
                    {
                        BrettManager.MatchSFX(newHSFX, BrettManager.activeSFX);
                    }

                    PlayerModels.skinned = true; i++; 
                    MelonPrefs.SetString("Player Models", "Skin", PlayerModels.currentskinPath); i++;
                    originalBody.ArtToBlender = newBodyBlender; i++;
                    originalBody.OnStart(); i++;
                    MelonCoroutines.Start(MiscFunctions.RefreshManager(PlayerModels.rigmanager, originalManager, originalBody));
                } catch
                {
                    MelonLogger.LogError($"Error caught at: {i}");
                }
            }
            else
            {
                MelonLogger.LogError("No skin found");
            }
        }
    }
}
