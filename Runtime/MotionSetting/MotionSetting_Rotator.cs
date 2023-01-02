using System;
using UnityEngine;

namespace PhEngine.Motion
{
    [Serializable]
    public class MotionSetting_Rotator : MotionSetting_Tweener
    {
        [Header("Start")]
        public bool isSetEulerAngleOnStart = false;
        public Vector3 startEulerAngle;

        [Header("Finish")]
        public Vector3 targetEulerAngle;
    }
}