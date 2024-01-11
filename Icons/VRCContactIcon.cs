//Drop into Enhanced Hierarchy/Editor/Icons Folder
//By ZenithVal for Enhanced Heirachy 2.0
//For VRChat Contact Icons.

using System.Text;
using UnityEditor;
using UnityEngine;

namespace EnhancedHierarchy.Icons {
    public sealed class VRCContactIcon : IconBase {

        private static readonly StringBuilder goComponents = new StringBuilder(500);
        private static readonly GUIContent tempTooltipContent = new GUIContent();
        private static bool hasContactComponent;
        private static bool hasContactReceiver;
        private static bool hasContactSender;

        public override string Name { get { return "VRChat Contact Icons"; } }
        public override float Width { get { return hasContactComponent ? 15f : 0f; } }
        public override IconPosition Side { get { return IconPosition.All; } }

        public override Texture2D PreferencesPreview { get { return EditorGUIUtility.IconContent("sv_icon_dot1_pix16_gizmo").image as Texture2D; } }
        public static Texture2D ContactSender { get { return EditorGUIUtility.IconContent("sv_icon_dot4_pix16_gizmo").image as Texture2D; } }
        

        public override void Init() {
            hasContactComponent = false;
            hasContactReceiver = false;
            hasContactSender = false; 

            if (!EnhancedHierarchy.IsGameObject)
                return;

            var components = EnhancedHierarchy.Components;

            try {   
                for (var i = 0; i < components.Count; i++)
                {
                    string componentName = components[i].GetType().ToString();
                    if (componentName.Contains("VRCContact"))
                    {
                        if (componentName.Contains("Receiver")) {
                            hasContactComponent = true;
                            hasContactReceiver = true;
                        }

                        if (componentName.Contains("Sender")) {
                            hasContactComponent = true;
                            hasContactSender = true;
                        }
                        break;
                    }
                }
            }
            catch (System.Exception e) {
                Debug.Log("Enhanced Hierarchy: Error in VRCContactIcon.cs: " + e);
            }
        }

        public override void DoGUI(Rect rect) {
            if (!EnhancedHierarchy.IsRepaintEvent || !EnhancedHierarchy.IsGameObject || !hasContactComponent)
                return;

            if (hasContactReceiver)
            {
                GUI.DrawTexture(rect, PreferencesPreview, ScaleMode.ScaleToFit);
            }

            if (hasContactSender)
            {
                GUI.DrawTexture(rect, ContactSender, ScaleMode.ScaleToFit);
            }

        }

    }
}