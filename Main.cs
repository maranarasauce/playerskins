using MelonLoader;
using System;
using System.IO;
using static UnityEngine.Object;
using UnityEngine;
using Unity;
using System.Collections;
using Il2CppSystem.Reflection;
using StressLevelZero.Player;
using StressLevelZero.VRMK;
using StressLevelZero.Interaction;
using StressLevelZero.Rig;

namespace PlayerSkins
{
    public static class BuildInfo
    {
        public const string Name = "Player Skins"; // Name of the Mod.  (MUST BE SET)
        public const string Author = "Maranara"; // Author of the Mod.  (Set as null if none)
        public const string Company = null; // Company that made the Mod.  (Set as null if none)
        public const string Version = "1.0"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
    }

    public class PlayerSkins : MelonMod
    {
        public override void OnApplicationStart()
        {
            //Create skin category
            var menu = EasyMenu.Interfaces.AddNewInterface("Player Skins", Color.red);

            //Create directory if not there already
            Directory.CreateDirectory(Environment.CurrentDirectory + "\\UserData\\PlayerSkins");
            //Search directory for skin files
            var skins = Directory.GetFiles(Environment.CurrentDirectory + "\\UserData\\PlayerSkins");

            //Loop through skin files
            foreach (var skin in skins)
            {
                //Check if it's actually a .body file
                if (skin.Substring(Math.Max(0, skin.Length - 5)) == ".body")
                {
                    //It is a body file, add it to the category list
                    menu.CreateFunctionElement(Path.GetFileName(skin), Color.green, null, null, () =>
                    {
                        LoadSkin(skin);
                    });
                }
            }

            menu.CreateFunctionElement("Default Skin", Color.blue, null, null, () =>
            {
                ResetSkin();
            });
        }
        public override void OnFixedUpdate()
        {

        }
        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                LoadSkin(Environment.CurrentDirectory + "\\UserData\\PlayerSkins\\ford.body");
            }
        }

        public void ResetSkin()
        {
            if (skinned == true && currentLoadedSkin != null)
            {
                GameObject.Destroy(currentLoadedSkin);
                if (currentLoadedBundle)
                {
                    currentLoadedBundle.Unload(true);
                }
                brett_body.enabled = true;
                brett_l_hand.enabled = true;
                brett_r_hand.enabled = true;
            }
            skinned = false;
        }

        public int AddUp(int i){
            i++;
            MelonLogger.Log(i.ToString());
            return i;
        }
        GameObject currentLoadedSkin;
        AssetBundle currentLoadedBundle;
        public void LoadSkin(string path)
        {
            brett_body.enabled = false;
            brett_l_hand.enabled = false;
            brett_r_hand.enabled = false;
            //shoulderStraps.enabled = false;
            //belt_mesh.enabled = false;

            currentLoadedBundle = AssetBundle.LoadFromFile(path);
            if (currentLoadedBundle != null)
            {
                int i = 0;
                try
                {
                    GameObject asset = currentLoadedBundle.LoadAsset("Assets/PlayerSkin.prefab").Cast<GameObject>();
                    
                    currentLoadedSkin = Instantiate(asset);

                    BoneworksModdingToolkit.SimpleFixes.FixObjectShader(currentLoadedSkin);
                    i = AddUp(i);
                    CharacterAnimationManager originalManager = Brett_neutral.GetComponent<CharacterAnimationManager>(); i = AddUp(i);
                    SLZ_BodyBlender originalBodyBlender = Brett_neutral.GetComponent<SLZ_BodyBlender>(); i = AddUp(i);
                    SLZ_Body originalBody = GameObject.Find("[RigManager (Default Brett)]/[SkeletonRig (GameWorld Brett)]/Body").GetComponent<SLZ_Body>(); i = AddUp(i);
                    GameWorldSkeletonRig skeletonRig = GameObject.Find("[RigManager (Default Brett)]/[SkeletonRig (GameWorld Brett)]").GetComponent<GameWorldSkeletonRig>();
                    RealtimeSkeletonRig skelebonesRig = GameObject.Find("[RigManager (Default Brett)]/[SkeletonRig (Realtime SkeleBones)]").GetComponent<RealtimeSkeletonRig>();
                    Animator originalAnimator = Brett_neutral.GetComponent<Animator>(); i = AddUp(i);
                    Animator newAnimator = Brett_neutral.gameObject.GetComponent<Animator>(); i = AddUp(i);
                    newAnimator.enabled = true;
                    newAnimator.runtimeAnimatorController = originalAnimator.runtimeAnimatorController; i = AddUp(i);
                    CharacterAnimationManager newManager = currentLoadedSkin.AddComponent<CharacterAnimationManager>();
                    newManager = originalManager.MemberwiseClone().Cast<CharacterAnimationManager>();
                    SLZ_BodyBlender newBodyBlender = currentLoadedSkin.AddComponent<SLZ_BodyBlender>(); i = AddUp(i);
                    originalBody.ArtToBlender = newBodyBlender; i = AddUp(i);

                    //skelebonesRig.characterAnimationManager = newManager;
                    newManager.animator = currentLoadedSkin.GetComponent<Animator>();
                    newManager.data = originalManager.data; i = AddUp(i);
                    newManager.leftHandTransform = currentLoadedSkin.transform.Find("SHJntGrp/MAINSHJnt/ROOTSHJnt/Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/l_Arm_ClavicleSHJnt/l_AC_AuxSHJnt/l_Arm_ShoulderSHJnt/l_Arm_Elbow_CurveSHJnt/l_WristSHJnt/l_Hand_1SHJnt/l_Hand_2SHJnt"); i = AddUp(i);
                    newManager.leftHandleTransform = newManager.leftHandTransform.Find("l_GripPoint_AuxSHJnt"); i = AddUp(i);

                    newManager.rightHandTransform = currentLoadedSkin.transform.Find("SHJntGrp/MAINSHJnt/ROOTSHJnt/Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/r_Arm_ClavicleSHJnt/r_AC_AuxSHJnt/r_Arm_ShoulderSHJnt/r_Arm_Elbow_CurveSHJnt/r_WristSHJnt/r_Hand_1SHJnt/r_Hand_2SHJnt"); i = AddUp(i);

                    newManager.rightHandleTransform = newManager.rightHandTransform.Find("r_GripPoint_AuxSHJnt"); i = AddUp(i);

                    newManager.leftOpenHandTransform = currentLoadedSkin.transform.Find("SHJntGrp/MAINSHJnt/ROOTSHJnt/Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/l_Arm_ClavicleSHJnt/l_AC_AuxSHJnt/l_Arm_ShoulderSHJnt/l_Arm_Elbow_CurveSHJnt/l_WristSHJnt/l_Hand_1SHJnt/l_Hand_2SHJnt_open"); i = AddUp(i);

                    newManager.leftClosedHandTransform = newManager.leftHandTransform; i = AddUp(i);

                    newManager.rightOpenHandTransform = currentLoadedSkin.transform.Find("SHJntGrp/MAINSHJnt/ROOTSHJnt/Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/r_Arm_ClavicleSHJnt/r_AC_AuxSHJnt/r_Arm_ShoulderSHJnt/r_Arm_Elbow_CurveSHJnt/r_WristSHJnt/r_Hand_1SHJnt/r_Hand_2SHJnt_open");
                    i = AddUp(i);
                    newManager.rightClosedHandTransform = newManager.rightHandTransform;
                    i = AddUp(i);
                    newBodyBlender.elbowBlendShape = 1; i = AddUp(i);
                    newBodyBlender.shoulderBlendShape = 1; i = AddUp(i);
                    newBodyBlender.wristBlendShape = 1; i = AddUp(i);
                    newBodyBlender.bodyMesh01 = currentLoadedSkin.transform.Find("geoGrp/brett_body").GetComponent<SkinnedMeshRenderer>(); i = AddUp(i);
                    newBodyBlender.lfHandMesh = currentLoadedSkin.transform.Find("geoGrp/brett_l_hand").GetComponent<SkinnedMeshRenderer>(); i = AddUp(i);
                    newBodyBlender.rtHandMesh = currentLoadedSkin.transform.Find("geoGrp/brett_r_hand").GetComponent<SkinnedMeshRenderer>(); i = AddUp(i);
                    newBodyBlender.twistPosWeight = 0.33f;i = AddUp(i);
                    newBodyBlender.twistRotWeight = 0.5f; i = AddUp(i);
                    newBodyBlender.twistUpperArmWeight = 0.5f; i = AddUp(i);
                    newBodyBlender.characterHeight = 1.76f; i = AddUp(i);
                    newBodyBlender.charSpecific = SLZ_BodyBlender.CharSpecific.Brett; i = AddUp(i);
                    newBodyBlender.FingerBlendCurve = originalBodyBlender.FingerBlendCurve; i = AddUp(i);
                    newBodyBlender.offsetsDirty = true; i = AddUp(i);
                    newBodyBlender.posOffs = originalBodyBlender.posOffs; i = AddUp(i);
                    newBodyBlender.posOff = originalBodyBlender.posOff; i = AddUp(i);
                    newBodyBlender.rotOffs = originalBodyBlender.rotOffs; i = AddUp(i);
                    newBodyBlender.rotOff = originalBodyBlender.rotOff; i = AddUp(i);
                    newBodyBlender.mkbody = originalBodyBlender.mkbody; i = AddUp(i);
                    newBodyBlender.mkRefs = originalBodyBlender.mkRefs; i = AddUp(i);
                    newBodyBlender.mkTransformPos = originalBodyBlender.mkTransformPos; i = AddUp(i);
                    newBodyBlender.mkTransformRot = originalBodyBlender.mkTransformRot; i = AddUp(i);

                    newBodyBlender.AutoFillBones(); i = AddUp(i);

                    skeletonRig.characterAnimationManager = newManager;
                    skinned = true;

                    MelonLogger.Log("Skin applied");
                }
                catch (Exception e)
                {
                    MelonLogger.LogError(e.Message);
                }
                
                
            } else
            {
                MelonLogger.LogError("Null");
            }
        }

        Transform Brett_neutral;
        //Log player transforms
        public override void OnLevelWasLoaded(int level)
        {
            Brett_neutral = GameObject.Find("[RigManager (Default Brett)]/[SkeletonRig (GameWorld Brett)]/Brett@neutral").transform;

            if (Brett_neutral)
            {
                int i = 0;
                try {
                    //Get skinned mesh renderers to disable
                    i++;
                    brett_body = Brett_neutral.Find("geoGrp/brett_body").GetComponent<SkinnedMeshRenderer>();
                    i++;
                    brett_l_hand = Brett_neutral.Find("geoGrp/brett_l_hand").GetComponent<SkinnedMeshRenderer>();
                    i++;
                    brett_r_hand = Brett_neutral.Find("geoGrp/brett_r_hand").GetComponent<SkinnedMeshRenderer>();
                    i++;
                    //belt_mesh = Brett_neutral.Find("geoGrp/belt_mesh").GetComponent<SkinnedMeshRenderer>();
                    i++;
                    //shoulderStraps = Brett_neutral.Find("geoGrp/shoulderStraps").GetComponent<SkinnedMeshRenderer>();
                } catch (Exception e)
                {
                    MelonLogger.LogError("Caught error at line " + i.ToString()); ;
                    MelonLogger.LogError(e.Message);
                }
            }
        }
        bool skinned;
        //--BRETT--
        //Skinned mesh renderers
        SkinnedMeshRenderer brett_body;
        SkinnedMeshRenderer brett_l_hand;
        SkinnedMeshRenderer brett_r_hand;

    }

    public static class TransformExtention
    {
        public static void LoadTrans(this Transform original, Transform savedCopy)
        {
            original.position = savedCopy.position;
            original.rotation = savedCopy.rotation;
        }
    }
}
