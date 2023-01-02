using System;
using UnityEngine;

namespace PhEngine.Motion
{
    [Serializable]
    public class MotionSetting_TextTyper : MotionSetting_Tweener, MotionSettingWithDuration
    {
        public enum DurationType
        {
            TimePerCharacter, MaxTime
        }

        [Header("DurationType")]
        public DurationType durationType;
        
        [Header("Start")]
        public bool isSetTextOnStart = true;
        public string startText;
        
        [Header("Finish")]
        public string targetText;

        public float Duration =>
            durationType == DurationType.MaxTime
                ? duration
                : duration * targetText.Length;
    }
}