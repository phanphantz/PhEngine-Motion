using System;
using DG.Tweening;
using UnityEngine;

namespace PhEngine.Motion
{
    [Serializable]
    public abstract class MotionSetting_Animator : MotionSetting
    {
        public float normalAnimatorSpeed = 1f;
    }
}