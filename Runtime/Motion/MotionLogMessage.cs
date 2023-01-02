namespace PhEngine.Motion
{
    internal static class MotionLogMessage
    {
        internal const string ERROR_NULL_MOTION_CONFIG = "Cannot play motion. config is missing.";
        internal const string ERROR_NULL_TARGET = "Cannot play motion. Target GameObject is missing.";
        internal const string WARN_CANT_KILL_ANIMATOR = "Animator motion cannot be killed";
        internal const string NULL_CLIP = "Cannot play motion. AnimationClip is null.";
    }

}