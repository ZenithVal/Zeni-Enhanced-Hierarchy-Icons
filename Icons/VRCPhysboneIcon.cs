//Drop into Enhanced Hierarchy/Editor/Icons Folder
//By ZenithVal for Enhanced Heirachy 2.0
//For VRChat Physbone Icons. Icons from Pumkin's Avatar Tools.

using System.Text;
using UnityEditor;
using UnityEngine;
using VRC.SDK3.Dynamics.PhysBone.Components;

namespace EnhancedHierarchy.Icons {
    public sealed class VRCPhysboneIcon : IconBase {

        private static readonly StringBuilder goComponents = new StringBuilder(500);
        private static readonly GUIContent tempTooltipContent = new GUIContent();
        private static bool hasComponent;
        private static bool hasPhysboneComponent;
        private static bool hasColliderComponent;

        public override string Name { get { return "VRChat Physbone Icons"; } }
        public override float Width { get { return hasComponent ? 15f : 0f; } }
        public override IconPosition Side { get { return IconPosition.All; } }

        public override Texture2D PreferencesPreview { get { return Resources.Load<Texture2D>("VRC_Physbone Icon"); } }
        public static Texture2D PhysboneCollider { get { return Resources.Load<Texture2D>("VRC_PhysboneCollider Icon"); } }
        

        public override void Init() {
            hasComponent = false;

            hasPhysboneComponent = false;
            hasColliderComponent = false;


            if (!EnhancedHierarchy.IsGameObject)
                return;

            var components = EnhancedHierarchy.Components;

            try {
                for (var i = 0; i < components.Count; i++)
                {
                    if (components[i] is VRCPhysBone)
                    {
                        hasPhysboneComponent = true;
                        hasComponent = true;
                    }
                    else if (components[i] is VRCPhysBoneCollider)
                    {
                        hasColliderComponent = true;
                        hasComponent = true;
                    }

                }
            }
            catch (System.Exception e) {
                Debug.Log("Enhanced Hierarchy: Error in VRCPhysboneIcon.cs: " + e);
            }
        }

        public override void DoGUI(Rect rect) {
            if (!EnhancedHierarchy.IsRepaintEvent || !EnhancedHierarchy.IsGameObject || !hasComponent)
                return;

            if (hasPhysboneComponent)
            {
                GUI.DrawTexture(rect, PreferencesPreview, ScaleMode.ScaleToFit);
            }
            else if (hasColliderComponent)
            {
                GUI.DrawTexture(rect, PhysboneCollider, ScaleMode.ScaleToFit);
            }

        }

    }
}