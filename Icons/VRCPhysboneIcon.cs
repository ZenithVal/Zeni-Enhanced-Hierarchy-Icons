//Drop into Enhanced Hierarchy/Editor/Icons Folder
//By ZenithVal for Enhanced Heirachy 2.0
//For VRChat Physbone Icons. Icons from Pumkin's Avatar Tools.

using System.Text;
using UnityEditor;
using UnityEngine;

namespace EnhancedHierarchy.Icons {
    public sealed class VRCPhysboneIcon : IconBase {

        private static readonly StringBuilder goComponents = new StringBuilder(500);
        private static readonly GUIContent tempTooltipContent = new GUIContent();
        private static bool HasVRCPhysbone;
        private static bool hasPhysboneComponent;
        private static bool hasColliderComponent;

        public override string Name { get { return "VRChat Physbone Icons"; } }
        public override float Width { get { return HasVRCPhysbone ? 15f : 0f; } }
        public override IconPosition Side { get { return IconPosition.All; } }

        public override Texture2D PreferencesPreview { get { return Resources.Load<Texture2D>("Physbone Icon"); } }
        public static Texture2D PhysboneCollider { get { return Resources.Load<Texture2D>("PhysboneCollider Icon"); } }
        

        public override void Init() {
            HasVRCPhysbone = false;

            hasPhysboneComponent = false;
            hasColliderComponent = false;


            if (!EnhancedHierarchy.IsGameObject)
                return;

            var components = EnhancedHierarchy.Components;

            try {
                for (var i = 0; i < components.Count; i++)
                {
                    string componentName = components[i].GetType().ToString();

                    if (componentName.Contains("VRCPhysBone"))
                    {
                        if (componentName.Contains("Collider")) {
                            hasColliderComponent = true;
                        }
                        else {
                            hasPhysboneComponent = true;
                        }

                        HasVRCPhysbone = true;
                        break;
                    }

                }
            }
            catch (System.Exception e) {
                Debug.Log("Enhanced Hierarchy: Error in VRCPhysboneIcon.cs: " + e);
            }
        }

        public override void DoGUI(Rect rect) {
            if (!EnhancedHierarchy.IsRepaintEvent || !EnhancedHierarchy.IsGameObject || !HasVRCPhysbone)
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