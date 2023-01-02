using System;
using UnityEngine;

namespace PhEngine.Motion
{
    [Serializable]
    public class MotionSetting_CanvasGroupFader : MotionSetting_Tweener
    {
        [Header("Start")]
        public bool isSetAlphaOnStart = false;
        public float startAlpha = 0f;
        public bool isBlockRaycastsOnStart = false;

        [Header("Finish")]
        public float targetAlpha = 0f;
        public bool isBlockRaycastsOnFinish = false;
        public bool isDeactivateGameObjectOnFinish = false;
    }
}