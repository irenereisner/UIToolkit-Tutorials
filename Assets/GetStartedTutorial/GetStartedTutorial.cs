using UnityEngine;
using UnityEngine.UIElements;

namespace Reko
{
    public class GetStartedTutorial : MonoBehaviour
    {
        private Button m_startButton;
        private TextField m_nameInput;

        private void OnEnable()
        {
            var uiDocument = GetComponent<UIDocument>();
            
            m_startButton = uiDocument.rootVisualElement.Q<Button>("menu__button-start");
            m_nameInput = uiDocument.rootVisualElement.Q<TextField>("menu__input-name");
            
            m_startButton.RegisterCallback<ClickEvent>(OnStart);
            m_nameInput.RegisterValueChangedCallback(OnNameChanged);
            
            OnNameChanged(m_nameInput.value);
        }


        private void OnDisable()
        {
            m_startButton.UnregisterCallback<ClickEvent>(OnStart);
            m_nameInput.UnregisterValueChangedCallback(OnNameChanged);
        }
        
        
        private void OnStart(ClickEvent evt)
        {
            var userName = m_nameInput.value;
            Debug.Log("Hello " + userName);
        }
        
        
        private void OnNameChanged(ChangeEvent<string> evt)
        {
            OnNameChanged(evt.newValue);
        }

        private void OnNameChanged(string newName)
        {
            var nameIsValid = !string.IsNullOrWhiteSpace(newName);
            m_startButton.SetEnabled(nameIsValid);
        }
    }
}
