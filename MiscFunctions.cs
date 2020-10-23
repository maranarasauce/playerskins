using System;
using UnityEngine;
using StressLevelZero.Player;
using StressLevelZero.VRMK;
using StressLevelZero.Rig;
using System.Collections;

namespace PlayerModels
{
    public static class MiscFunctions
    {
        public static Component CopyComponent(Component original, Component newcopy)
        {
            Type type = original.GetType();
            Component copy = newcopy;
            // Copied fields can be restricted with BindingFlags
            System.Reflection.FieldInfo[] fields = type.GetFields();
            foreach (System.Reflection.FieldInfo field in fields)
            {
                field.SetValue(copy, field.GetValue(original));
            }
            return copy;
        }

        public static IEnumerator RefreshManager(RigManager rigmanager, CharacterAnimationManager originalManager, SLZ_Body _Body)
        {
            originalManager.enabled = false;
            rigmanager.gameWorldSkeletonRig.body.enabled = false;
            _Body.enabled = false;
            yield return new WaitForEndOfFrame();
            originalManager.enabled = true;
            rigmanager.gameWorldSkeletonRig.body.enabled = true;
        }
    }
}
