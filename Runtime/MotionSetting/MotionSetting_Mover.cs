using System;
using UnityEngine;

namespace PhEngine.Motion
{
    [Serializable]
    public class MotionSetting_Mover : MotionSetting_Tweener
    {
        [Header("Start")]
        public bool isSetPositionOnStart = false;
        public Vector3 startPosition;

        [Header("Finish")]
        public Vector3 targetPosition;
    }
}