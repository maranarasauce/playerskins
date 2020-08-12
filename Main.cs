using MelonLoader;
using System;
using System.IO;
using static UnityEngine.Object;
using UnityEngine;
using Unity;
using System.Collections;

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
        }
        public override void OnFixedUpdate()
        {
            if (skinned && currentLoadedSkin)
            {
                int i = 0;
                try
                {
                    Croot.LoadTrans(root); i++;

                    CHipL.LoadTrans(HipL); i++;
                    CKneeL.LoadTrans(KneeL); i++;
                    CAnkleL.LoadTrans(AnkleL); i++;
                    CFootL.LoadTrans(FootL); i++;
                    CToeL.LoadTrans(ToeL); i++;

                    CHipR.LoadTrans(HipR); i++;
                    CKneeR.LoadTrans(KneeR); i++;
                    CAnkleR.LoadTrans(AnkleR); i++;
                    CFootR.LoadTrans(FootR); i++;
                    CToeR.LoadTrans(ToeR); i++;

                    CSpine1.LoadTrans(Spine1); i++;
                    CSpine2.LoadTrans(Spine2); i++;
                    CSpineTop.LoadTrans(SpineTop); i++;

                    CNeck.LoadTrans(Neck); i++;
                    CNeck2.LoadTrans(Neck2); i++;
                    CNeckTop.LoadTrans(NeckTop); i++;

                    CClavicleL.LoadTrans(ClavicleL); i++;
                    CAuxL.LoadTrans(AuxL); i++;
                    CShoulderL.LoadTrans(ShoulderL); i++;
                    CArmLowerL.LoadTrans(ArmLowerL); i++;
                    CElbowL.LoadTrans(ElbowL); i++;
                    CWristL.LoadTrans(WristL); i++;
                    CHandL.LoadTrans(HandL); i++;
                    CHand2L.LoadTrans(Hand2L); i++;

                    CHandOpenL.LoadTrans(HandOpenL); i++;
                    CLFinger11.LoadTrans(LFinger11); i++;
                    CLFinger12.LoadTrans(LFinger12); i++;
                    CLFinger13.LoadTrans(LFinger13); i++;
                    CLFinger14.LoadTrans(LFinger14); i++;
                    CLFinger21.LoadTrans(LFinger21); i++;
                    CLFinger22.LoadTrans(LFinger22); i++;
                    CLFinger23.LoadTrans(LFinger23); i++;
                    CLFinger24.LoadTrans(LFinger24); i++;
                    CLFinger31.LoadTrans(LFinger31); i++;
                    CLFinger32.LoadTrans(LFinger32); i++;
                    CLFinger33.LoadTrans(LFinger33); i++;
                    CLFinger34.LoadTrans(LFinger34); i++;
                    CLFinger41.LoadTrans(LFinger41); i++;
                    CLFinger42.LoadTrans(LFinger42); i++;
                    CLFinger43.LoadTrans(LFinger43); i++;
                    CLFinger44.LoadTrans(LFinger44); i++;
                    CLFinger51.LoadTrans(LFinger51); i++;
                    CLFinger52.LoadTrans(LFinger52); i++;
                    CLFinger53.LoadTrans(LFinger53); i++;
                    CLFinger54.LoadTrans(LFinger54); i++;
                    CClavicleR.LoadTrans(ClavicleR); i++;

                    CAuxR.LoadTrans(AuxR); i++;
                    CShoulderR.LoadTrans(ShoulderR); i++;
                    CArmUpperR.LoadTrans(ArmUpperR); i++;
                    CArmLowerR.LoadTrans(ArmLowerR); i++;
                    CElbowR.LoadTrans(ElbowR); i++;
                    CWristR.LoadTrans(WristR); i++;
                    CHandR.LoadTrans(HandR); i++;
                    CHand2R.LoadTrans(Hand2R); i++;
                    CHandOpenR.LoadTrans(HandOpenL); i++;
                    CRFinger11.LoadTrans(RFinger11); i++;
                    CRFinger12.LoadTrans(RFinger12); i++;
                    CRFinger13.LoadTrans(RFinger13); i++;
                    CRFinger14.LoadTrans(RFinger14); i++;
                    CRFinger21.LoadTrans(RFinger21); i++;
                    CRFinger22.LoadTrans(RFinger22); i++;
                    CRFinger23.LoadTrans(RFinger23); i++;
                    CRFinger24.LoadTrans(RFinger24); i++;
                    CRFinger31.LoadTrans(RFinger31); i++;
                    CRFinger32.LoadTrans(RFinger32); i++;
                    CRFinger33.LoadTrans(RFinger33); i++;
                    CRFinger34.LoadTrans(RFinger34); i++;
                    CRFinger41.LoadTrans(RFinger41); i++;
                    CRFinger42.LoadTrans(RFinger42); i++;
                    CRFinger43.LoadTrans(RFinger43); i++;
                    CRFinger44.LoadTrans(RFinger44); i++;
                    CRFinger51.LoadTrans(RFinger51); i++;
                    CRFinger52.LoadTrans(RFinger52); i++;
                    CRFinger53.LoadTrans(RFinger53); i++;
                    CRFinger54.LoadTrans(LFinger54); i++;
                }
                catch (Exception e)
                {
                    MelonLogger.LogError("Caught error at line " + i.ToString()); ;
                    MelonLogger.LogError(e.Message);
                }
            }
        }
        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                LoadSkin(Environment.CurrentDirectory + "\\UserData\\PlayerSkins\\ford.body");
            }
            

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

            if (skinned == true && currentLoadedSkin != null)
            {
                GameObject.Destroy(currentLoadedSkin);
                if (currentLoadedBundle)
                {
                    currentLoadedBundle.Unload(true);
                }
            }

            currentLoadedBundle = AssetBundle.LoadFromFile(path);
            if (currentLoadedBundle != null)
            {
                int i = 0;
                try
                {
                    i++;
                    GameObject asset = currentLoadedBundle.LoadAsset("Assets/PlayerSkin.prefab").Cast<GameObject>();
                    i++;
                    
                    currentLoadedSkin = Instantiate(asset);
                    i++;
                    if (currentLoadedSkin.GetComponent<Animator>() != null){
                        GameObject.Destroy(currentLoadedSkin.GetComponent<Animator>());
                    }
                    
                    BoneworksModdingToolkit.SimpleFixes.FixObjectShader(currentLoadedSkin);
                    i++;
                    Croot = currentLoadedSkin.transform.Find("SHJntGrp/MAINSHJnt/ROOTSHJnt");
                    i++;
                    CHipL = Croot.Find("l_Leg_HipSHJnt");
                    i++;
                    CKneeL = Croot.Find("l_Leg_HipSHJnt/l_Leg_KneeSHJnt");
                    i++;
                    CAnkleL = Croot.Find("l_Leg_HipSHJnt/l_Leg_KneeSHJnt/l_Leg_AnkleSHJnt");
                    i++;
                    CFootL = Croot.Find("l_Leg_HipSHJnt/l_Leg_KneeSHJnt/l_Leg_AnkleSHJnt/l_Leg_BallSHJnt");

                    i++;
                    CToeL = Croot.Find("l_Leg_HipSHJnt/l_Leg_KneeSHJnt/l_Leg_AnkleSHJnt/l_Leg_BallSHJnt/l_Leg_ToeSHJnt");
                    i++;

                    CHipR = Croot.Find("r_Leg_HipSHJnt");
                    i++;
                    CKneeR = Croot.Find("r_Leg_HipSHJnt/r_Leg_KneeSHJnt");
                    i++;
                    CAnkleR = Croot.Find("r_Leg_HipSHJnt/r_Leg_KneeSHJnt/r_Leg_AnkleSHJnt");
                    i++;
                    CFootR = Croot.Find("r_Leg_HipSHJnt/r_Leg_KneeSHJnt/r_Leg_AnkleSHJnt/r_Leg_BallSHJnt");
                    
                    i++;
                    CToeR = Croot.Find("r_Leg_HipSHJnt/r_Leg_KneeSHJnt/r_Leg_AnkleSHJnt/r_Leg_BallSHJnt/r_Leg_ToeSHJnt");
                    i++;

                    CSpine1 = Croot.Find("Spine_01SHJnt");
                    i++;
                    CSpine2 = Croot.Find("Spine_01SHJnt/Spine_02SHJnt");
                    i++;
                    CSpineTop = Croot.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt");
                    i++;
                    CNeck = Croot.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/Neck_01SHJnt");
                    i++;
                    CNeck2 = Croot.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/Neck_01SHJnt/Neck_02SHJnt");
                    i++;
                    CNeckTop = Croot.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/Neck_01SHJnt/Neck_02SHJnt/Neck_TopSHJnt");
                    i++;

                    //Left ARM
                    CClavicleL = Croot.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/l_Arm_ClavicleSHJnt");
                    i++;
                    CAuxL = Croot.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/l_Arm_ClavicleSHJnt/l_AC_AuxSHJnt");
                    i++;
                    CShoulderL = Croot.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/l_Arm_ClavicleSHJnt/l_AC_AuxSHJnt/l_Arm_ShoulderSHJnt");
                    i++;
                    CArmUpperL = Croot.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/l_Arm_ClavicleSHJnt/l_AC_AuxSHJnt/l_Arm_ShoulderSHJnt/l_Arm_Upper_Curve1SHJnt");
                    i++;
                    CElbowL = Croot.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/l_Arm_ClavicleSHJnt/l_AC_AuxSHJnt/l_Arm_ShoulderSHJnt/l_Arm_Elbow_CurveSHJnt");
                    i++;
                    CArmLowerL = Croot.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/l_Arm_ClavicleSHJnt/l_AC_AuxSHJnt/l_Arm_ShoulderSHJnt/l_Arm_Elbow_CurveSHJnt/l_Arm_Lower_Curve1SHJnt");
                    i++;
                    CWristL = Croot.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/l_Arm_ClavicleSHJnt/l_AC_AuxSHJnt/l_Arm_ShoulderSHJnt/l_Arm_Elbow_CurveSHJnt/l_WristSHJnt");
                    i++;
                    CHandL = Croot.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/l_Arm_ClavicleSHJnt/l_AC_AuxSHJnt/l_Arm_ShoulderSHJnt/l_Arm_Elbow_CurveSHJnt/l_WristSHJnt/l_Hand_1SHJnt");
                    i++;
                    CHand2L = CHandL.GetChild(0);
                    i++;
                    CHandOpenL = Croot.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/l_Arm_ClavicleSHJnt/l_AC_AuxSHJnt/l_Arm_ShoulderSHJnt/l_Arm_Elbow_CurveSHJnt/l_WristSHJnt/l_Hand_1SHJnt/l_Hand_2SHJnt_open");
                    i++;
                    CLFinger11 = CHand2L.GetChild(0);
                    i++;
                    CLFinger12 = CLFinger11.GetChild(0);
                    i++;
                    CLFinger13 = CLFinger12.GetChild(0);
                    i++;
                    CLFinger14 = CLFinger13.GetChild(0);
                    i++;
                    CLFinger21 = CHand2L.GetChild(1);
                    i++;
                    CLFinger22 = CLFinger21.GetChild(0);
                    i++;
                    CLFinger23 = CLFinger22.GetChild(0);
                    i++;
                    CLFinger24 = CLFinger23.GetChild(0);
                    i++;
                    CLFinger31 = CHand2L.GetChild(2);
                    i++;
                    CLFinger32 = CLFinger31.GetChild(0);
                    i++;
                    CLFinger33 = CLFinger32.GetChild(0);
                    i++;
                    CLFinger34 = CLFinger33.GetChild(0);
                    i++;
                    CLFinger41 = CHand2L.GetChild(3);
                    i++;
                    CLFinger42 = CLFinger41.GetChild(0);
                    i++;
                    CLFinger43 = CLFinger42.GetChild(0);
                    i++;
                    CLFinger44 = CLFinger43.GetChild(0);
                    i++;
                    CLFinger51 = CHand2L.GetChild(5);
                    i++;
                    CLFinger52 = CLFinger51.GetChild(0);
                    i++;
                    CLFinger53 = CLFinger52.GetChild(0);
                    i++;
                    CLFinger54 = CLFinger53.GetChild(0);
                    i++;
                    //Right ARM
                    CClavicleR = Croot.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/r_Arm_ClavicleSHJnt");
                    i++;
                    CAuxR = Croot.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/r_Arm_ClavicleSHJnt/r_AC_AuxSHJnt");
                    i++;
                    CShoulderR = Croot.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/r_Arm_ClavicleSHJnt/r_AC_AuxSHJnt/r_Arm_ShoulderSHJnt");
                    i++;
                    CArmUpperR = Croot.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/r_Arm_ClavicleSHJnt/r_AC_AuxSHJnt/r_Arm_ShoulderSHJnt/r_Arm_Upper_Curve1SHJnt");
                    i++;
                    CElbowR = Croot.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/r_Arm_ClavicleSHJnt/r_AC_AuxSHJnt/r_Arm_ShoulderSHJnt/r_Arm_Elbow_CurveSHJnt");
                    i++;
                    CArmLowerR = Croot.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/r_Arm_ClavicleSHJnt/r_AC_AuxSHJnt/r_Arm_ShoulderSHJnt/r_Arm_Elbow_CurveSHJnt/r_Arm_Lower_Curve1SHJnt");
                    i++;
                    CWristR = Croot.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/r_Arm_ClavicleSHJnt/r_AC_AuxSHJnt/r_Arm_ShoulderSHJnt/r_Arm_Elbow_CurveSHJnt/r_WristSHJnt");
                    i++;
                    CHandR = Croot.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/r_Arm_ClavicleSHJnt/r_AC_AuxSHJnt/r_Arm_ShoulderSHJnt/r_Arm_Elbow_CurveSHJnt/r_WristSHJnt/r_Hand_1SHJnt");
                    i++;
                    CHand2R = Croot.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/r_Arm_ClavicleSHJnt/r_AC_AuxSHJnt/r_Arm_ShoulderSHJnt/r_Arm_Elbow_CurveSHJnt/r_WristSHJnt/r_Hand_1SHJnt/r_Hand_2SHJnt");
                    i++;
                    CHandOpenR = Croot.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/r_Arm_ClavicleSHJnt/r_AC_AuxSHJnt/r_Arm_ShoulderSHJnt/r_Arm_Elbow_CurveSHJnt/r_WristSHJnt/r_Hand_1SHJnt/r_Hand_2SHJnt_open");
                    i++;
                    CRFinger11 = CHand2R.GetChild(0);
                    i++;
                    CRFinger12 = CRFinger11.GetChild(0);
                    i++;
                    CRFinger13 = CRFinger12.GetChild(0);
                    i++;
                    CRFinger14 = CRFinger13.GetChild(0);
                    i++;
                    CRFinger21 = CHand2R.GetChild(1);
                    i++;
                    CRFinger22 = CRFinger21.GetChild(0);
                    i++;
                    CRFinger23 = CRFinger22.GetChild(0);
                    i++;
                    CRFinger24 = CRFinger23.GetChild(0);
                    i++;
                    CRFinger31 = CHand2R.GetChild(2);
                    i++;
                    CRFinger32 = CRFinger31.GetChild(0);
                    i++;
                    CRFinger33 = CRFinger32.GetChild(0);
                    i++;
                    CRFinger34 = CRFinger33.GetChild(0);
                    i++;
                    CRFinger41 = CHand2R.GetChild(3);
                    i++;
                    CRFinger42 = CRFinger41.GetChild(0);
                    i++;
                    CRFinger43 = CRFinger42.GetChild(0);
                    i++;
                    CRFinger44 = CRFinger43.GetChild(0);
                    i++;
                    CRFinger51 = CHand2R.GetChild(5);
                    i++;
                    CRFinger52 = CRFinger51.GetChild(0);
                    i++;
                    CRFinger53 = CRFinger52.GetChild(0);
                    i++;
                    CRFinger54 = CRFinger53.GetChild(0);
                    i++;

                    skinned = true;

                    MelonLogger.Log("Skin log done");
                }
                catch (Exception e)
                {
                    MelonLogger.LogError("Caught error at line " + i.ToString()); ;
                    MelonLogger.LogError(e.Message);
                }
                
                
            } else
            {
                MelonLogger.LogError("Null");
            }
        }

        //Log player transforms
        public override void OnLevelWasLoaded(int level)
        {
            Transform Brett_neutral = GameObject.Find("[RigManager (Default Brett)]/[SkeletonRig (GameWorld Brett)]/Brett@neutral").transform;

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
                    i++;

                    root = Brett_neutral.Find("SHJntGrp/MAINSHJnt/ROOTSHJnt");
                    
                    i++;
                    HipL = root.Find("l_Leg_HipSHJnt");
                    i++;
                    KneeL = root.Find("l_Leg_HipSHJnt/l_Leg_KneeSHJnt");
                    i++;
                    AnkleL = root.Find("l_Leg_HipSHJnt/l_Leg_KneeSHJnt/l_Leg_AnkleSHJnt");
                    i++;
                    FootL = root.Find("l_Leg_HipSHJnt/l_Leg_KneeSHJnt/l_Leg_AnkleSHJnt/l_Leg_BallSHJnt");
                    
                    i++;
                    ToeL = root.Find("l_Leg_HipSHJnt/l_Leg_KneeSHJnt/l_Leg_AnkleSHJnt/l_Leg_BallSHJnt/l_Leg_ToeSHJnt");
                    i++;

                    HipR = root.Find("r_Leg_HipSHJnt");
                    i++;
                    KneeR = root.Find("r_Leg_HipSHJnt/r_Leg_KneeSHJnt");
                    i++;
                    AnkleR = root.Find("r_Leg_HipSHJnt/r_Leg_KneeSHJnt/r_Leg_AnkleSHJnt");
                    i++;
                    FootR = root.Find("r_Leg_HipSHJnt/r_Leg_KneeSHJnt/r_Leg_AnkleSHJnt/r_Leg_BallSHJnt");
                    
                    i++;
                    ToeR = root.Find("r_Leg_HipSHJnt/r_Leg_KneeSHJnt/r_Leg_AnkleSHJnt/r_Leg_BallSHJnt/r_Leg_ToeSHJnt");
                    i++;

                    Spine1 = root.Find("Spine_01SHJnt");
                    i++;
                    Spine2 = root.Find("Spine_01SHJnt/Spine_02SHJnt");
                    i++;
                    SpineTop = root.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt");
                    i++;
                    Neck = root.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/Neck_01SHJnt");
                    i++;
                    Neck2 = root.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/Neck_01SHJnt/Neck_02SHJnt");
                    i++;
                    NeckTop = root.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/Neck_01SHJnt/Neck_02SHJnt/Neck_TopSHJnt");
                    i++;

                    //Left ARM
                    ClavicleL = root.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/l_Arm_ClavicleSHJnt");
                    i++;
                    AuxL = root.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/l_Arm_ClavicleSHJnt/l_AC_AuxSHJnt");
                    i++;
                    ShoulderL = root.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/l_Arm_ClavicleSHJnt/l_AC_AuxSHJnt/l_Arm_ShoulderSHJnt");
                    i++;
                    ArmUpperL = root.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/l_Arm_ClavicleSHJnt/l_AC_AuxSHJnt/l_Arm_ShoulderSHJnt/l_Arm_Upper_Curve1SHJnt");
                    i++;
                    ElbowL = root.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/l_Arm_ClavicleSHJnt/l_AC_AuxSHJnt/l_Arm_ShoulderSHJnt/l_Arm_Elbow_CurveSHJnt");
                    i++;
                    ArmLowerL = root.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/l_Arm_ClavicleSHJnt/l_AC_AuxSHJnt/l_Arm_ShoulderSHJnt/l_Arm_Elbow_CurveSHJnt/l_Arm_Lower_Curve1SHJnt");
                    i++;
                    WristL = root.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/l_Arm_ClavicleSHJnt/l_AC_AuxSHJnt/l_Arm_ShoulderSHJnt/l_Arm_Elbow_CurveSHJnt/l_WristSHJnt");
                    i++;
                    HandL = root.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/l_Arm_ClavicleSHJnt/l_AC_AuxSHJnt/l_Arm_ShoulderSHJnt/l_Arm_Elbow_CurveSHJnt/l_WristSHJnt/l_Hand_1SHJnt");
                    i++;
                    Hand2L = root.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/l_Arm_ClavicleSHJnt/l_AC_AuxSHJnt/l_Arm_ShoulderSHJnt/l_Arm_Elbow_CurveSHJnt/l_WristSHJnt/l_Hand_1SHJnt/l_Hand_2SHJnt");
                    i++;
                    HandOpenL = root.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/l_Arm_ClavicleSHJnt/l_AC_AuxSHJnt/l_Arm_ShoulderSHJnt/l_Arm_Elbow_CurveSHJnt/l_WristSHJnt/l_Hand_1SHJnt/l_Hand_2SHJnt_open");
                    i++;
                    LFinger11 = Hand2L.GetChild(0);
                    i++;
                    LFinger12 = LFinger11.GetChild(0);
                    i++;
                    LFinger13 = LFinger12.GetChild(0);
                    i++;
                    LFinger14 = LFinger13.GetChild(0);
                    i++;
                    LFinger21 = Hand2L.GetChild(1);
                    i++;
                    LFinger22 = LFinger21.GetChild(0);
                    i++;
                    LFinger23 = LFinger22.GetChild(0);
                    i++;
                    LFinger24 = LFinger23.GetChild(0);
                    i++;
                    LFinger31 = Hand2L.GetChild(2);
                    i++;
                    LFinger32 = LFinger31.GetChild(0);
                    i++;
                    LFinger33 = LFinger32.GetChild(0);
                    i++;
                    LFinger34 = LFinger33.GetChild(0);
                    i++;
                    LFinger41 = Hand2L.GetChild(3);
                    i++;
                    LFinger42 = LFinger41.GetChild(0);
                    i++;
                    LFinger43 = LFinger42.GetChild(0);
                    i++;
                    LFinger44 = LFinger43.GetChild(0);
                    i++;
                    LFinger51 = Hand2L.GetChild(5);
                    i++;
                    LFinger52 = LFinger51.GetChild(0);
                    i++;
                    LFinger53 = LFinger52.GetChild(0);
                    i++;
                    LFinger54 = LFinger53.GetChild(0);
                    i++;
                    //Right ARM
                    ClavicleR = root.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/r_Arm_ClavicleSHJnt");
                    i++;
                    AuxR = root.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/r_Arm_ClavicleSHJnt/r_AC_AuxSHJnt");
                    i++;
                    ShoulderR = root.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/r_Arm_ClavicleSHJnt/r_AC_AuxSHJnt/r_Arm_ShoulderSHJnt");
                    i++;
                    ArmUpperR = root.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/r_Arm_ClavicleSHJnt/r_AC_AuxSHJnt/r_Arm_ShoulderSHJnt/r_Arm_Upper_Curve1SHJnt");
                    i++;
                    ElbowR = root.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/r_Arm_ClavicleSHJnt/r_AC_AuxSHJnt/r_Arm_ShoulderSHJnt/r_Arm_Elbow_CurveSHJnt");
                    i++;
                    ArmLowerR = root.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/r_Arm_ClavicleSHJnt/r_AC_AuxSHJnt/r_Arm_ShoulderSHJnt/r_Arm_Elbow_CurveSHJnt/r_Arm_Lower_Curve1SHJnt");
                    i++;
                    WristR = root.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/r_Arm_ClavicleSHJnt/r_AC_AuxSHJnt/r_Arm_ShoulderSHJnt/r_Arm_Elbow_CurveSHJnt/r_WristSHJnt");
                    i++;
                    HandR = root.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/r_Arm_ClavicleSHJnt/r_AC_AuxSHJnt/r_Arm_ShoulderSHJnt/r_Arm_Elbow_CurveSHJnt/r_WristSHJnt/r_Hand_1SHJnt");
                    i++;
                    Hand2R = root.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/r_Arm_ClavicleSHJnt/r_AC_AuxSHJnt/r_Arm_ShoulderSHJnt/r_Arm_Elbow_CurveSHJnt/r_WristSHJnt/r_Hand_1SHJnt/r_Hand_2SHJnt");
                    i++;
                    HandOpenR = root.Find("Spine_01SHJnt/Spine_02SHJnt/Spine_TopSHJnt/r_Arm_ClavicleSHJnt/r_AC_AuxSHJnt/r_Arm_ShoulderSHJnt/r_Arm_Elbow_CurveSHJnt/r_WristSHJnt/r_Hand_1SHJnt/r_Hand_2SHJnt_open");
                    i++;
                    RFinger11 = Hand2R.GetChild(0);
                    i++;
                    RFinger12 = RFinger11.GetChild(0);
                    i++;
                    RFinger13 = RFinger12.GetChild(0);
                    i++;
                    RFinger14 = RFinger13.GetChild(0);
                    i++;
                    RFinger21 = Hand2R.GetChild(1);
                    i++;
                    RFinger22 = RFinger21.GetChild(0);
                    i++;
                    RFinger23 = RFinger22.GetChild(0);
                    i++;
                    RFinger24 = RFinger23.GetChild(0);
                    i++;
                    RFinger31 = Hand2R.GetChild(2);
                    i++;
                    RFinger32 = RFinger31.GetChild(0);
                    i++;
                    RFinger33 = RFinger32.GetChild(0);
                    i++;
                    RFinger34 = RFinger33.GetChild(0);
                    i++;
                    RFinger41 = Hand2R.GetChild(3);
                    i++;
                    RFinger42 = RFinger41.GetChild(0);
                    i++;
                    RFinger43 = RFinger42.GetChild(0);
                    i++;
                    RFinger44 = RFinger43.GetChild(0);
                    i++;
                    RFinger51 = Hand2R.GetChild(5);
                    i++;
                    RFinger52 = RFinger51.GetChild(0);
                    i++;
                    RFinger53 = RFinger52.GetChild(0);
                    i++;
                    RFinger54 = RFinger53.GetChild(0);
                    i++;
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
        SkinnedMeshRenderer belt_mesh;
        SkinnedMeshRenderer shoulderStraps;
        //Root
        Transform root;
        //Left leg
        Transform HipL;
        Transform KneeL;
        Transform AnkleL;
        Transform FootL;
        Transform ToeL;
        //Right leg
        Transform HipR;
        Transform KneeR;
        Transform AnkleR;
        Transform FootR;
        Transform ToeR;
        //Spine
        Transform Spine1;
        Transform Spine2;
        Transform SpineTop;
        //Neck
        Transform Neck;
        Transform Neck2;
        Transform NeckTop;
        //-----LEFT ARM------
        Transform ClavicleL;
        Transform AuxL;
        Transform ShoulderL;
        Transform ArmUpperL;
        Transform ElbowL;
        Transform ArmLowerL;
        Transform WristL;
        Transform HandL;
        Transform Hand2L;
        Transform HandOpenL;

        Transform LFinger11;
            Transform LFinger12;
                Transform LFinger13;
                    Transform LFinger14;
        Transform LFinger21;
            Transform LFinger22;
                Transform LFinger23;
                    Transform LFinger24;
        Transform LFinger31;
            Transform LFinger32;
                    Transform LFinger33;
                        Transform LFinger34;
        Transform LFinger41;
            Transform LFinger42;
                Transform LFinger43;
                    Transform LFinger44;
        Transform LFinger51;
            Transform LFinger52;
                Transform LFinger53;
                        Transform LFinger54;
        //-----Right ARM------
        Transform ClavicleR;
        Transform AuxR;
        Transform ShoulderR;
        Transform ArmUpperR;
        Transform ElbowR;
        Transform ArmLowerR;
        Transform WristR;
        Transform HandR;
        Transform Hand2R;
        Transform HandOpenR;

        Transform RFinger11;
            Transform RFinger12;
                Transform RFinger13;
                    Transform RFinger14;
        Transform RFinger21;
            Transform RFinger22;
                Transform RFinger23;
                    Transform RFinger24;
        Transform RFinger31;
            Transform RFinger32;
                Transform RFinger33;
                    Transform RFinger34;
        Transform RFinger41;
            Transform RFinger42;
                Transform RFinger43;
                    Transform RFinger44;
        Transform RFinger51;
            Transform RFinger52;
                Transform RFinger53;
                    Transform RFinger54;

        //--CUSTOM RIG--
        //Root
        Transform Croot;
        //Left leg
        Transform CHipL;
        Transform CKneeL;
        Transform CAnkleL;
        Transform CFootL;
        Transform CToeL;
        //Right leg
        Transform CHipR;
        Transform CKneeR;
        Transform CAnkleR;
        Transform CFootR;
        Transform CToeR;
        //Spine
        Transform CSpine1;
        Transform CSpine2;
        Transform CSpineTop;
        //Neck
        Transform CNeck;
        Transform CNeck2;
        Transform CNeckTop;
        //-----LEFT ARM------
        Transform CClavicleL;
        Transform CAuxL;
        Transform CShoulderL;
        Transform CArmUpperL;
        Transform CElbowL;
        Transform CArmLowerL;
        Transform CWristL;
        Transform CHandL;
        Transform CHand2L;
        Transform CHandOpenL;

        Transform CLFinger11;
        Transform CLFinger12;
        Transform CLFinger13;
        Transform CLFinger14;
        Transform CLFinger21;
        Transform CLFinger22;
        Transform CLFinger23;
        Transform CLFinger24;
        Transform CLFinger31;
        Transform CLFinger32;
        Transform CLFinger33;
        Transform CLFinger34;
        Transform CLFinger41;
        Transform CLFinger42;
        Transform CLFinger43;
        Transform CLFinger44;
        Transform CLFinger51;
        Transform CLFinger52;
        Transform CLFinger53;
        Transform CLFinger54;
        //-----Right ARM------
        Transform CClavicleR;
        Transform CAuxR;
        Transform CShoulderR;
        Transform CArmUpperR;
        Transform CElbowR;
        Transform CArmLowerR;
        Transform CWristR;
        Transform CHandR;
        Transform CHand2R;
        Transform CHandOpenR;

        Transform CRFinger11;
        Transform CRFinger12;
        Transform CRFinger13;
        Transform CRFinger14;
        Transform CRFinger21;
        Transform CRFinger22;
        Transform CRFinger23;
        Transform CRFinger24;
        Transform CRFinger31;
        Transform CRFinger32;
        Transform CRFinger33;
        Transform CRFinger34;
        Transform CRFinger41;
        Transform CRFinger42;
        Transform CRFinger43;
        Transform CRFinger44;
        Transform CRFinger51;
        Transform CRFinger52;
        Transform CRFinger53;
        Transform CRFinger54;
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
