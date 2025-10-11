#if UNITY_2021_2_OR_NEWER
using System;
using System.Collections.Generic;
using UnityEditor.Overlays;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEngine;
using UnityEditor.Toolbars;

namespace SingularityGroup.HotReload.Editor
{
    [Overlay(typeof(SceneView), "Hot Reload", true)]
    [Icon("Assets/HotReload/Editor/Resources/Icon_DarkMode.png")]
    internal class HotReloadOverlay : ToolbarOverlay
    {
        private HotReloadOverlay() : base(HotReloadToolbarIndicationButton.id, HotReloadToolbarEventsButton.id,
            HotReloadToolbarRecompileButton.id)
        {
            EditorApplication.update += Update;
        }

        private EditorIndicationState.IndicationStatus lastIndicationStatus;

        [EditorToolbarElement(id, typeof(SceneView))]
        private class HotReloadToolbarIndicationButton : EditorToolbarButton, IAccessContainerWindow
        {
            internal const string id = "HotReloadOverlay/LogoButton";
            public EditorWindow containerWindow { get; set; }

            private EditorIndicationState.IndicationStatus lastIndicationStatus;

            internal HotReloadToolbarIndicationButton()
            {
                icon = GetIndicationIcon();
                tooltip = EditorIndicationState.IndicationStatusText;
                clicked += OnClick;
                EditorApplication.update += Update;
            }

            private void OnClick()
            {
                EditorWindow.GetWindow<HotReloadWindow>().Show();
                EditorWindow.GetWindow<HotReloadWindow>().SelectTab(typeof(HotReloadRunTab));
            }

            private void Update()
            {
                if (lastIndicationStatus != EditorIndicationState.CurrentIndicationStatus)
                {
                    icon = GetIndicationIcon();
                    tooltip = EditorIndicationState.IndicationStatusText;
                    lastIndicationStatus = EditorIndicationState.CurrentIndicationStatus;
                }
            }

            ~HotReloadToolbarIndicationButton()
            {
                clicked -= OnClick;
                EditorApplication.update -= Update;
            }
        }

        [EditorToolbarElement(id, typeof(SceneView))]
        private class HotReloadToolbarEventsButton : EditorToolbarButton, IAccessContainerWindow
        {
            internal const string id = "HotReloadOverlay/EventsButton";
            public EditorWindow containerWindow { get; set; }

            private bool lastShowingRedDot;

            internal HotReloadToolbarEventsButton()
            {
                icon = HotReloadState.ShowingRedDot
                    ? GUIHelper.GetInvertibleIcon(InvertibleIcon.EventsNew)
                    : GUIHelper.GetInvertibleIcon(InvertibleIcon.Events);
                tooltip = "Events";
                clicked += OnClick;
                EditorApplication.update += Update;
            }

            private void OnClick()
            {
                HotReloadEventPopup.Open(PopupSource.Overlay, Event.current.mousePosition);
            }

            private void Update()
            {
                if (lastShowingRedDot != HotReloadState.ShowingRedDot)
                {
                    icon = HotReloadState.ShowingRedDot
                        ? GUIHelper.GetInvertibleIcon(InvertibleIcon.EventsNew)
                        : GUIHelper.GetInvertibleIcon(InvertibleIcon.Events);
                    lastShowingRedDot = HotReloadState.ShowingRedDot;
                }
            }

            ~HotReloadToolbarEventsButton()
            {
                clicked -= OnClick;
                EditorApplication.update -= Update;
            }
        }


        [EditorToolbarElement(id, typeof(SceneView))]
        private class HotReloadToolbarRecompileButton : EditorToolbarButton, IAccessContainerWindow
        {
            internal const string id = "HotReloadOverlay/RecompileButton";

            public EditorWindow containerWindow { get; set; }

            private Texture2D refreshIcon => GUIHelper.GetInvertibleIcon(InvertibleIcon.Recompile);

            internal HotReloadToolbarRecompileButton()
            {
                icon = refreshIcon;
                tooltip = "Recompile";
                clicked += HotReloadRunTab.RecompileWithChecks;
            }
        }

        private static Texture2D latestIcon;
        private static Dictionary<string, Texture2D> iconTextures = new();
        private static Spinner spinner = new(100);

        private static Texture2D GetIndicationIcon()
        {
            if (EditorIndicationState.IndicationIconPath == null || EditorIndicationState.SpinnerActive)
                latestIcon = spinner.GetIcon();
            else
                latestIcon = GUIHelper.GetLocalIcon(EditorIndicationState.IndicationIconPath);
            return latestIcon;
        }

        private static Image indicationIcon;
        private static Label indicationText;

        private bool initialized;

        /// <summary>
        /// Create Hot Reload overlay panel.
        /// </summary>
        public override VisualElement CreatePanelContent()
        {
            var root = new VisualElement { name = "Hot Reload Indication" };
            root.style.flexDirection = FlexDirection.Row;

            indicationIcon = new Image { image = GUIHelper.GetLocalIcon(EditorIndicationState.greyIconPath) };
            indicationIcon.style.height = 30;
            indicationIcon.style.width = 30;
            indicationIcon.style.marginLeft = 2;
            indicationIcon.style.marginTop = 1;
            indicationIcon.style.marginRight = 5;

            indicationText = new Label { text = EditorIndicationState.IndicationStatusText };
            indicationText.style.paddingTop = 9;
            indicationText.style.marginLeft = new StyleLength(StyleKeyword.Auto);
            indicationText.style.marginRight = new StyleLength(StyleKeyword.Auto);

            root.Add(indicationIcon);
            root.Add(indicationText);
            root.style.width = 190;
            root.style.height = 32;
            initialized = true;
            return root;
        }

        private static bool _repaint;
        private static bool _instantRepaint;
        private static DateTime _lastRepaint;

        private void Update()
        {
            if (!initialized) return;
            if (lastIndicationStatus != EditorIndicationState.CurrentIndicationStatus)
            {
                indicationIcon.image = GetIndicationIcon();
                indicationText.text = EditorIndicationState.IndicationStatusText;
                lastIndicationStatus = EditorIndicationState.CurrentIndicationStatus;
            }

            try
            {
                if (HotReloadEventPopup.I.open
                    && EditorWindow.mouseOverWindow
                    && EditorWindow.mouseOverWindow?.GetType() == typeof(UnityEditor.PopupWindow)
                   )
                    _repaint = true;
            }
            catch (NullReferenceException)
            {
                // Unity randomly throws nullrefs when EditorWindow.mouseOverWindow gets accessed
            }

            if (_repaint && DateTime.UtcNow - _lastRepaint > TimeSpan.FromMilliseconds(33))
            {
                _repaint = false;
                _instantRepaint = true;
            }

            if (_instantRepaint) HotReloadEventPopup.I.Repaint();
        }

        ~HotReloadOverlay()
        {
            EditorApplication.update -= Update;
        }
    }
}
#endif