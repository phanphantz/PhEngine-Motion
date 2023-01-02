using System;
using UnityEngine;

namespace PhEngine.Motion
{
    [Serializable]
    public class MotionSetting_ColorFader : MotionSetting_Tweener
    {
        [Header("Start")]
        public bool isSetColorOnStart = false;
        public Color startColor;

        [Header("Finish")]
        public Color targetColor;
    }
}