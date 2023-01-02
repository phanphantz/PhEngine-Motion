using System;
using UnityEngine;

namespace PhEngine.Motion
{
    [Serializable]
    public class MotionSetting_AnimatorStatePlayer : MotionSetting_Animator
    {
        [Header("Target Animation State")]
        public int targetAnimationLayerIndex;
        public string targetAnimationStateName;
    }
}