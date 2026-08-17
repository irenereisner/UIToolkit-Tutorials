using UnityEngine;
using UnityEngine.UIElements;

namespace Reko
{
    public class UserProfileTutorial : MonoBehaviour
    {
        [SerializeField]
        private UserData m_userData;
        
        private UserData m_userDataCopy;
        
        void Start()
        {
            var uiDocument = GetComponent<UIDocument>();
            SetupUI(uiDocument.rootVisualElement);
        }
        
        private void SetupUI(VisualElement root)
        {
            var profile = root.Q<VisualElement>("profile");

            // save values in copy until the user hits the Save button
            m_userDataCopy = new UserData(GetUserData());
            profile.dataSource = m_userDataCopy;

            var saveButton = root.Q<Button>("profile__button-save");
            saveButton.RegisterCallback<ClickEvent>(OnSave);
        }

        

        private UserData GetUserData()
        {
            // replace this with real data from a database
            return m_userData;
        }

        private void OnSave(ClickEvent _)
        {
            m_userData.Refresh(m_userDataCopy);
            m_userDataCopy.Changed = false;
        }
    }
}
