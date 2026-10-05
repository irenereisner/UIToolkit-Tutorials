/*
 * Copyright (c) 2026 Irene Reisner-Kollmann
 * https://reko3d.com
 * SPDX-License-Identifier: MIT
 */

#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UIElements;

namespace Reko
{
    public class ToggleButtonGroupTutorial : MonoBehaviour
    {
        [SerializeField]
        private GameSettings m_settings;

        private void Start()
        {
            var uiDocument = GetComponent<UIDocument>();
            uiDocument.rootVisualElement.dataSource = m_settings;
        }
        
        
                
#if UNITY_EDITOR
        [InitializeOnLoadMethod]
#else
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
#endif
        internal static void RegisterConverters()
        {
            ConverterGroups.RegisterGlobalConverter((ref Difficulty v) => 
                ToggleButtonGroupState.FromEnumFlags(v));
            ConverterGroups.RegisterGlobalConverter((ref ToggleButtonGroupState v) =>
                ToggleButtonGroupState.ToEnumFlags<Difficulty>(v));
        }
    }
}