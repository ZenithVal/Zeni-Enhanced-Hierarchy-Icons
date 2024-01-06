//Drop into Enhanced Hierarchy/Editor/Icons Folder
//By ZenithVal for Enhanced Heirachy 2.0
//For FinalIK Icons

using System;
using System.Collections.Generic;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace EnhancedHierarchy.Icons {
    public sealed class FinalIKIcons : IconBase {

        private static readonly StringBuilder goComponents = new StringBuilder(500);
        private static readonly GUIContent tempTooltipContent = new GUIContent();
        private static bool hasFinalIKComponent;

        public override string Name { get { return "FinalIK Avatar Icons"; } }
        public override float Width { get { return hasFinalIKComponent ? 15f : 0f; } }
        public override IconPosition Side { get { return IconPosition.All; } }

        public override Texture2D PreferencesPreview { get { return AssetDatabase.LoadAssetAtPath<Texture2D>(AssetDatabase.GUIDToAssetPath("79450243724744b44820e5468e418048")); } }
        //I really don't use any other IKs besides CCDIK, if you ever actually need more I guess let me know. 
        //Also obligatory sorry for using the GUID ~ Dunno what I'm doing.

        public override void Init() {
            hasFinalIKComponent = false;

            if (!EnhancedHierarchy.IsGameObject)
                return;

            var components = EnhancedHierarchy.Components;

            for (var i = 0; i < components.Count; i++)
            {
                string componentName = components[i].GetType().ToString();
                if (componentName.Contains("CCDIK"))
                {
                    hasFinalIKComponent = true;
                    break;
                }
            }
        }

        public override void DoGUI(Rect rect) {
            if (!EnhancedHierarchy.IsRepaintEvent || !EnhancedHierarchy.IsGameObject || !hasFinalIKComponent)
                return;

            GUI.DrawTexture(rect, PreferencesPreview, ScaleMode.ScaleToFit);
        }

    }
}