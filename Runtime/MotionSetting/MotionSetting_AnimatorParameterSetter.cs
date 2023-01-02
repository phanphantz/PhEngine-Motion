using System;
using UnityEngine;

namespace PhEngine.Motion
{
    [Serializable]
    public partial class MotionSetting_AnimatorParameterSetter : MotionSetting_Animator
    {
        [Header("Parameter Manipulation")]
        public float duration;
        public SetBoolCommand[] setBoolCommands;
        public SetFloatCommand[] setFloatCommands;
        public SetIntCommand[] setIntCommands;
        public string[] setTriggerCommands;
        public string[] resetTriggerCommands;
    }
}