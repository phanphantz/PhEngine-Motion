namespace PhEngine.Motion
{
    internal static class MotionRequester
    {
        internal static void RequestPlay(TransitionPlayer player, Motion motion)
        {
            if (!TryCreateMotionRequest(player, motion, out var motionRequest)) 
                return;
            
            motion.concept.blueprint.Play(motionRequest);
        }
        
        internal static void RequestPause(TransitionPlayer player, Motion motion)
        {
            if (!TryCreateMotionRequest(player, motion, out var motionRequest)) 
                return;
            
            motion.concept.blueprint.Pause(motionRequest);
        }

        internal static void RequestResume(TransitionPlayer player, Motion motion)
        {
            if (!TryCreateMotionRequest(player, motion, out var motionRequest)) 
                return;
            
            motion.concept.blueprint.Resume(motionRequest);
        }

        internal static void RequestComplete(TransitionPlayer player, Motion motion)
        {
            if (!TryCreateMotionRequest(player, motion, out var motionRequest)) 
                return;
            
            motion.concept.blueprint.Complete(motionRequest);
        }

        internal static void RequestKill(TransitionPlayer player, Motion motion)
        {
            if (!TryCreateMotionRequest(player, motion, out var motionRequest)) 
                return;
            
            motion.concept.blueprint.Kill(motionRequest);
        }
        
        static bool TryCreateMotionRequest(TransitionPlayer player, Motion motion, out MotionRequest motionRequest)
        {
            motionRequest = null;
            if (!MotionValidator.Validate(motion))
                return false;

            motionRequest = CreateMotionRequest(player, motion);
            return true;
        }
        
        static MotionRequest CreateMotionRequest(TransitionPlayer player, Motion motion)
        {
            MotionSetting overrideSetting = null;
            if (motion.concept.settingOverrider != null)
                overrideSetting = motion.concept.settingOverrider.GetOverridenSetting();
                
            return new MotionRequest(player, motion, overrideSetting);
        }
        
    }
}