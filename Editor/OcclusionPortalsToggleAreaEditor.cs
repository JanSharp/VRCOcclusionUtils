using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEditor;
using UdonSharpEditor;

namespace JanSharp
{
    [InitializeOnLoad]
    public static class OcclusionPortalsToggleAreaOnBuild
    {
        static OcclusionPortalsToggleAreaOnBuild() => JanSharp.OnBuildUtil.RegisterType<OcclusionPortalsToggleArea>(OnBuild);

        private static bool OnBuild(OcclusionPortalsToggleArea area)
        {
            SerializedObject collidersProxy = new SerializedObject(area.GetComponents<Collider>());
            collidersProxy.FindProperty("m_IsTrigger").boolValue = true;
            collidersProxy.ApplyModifiedProperties();
            return true;
        }
    }
}
