using System;
using UnityEngine;

namespace PhEngine.Motion
{
    [Serializable]
    public class MotionSetting_Scaler : MotionSetting_Tweener
    {
        [Header("Start")]
        public bool isSetScaleOnStart = false;
        public Vector3 startScale;

        [Header("Finish")]
        public Vector3 targetScale;
    }
}