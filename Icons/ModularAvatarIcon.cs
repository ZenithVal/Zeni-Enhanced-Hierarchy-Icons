//Drop into Enhanced Hierarchy/Editor/Icons Folder
//By ZenithVal for Enhanced Heirachy 2.0
//For Modular Avatar Icons https://github.com/bdunderscore/modular-avatar
//Probably only works if installed via VCC/Package Manager. I don't know what I'm doing.

using System.Text;
using UnityEditor;
using UnityEngine;

namespace EnhancedHierarchy.Icons {
    public sealed class ModularAvatarIcon : IconBase {

        private static readonly StringBuilder goComponents = new StringBuilder(500);
        private static readonly GUIContent tempTooltipContent = new GUIContent();
        private static bool hasModularAvatarComponent;

        public override string Name { get { return "Modular Avatar Icons"; } }
        public override float Width { get { return hasModularAvatarComponent ? 15f : 0f; } }
        public override IconPosition Side { get { return IconPosition.All; } }

        public override Texture2D PreferencesPreview { get { return AssetDatabase.LoadAssetAtPath<Texture2D>(AssetDatabase.GUIDToAssetPath("a8edd5bd1a0a64a40aa99cc09fb5f198")); } }
        //Referencing the GUID. This is probably a bad way to do this... sorry.

        public override void Init() {
            hasModularAvatarComponent = false;

            if (!EnhancedHierarchy.IsGameObject)
                return;

            var components = EnhancedHierarchy.Components;

            try {
                for (var i = 0; i < components.Count; i++)
                {
                    string componentName = components[i].GetType().ToString();
                    if (componentName.Contains("ModularAvatar"))
                    {
                        hasModularAvatarComponent = true;
                        break;
                    }
                }
            }
            catch (System.Exception e) {
                Debug.Log("Enhanced Hierarchy: Error in ModularAvatarIcon.cs: " + e);
            }
        }

        public override void DoGUI(Rect rect) {
            if (!EnhancedHierarchy.IsRepaintEvent || !EnhancedHierarchy.IsGameObject || !hasModularAvatarComponent)
                return;

            GUI.DrawTexture(rect, PreferencesPreview, ScaleMode.ScaleToFit);
        }

    }
}