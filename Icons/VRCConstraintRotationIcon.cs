//Drop into Enhanced Hierarchy/Editor/Icons Folder
//By ZenithVal for Enhanced Heirachy 2.0

using System.Text;
using UnityEngine;
using VRC.SDK3.Dynamics.Constraint.Components;

namespace EnhancedHierarchy.Icons {
    public sealed class VRCConstraintRotationIcon : IconBase {

        private static readonly StringBuilder goComponents = new StringBuilder(500);
        private static readonly GUIContent tempTooltipContent = new GUIContent();
        private static bool hasComponent;

        public override string Name { get { return "VRChat Rotation Constraint Icon"; } }
        public override float Width { get { return hasComponent ? 15f : 0f; } }
        public override IconPosition Side { get { return IconPosition.All; } }

        public override Texture2D PreferencesPreview { get { return Resources.Load<Texture2D>("VRC_RotationConstraint Icon"); } }

        public override void Init() {
            hasComponent = false;

            if (!EnhancedHierarchy.IsGameObject)
                return;

            var components = EnhancedHierarchy.Components;

            for (var i = 0; i < components.Count; i++)
                if (components[i] is VRCRotationConstraint) {
                    hasComponent = true;
                    break;
                }
        }

        public override void DoGUI(Rect rect) {
            if (!EnhancedHierarchy.IsRepaintEvent || !EnhancedHierarchy.IsGameObject || !hasComponent)
                return;

            GUI.DrawTexture(rect, PreferencesPreview, ScaleMode.ScaleToFit);
        }

    }
}
