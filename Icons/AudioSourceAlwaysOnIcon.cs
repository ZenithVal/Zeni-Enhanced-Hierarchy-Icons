//Drop into Enhanced Hierarchy/Editor/Icons Folder
//By ZenithVal for Enhanced Heirachy 2.0

using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;


namespace EnhancedHierarchy.Icons {
    public sealed class AudioSourceIcon : IconBase {

        private static readonly StringBuilder goComponents = new StringBuilder(500);
        private static readonly GUIContent tempTooltipContent = new GUIContent();
        private static bool hasAudioSource;

        public override string Name { get { return "Audio Source Icon (Always Enabled)"; } }
        public override float Width { get { return hasAudioSource ? 15f : 0f; } }
        public override IconPosition Side { get { return IconPosition.All; } }

        public override Texture2D PreferencesPreview { get { return AssetPreview.GetMiniTypeThumbnail(typeof(AudioSource)); } }

        //public override string PreferencesTooltip { get { return "Some tag for the tooltip here"; } }

        public override void Init() {
            hasAudioSource = false;

            if (!EnhancedHierarchy.IsGameObject)
                return;

            var components = EnhancedHierarchy.Components;

            for (var i = 0; i < components.Count; i++)
                if (components[i] is AudioSource) {
                    hasAudioSource = true;
                    break;
                }
        }

        public override void DoGUI(Rect rect) {
            if (!EnhancedHierarchy.IsRepaintEvent || !EnhancedHierarchy.IsGameObject || !hasAudioSource)
                return;

            GUI.DrawTexture(rect, PreferencesPreview, ScaleMode.ScaleToFit);
        }

    }
}
