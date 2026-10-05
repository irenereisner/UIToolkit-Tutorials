/*
 * Copyright (c) 2026 Irene Reisner-Kollmann
 * https://reko3d.com
 * SPDX-License-Identifier: MIT
 */

using System;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

namespace Reko
{
    [Flags]
    public enum Difficulty
    {
        Easy = 1 << 0,
        Medium = 1 << 1,
        Hard = 1 << 2,
        Insane = 1 << 3,
    }
    
    [Serializable]
    public class GameSettings
    {
        [SerializeField, DontCreateProperty]
        private Difficulty m_difficulty;
        [CreateProperty]
        public Difficulty difficulty
        {
            get => m_difficulty;
            set
            {
                m_difficulty = value;
                Debug.Log($"Difficulty changed to {m_difficulty}");
            }
        }
    }
}