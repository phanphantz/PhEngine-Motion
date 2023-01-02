using System;
using DG.Tweening;
using UnityEngine;

namespace PhEngine.Motion
{
    [Serializable]
    public abstract class MotionSetting_Tweener : MotionSetting
    {
        [Header("Tween Settings")]
        public float duration = 0.5f;
        public Ease ease;
        public float delay;
        public int loops;
        public LoopType loopType;
        public bool isInverted;
    }
}