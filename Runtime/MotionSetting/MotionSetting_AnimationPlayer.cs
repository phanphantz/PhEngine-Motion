using System;
using DG.Tweening;
using UnityEngine;

namespace PhEngine.Motion
{
    [Serializable]
    public class MotionSetting_AnimationPlayer : MotionSetting
    {
        public AnimationClip preferredAnimationClip;
        public float normalAnimationClipSpeed = 1f;
    }
}