using UnityEngine;
using UnityEngine.UIElements;


namespace Reko
{
    /// <summary>
    /// A thin adapter to access the VisualElement root of the UIToolkit.
    /// It supports both the Panel Renderer and the UI Document.
    ///
    /// Add this component to the same game object as the Panel Renderer or the UI Document.
    /// Register a callback to VisualRootChanged and initialize your UI elements inside it.
    /// </summary>
    public class UIToolkitRootAccessor : MonoBehaviour
    {
        private VisualElement m_visualRootElement;

        public VisualElement VisualRoot
        {
            get => m_visualRootElement;
            private set
            {
                if (m_visualRootElement == value)
                    return;
                m_visualRootElement = value;
                VisualRootChanged?.Invoke(value);
            }
        }

        public bool HasRoot
        {
            get => m_visualRootElement != null;
        }
        
        public event System.Action<VisualElement> VisualRootChanged;
        
        
#if UNITY_6000_5_OR_NEWER
        private PanelRenderer m_panelRenderer;
#endif
        
        void OnEnable()
        {
            bool initialized = false;
#if UNITY_6000_5_OR_NEWER
            m_panelRenderer = GetComponent<PanelRenderer>();
            if (m_panelRenderer != null)
            {
                m_panelRenderer.RegisterUIReloadCallback(OnUIReload);
                initialized = true;
            }
#endif

            if (!initialized)
            {
                // look for UI Document if no Panel Renderer was found or the current Unity version doesn't support it.
                var uiDocument = GetComponent<UIDocument>();
                if (uiDocument != null)
                {
                    VisualRoot = uiDocument.rootVisualElement;
                }
                else
                {
                    Debug.LogError("UIToolkitRootAccessor: No Panel Renderer or UI Document found in the gameobject.");
                }
            }
        }

        void OnDisable()
        {
#if UNITY_6000_5_OR_NEWER
            if (m_panelRenderer != null)
            {
                m_panelRenderer.UnregisterUIReloadCallback(OnUIReload);
            }
#endif
        }


#if UNITY_6000_5_OR_NEWER
        private void OnUIReload(PanelRenderer renderer, VisualElement root)
        {
            VisualRoot = root;
        }
#endif


    }
}

