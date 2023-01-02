using System;

namespace PhEngine.Motion
{
    [Serializable]
    public class MotionConcept
    {
        public MotionBlueprint blueprint;
        public MotionSettingOverrider settingOverrider;

        public MotionConcept(MotionBlueprint blueprint, MotionSettingOverrider settingOverrider)
        {
            this.blueprint = blueprint;
            this.settingOverrider = settingOverrider;
        }

    }
}
