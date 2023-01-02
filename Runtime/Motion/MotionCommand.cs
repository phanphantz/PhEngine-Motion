namespace PhEngine.Motion
{
    public class MotionCommand<T1, T2> where T2 : MotionSetting
    {
        public TransitionPlayer Player { get; }
        public Motion Motion { get; }
        public T1 Component { get; }
        public T2 Setting { get; }
        
        public MotionCommand(MotionRequest request, T2 defaultSetting)
        {
            Player = request.Player;
            Motion = request.Motion;
            Component = GetTargetComponent(request);
            Setting = GetActualSettingToUse(request, defaultSetting);
        }

        static T1 GetTargetComponent(MotionRequest request)
        {
            return request.GetTargetComponent<T1>();
        }

        static T2 GetActualSettingToUse(MotionRequest request, T2 defaultSetting)
        {
            if (!(request.OverrideSetting is T2 setting))
                setting = defaultSetting;
            
            return setting;
        }
        
    }
}