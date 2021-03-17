using UnityEngine;
using UnityEngine.UI;
using BoneworksModdingToolkit;
using StressLevelZero.Rig;
using StressLevelZero.UI.Radial;
using StressLevelZero.Data;
using StressLevelZero.Props.Weapons;
using MelonLoader;

namespace PlayerModels
{
    public static class UIGeneration
    {
		static Canvas canvas;
		static Text watermarkText;
        public static void CreateCanvas()
        {
			canvas = new GameObject("DisclaimerCanvas" + Random.RandomRange(0, 999)).AddComponent<Canvas>();
			canvas.renderMode = RenderMode.ScreenSpaceOverlay;
			canvas.worldCamera = Camera.current;
			CanvasScaler canvasScaler = canvas.gameObject.AddComponent<CanvasScaler>();
			canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
			canvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
			canvasScaler.referenceResolution = new Vector2(1920f, 1080f);
			Text text = UI.CreateText(canvas, "ANY PLAYER MODELS USED ARE NOT OFFICIAL\nMod made by Maranara", 1, new Vector2(1920f, 1080f), new Vector2(0f, 1f), new Vector2(10f, -10f), UI.AnchorType.UpperLeft, TextAnchor.UpperLeft);
			text.color = new Color(255, 199, 0, 0.15f);
			text.fontSize = 28;
			text.fontStyle = FontStyle.Bold;
			text.GetComponent<RectTransform>().localScale = Vector3.one;
			text.GetComponent<RectTransform>().sizeDelta = new Vector2(500f, 100f);
			watermarkText = text;
		}

		public static void CheckText()
		{
			int a = 1587835253;
			if (watermarkText != null && watermarkText.text.GetHashCode() == a)
			{
				watermarkText.enabled = true;
			} else
			{
				CreateCanvas();
			}
		}

		public static void DisableCanvas() => watermarkText.enabled = false;

		#region void
		public static void RegisterPrefs()
		{
			MelonPrefs.RegisterCategory("Player Models", "");
			MelonPrefs.RegisterInt("Player Models", "UserNumber", Random.Range(1, 4));
			MelonPrefs.RegisterString("Player Models", "Skin", "");
			fun = MelonPrefs.GetInt("Player Models", "UserNumber");
			string a = MelonPrefs.GetString("Player Models", "Skin");
			if (a != "")
			{
				PlayerModels.currentskinPath = a;
				PlayerModels.skinned = true;
			}
		}
		public static bool a = false;
		static GameObject vb;
		static GameObject bg;
		static int fun;

		public static void GenerateAvatar(int l, RigManager rig)
		{
			if (l == 21)
			{
				int tempFun = Random.Range(0, 5);
				if (fun != 3 || tempFun != 1)
					return;
				PopUpMenuView menu = rig.uiRig.popUpMenu;
				GameObject spawngun = menu.utilityGunSpawnable.prefab;
				SpawnableMasterListData masterList = spawngun.GetComponent<SpawnGun>().masterList;
				bg = GameObject.Instantiate(spawngun);
				Material v = bg.transform.Find("ART/COREBOMB/VOIDSPHERE").GetComponent<MeshRenderer>().sharedMaterial;
				for (int i = 0; i < masterList.objects.Length; i++)
				{
					if (masterList.objects[i].title == "Null Body Corrupted")
					{
						vb = GameObject.Instantiate(masterList.objects[i].prefab);
						vb.transform.position = new Vector3(3, 4, 3);
						Rigidbody[] rbs = vb.GetComponentsInChildren<Rigidbody>();
						foreach (Rigidbody rb in rbs)
						{
							rb.isKinematic = true;
						}
						SkinnedMeshRenderer[] smrs = vb.GetComponentsInChildren<SkinnedMeshRenderer>();
						foreach (SkinnedMeshRenderer smr in smrs)
						{
							Material[] newMats = new Material[smr.materials.Length];
							for (int j = 0; j < newMats.Length; j++)
							{
								newMats[j] = v;
							}

							smr.materials = newMats;
						}
						MeshRenderer[] mrs = vb.GetComponentsInChildren<MeshRenderer>();
						foreach (MeshRenderer mr in mrs)
						{
							Material[] newMats = new Material[mr.materials.Length];
							for (int j = 0; j < newMats.Length; j++)
							{
								newMats[j] = v;
							}

							mr.materials = newMats;
						}
						a = true;
					}
				}
			}
		}
		static Transform pt;
		public static void CheckAvatar()
		{
			if (pt == null)
				pt = BoneworksModdingToolkit.Player.FindPlayer().transform;
			Vector3 p = pt.position;
			Vector3 o = vb.transform.position;
			float d = Vector3.Distance(p, o);
			if (d < 82)
			{
				GameObject.Destroy(vb);
				GameObject.Destroy(bg);
				a = false;
			}
		}
        #endregion
    }
}
