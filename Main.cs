using MelonLoader;
using System;
using System.IO;
using static UnityEngine.Object;
using UnityEngine;
using StressLevelZero.Rig;
using System.Linq;

namespace PlayerModels
{
    public static class BuildInfo
    {
        public const string Name = "Custom Player Models"; // Name of the Mod.  (MUST BE SET)
        public const string Author = "Maranara"; // Author of the Mod.  (Set as null if none)
        public const string Company = null; // Company that made the Mod.  (Set as null if none)
        public const string Version = "1.0"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
    }

    public class PlayerModels : MelonMod
    {
        public static AssetBundle UIBundle;
        public static bool skinned;
        public override void OnApplicationStart()
        {
            //Create skin category
            var menu = EasyMenu.Interfaces.AddNewInterface("Player Models", Color.red);

            //Create directory if not there already
            Directory.CreateDirectory(Environment.CurrentDirectory + "\\UserData\\PlayerModels");
            //Search directory for skin files
            var skins = Directory.GetFiles(Environment.CurrentDirectory + "\\UserData\\PlayerModels");

            #region UI Bundle Loader
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
            #endregion

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
            if (skinned)
                rigmanager.uiRig.OnLateUpdate();
        }

        
        public static RigManager rigmanager;
        //Log player transforms
        public override void OnLevelWasLoaded(int level)
        {
            skinned = false;
            if (SkinLoading.currentLoadedBundle != null)
            {
                SkinLoading.currentLoadedBundle.Unload(true);
                SkinLoading.currentLoadedBundle = null;
            }
            rigmanager = GameObject.Find("[RigManager (Default Brett)]").GetComponent<RigManager>();
            BrettManager.Brett_neutral = GameObject.Find("[RigManager (Default Brett)]/[SkeletonRig (GameWorld Brett)]/Brett@neutral").transform;

            if (BrettManager.Brett_neutral)
            {
                try
                {
                    rigmanager.bodyVitals.quickmenuEnabled = true;
                }
                catch (Exception e)
                {
                    MelonLogger.LogError("Caught error trying to disable the skinned mesh renderers");
                    MelonLogger.LogError(e.Message);
                }

                CreateUI();
            }
        }



        GameObject uiPrefab;
        void CreateUI()
        {
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
        }
    }
    
}
