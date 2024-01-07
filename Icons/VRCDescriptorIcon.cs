//Drop into Enhanced Hierarchy/Editor/Icons Folder
//By ZenithVal for Enhanced Heirachy 2.0
//Just adds a script icon next to Avatar Descriptors (For those of us that dont run monobehavior Icons)

using System.Text;
using UnityEditor;
using UnityEngine;

namespace EnhancedHierarchy.Icons {
    public sealed class VRCDescriptorIcon : IconBase {

        private static readonly StringBuilder goComponents = new StringBuilder(500);
        private static readonly GUIContent tempTooltipContent = new GUIContent();
        private static bool hasAvatarDescriptor;

        public override string Name { get { return "VRChat Avatar Descriptor Icon"; } }
        public override float Width { get { return hasAvatarDescriptor ? 15f : 0f; } }
        public override IconPosition Side { get { return IconPosition.All; } }

        public override Texture2D PreferencesPreview { get { return EditorGUIUtility.IconContent("Avatar Icon").image as Texture2D; } }
        

        public override void Init() {
            hasAvatarDescriptor = false;

            if (!EnhancedHierarchy.IsGameObject)
                return;

            var components = EnhancedHierarchy.Components;

            for (var i = 0; i < components.Count; i++)
            {
                string componentName = components[i].GetType().ToString();

                if (componentName.Contains("VRCAvatarDescriptor"))
                {
                    hasAvatarDescriptor = true;
                    break;
                }

            }
        }

        public override void DoGUI(Rect rect) {
            if (!EnhancedHierarchy.IsRepaintEvent || !EnhancedHierarchy.IsGameObject || !hasAvatarDescriptor)
                return;

            if (hasAvatarDescriptor)
            {
                GUI.DrawTexture(rect, PreferencesPreview, ScaleMode.ScaleToFit);
                return;
            }

        }

    }
}