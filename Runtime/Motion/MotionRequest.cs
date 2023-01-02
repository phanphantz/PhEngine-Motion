namespace PhEngine.Motion
{

    public class MotionRequest
    {
        public TransitionPlayer Player { get; }
        public Motion Motion { get; }
        public MotionSetting OverrideSetting { get; }

        public MotionRequest (TransitionPlayer player, Motion motion, MotionSetting overrideSetting = null)
        {
            Player = player;
            Motion = motion;
            OverrideSetting = overrideSetting;
        }

        internal T GetTargetComponent<T>()
        {
            return Motion.targetGameObject.GetComponent<T>();
        }
        
    }

}
