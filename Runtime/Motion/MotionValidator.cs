using PhEngine.Core;

namespace PhEngine.Motion
{
    internal static class MotionValidator
    {
        internal static bool Validate(Motion motion)
        {
            if (motion.concept.blueprint == null)
            {
                PhDebug.LogError<Motion>(MotionLogMessage.ERROR_NULL_MOTION_CONFIG);
                return false;
            }

            if (motion.targetGameObject == null)
            {
                PhDebug.LogError<Motion>(MotionLogMessage.ERROR_NULL_TARGET);
                return false;
            }

            return true;
        }
    }
}