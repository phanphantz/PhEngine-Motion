using System;

namespace PhEngine.Motion
{
    [Serializable]
    public class MotionSetting_CanvasFlipper : MotionSetting_Rotator
    {
        public float farClipPlane = 2000f;
    }
}