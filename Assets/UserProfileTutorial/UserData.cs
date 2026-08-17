using System;
using Unity.Properties;
using UnityEngine;

namespace Reko
{
    [Serializable]
    public class UserData
    {
        [SerializeField, DontCreateProperty]
        private string m_name;
        [CreateProperty]
        public string Name
        {
            get => m_name;
            set
            {
                m_name = value;
                Changed = true;
            }
        }

        [SerializeField, DontCreateProperty]
        private string m_email;
        [CreateProperty]
        public string Email
        {
            get => m_email;
            set
            {
                m_email = value;
                Changed = true;
            }
        }

        [SerializeField, DontCreateProperty]
        private Texture2D m_image;
        [CreateProperty]
        public Texture2D Image
        {
            get => m_image;
            set
            {
                m_image = value;
                Changed = true;
            }
        }

        private bool m_changed;
        [CreateProperty]
        public bool Changed
        {
            get => m_changed;
            set => m_changed = value;
        }

        public UserData(string name = "", string email = "", Texture2D image = null)
        {
            m_name = name;
            m_email = email;
            m_image = image;
        }
        
        public UserData(UserData other)
        {
            m_name = other.m_name;
            m_email = other.m_email;
            m_image = other.m_image;
        }

        public void Refresh(UserData other)
        {
            m_name = other.m_name;
            m_email = other.m_email;
            m_image = other.m_image;
        }
    }
}
