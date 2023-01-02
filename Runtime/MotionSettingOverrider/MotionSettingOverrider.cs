using System;
using UnityEngine;

namespace PhEngine.Motion
{
    public abstract class MotionSettingOverrider: MonoBehaviour
    {
        internal abstract MotionSetting GetOverridenSetting();
    }
}