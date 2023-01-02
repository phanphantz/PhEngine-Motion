using UnityEngine;

namespace PhEngine.Motion
{
    public class MotionSettingOverriderGen<T> : MotionSettingOverrider where T : MotionSetting
    {
        public T setting;
        internal override MotionSetting GetOverridenSetting()
        {
            return setting;
        }
    }
}