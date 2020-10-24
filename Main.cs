using MelonLoader;
using System;
using System.IO;
using UnityEngine;
using StressLevelZero.Rig;

namespace PlayerModels
{
    public static class BuildInfo
    {
        public const string Name = "Custom Player Models";
        public const string Author = "Maranara";
        public const string Company = null;
        public const string Version = "1.0";
        public const string DownloadLink = null;
    }

    public class PlayerModels : MelonMod
    {
        #if usingBundle
        public static AssetBundle UIBundle;
        #endif
        public static bool skinned;
        public static string currentskinPath;
        public override void OnApplicationStart()
        {
            //Create skin category
            var menu = EasyMenu.Interfaces.AddNewInterface("Player Models", Color.red);
            UIHandler.RegisterPrefs();

            //Create directory if not there already
            Directory.CreateDirectory(Environment.CurrentDirectory + "\\UserData\\PlayerModels");
            //Search directory for skin files
            var skins = Directory.GetFiles(Environment.CurrentDirectory + "\\UserData\\PlayerModels");

#if usingBundle
            MelonLogger.LogWarning("Using UI asset bundle!");
            var asm = typeof(PlayerModels).Assembly;
            var tempPath = System.IO.Path.Combine(Application.dataPath, "playermodelcanvas");
            using (var stream = asm.GetManifestResourceStream(asm.GetManifestResourceNames().First(x => x.Contains("playermodelcanvas"))))
            using (var file = System.IO.File.OpenWrite(tempPath))
            {
                stream.CopyTo(file);
            }

            UIBundle = AssetBundle.LoadFromFile(tempPath);
            UIBundle.hideFlags = HideFlags.DontUnloadUnusedAsset;
            System.IO.File.Delete(tempPath);
#endif

            //Loop through skin files
            foreach (var skin in skins)
            {
                //Check if it's actually a .body file
                if (skin.Substring(Math.Max(0, skin.Length - 5)) == ".body")
                {
                    //It is a body file, add it to the category list
                    menu.CreateFunctionElement(Path.GetFileName(skin), Color.green, null, null, () =>
                    {
                        SkinLoading.LoadSkin(skin);
                    });
                }
            }

            menu.CreateFunctionElement("Default Skin", Color.blue, null, null, () =>
            {
                SkinLoading.ResetSkin();
            });
        }
        
        public override void OnLateUpdate()
        {
            if (skinned && rigmanager.uiRig != null)
                rigmanager.uiRig.OnLateUpdate();
            if (UIHandler.a)
                UIHandler.Update();
        }

        
        public static RigManager rigmanager;
        //Log player transforms
        public override void OnLevelWasLoaded(int level)
        {
            if (SkinLoading.currentLoadedBundle != null)
            {
                SkinLoading.currentLoadedBundle.Unload(true);
                SkinLoading.currentLoadedBundle = null;
            }
            rigmanager = GameObject.Find("[RigManager (Default Brett)]").GetComponent<RigManager>();
            BrettManager.Brett_neutral = GameObject.Find("[RigManager (Default Brett)]/[SkeletonRig (GameWorld Brett)]/Brett@neutral").transform;
            
        }

        public override void OnLevelWasInitialized(int level)
        {
            UIHandler.Summon(level, rigmanager);
            if (BrettManager.Brett_neutral)
            {
                BrettManager.FindParts();
                rigmanager.bodyVitals.quickmenuEnabled = true;

                UIHandler.CreateUI();
                if (skinned)
                {
                    UIHandler.EnableText();
                    SkinLoading.LoadSkin(currentskinPath);
                }
                else
                {
                    UIHandler.DisableText();
                }
            }
        }

        void CreateUI()
        {
#if usingBundle
            GameObject persistentUI = GameObject.Find("PlayerModelWatermark");
            if (persistentUI == null)
            {
                uiPrefab = UIBundle.LoadAsset("Assets/Canvas.prefab").Cast<GameObject>();
                GameObject uiObject = Instantiate(uiPrefab);
                uiObject.name = "PlayerModelWatermark" + UnityEngine.Random.Range(0, 999);
                uiObject.GetComponent<Canvas>().worldCamera = Camera.current;
                DontDestroyOnLoad(uiObject);
            } else
            {
                persistentUI.GetComponent<Canvas>().worldCamera = Camera.current;
            }
#endif
        }
    }
    
}
