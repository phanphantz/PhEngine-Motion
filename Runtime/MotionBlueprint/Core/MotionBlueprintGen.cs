namespace PhEngine.Motion
{
    public abstract class MotionBlueprintGen<T,T1> : MotionBlueprint where T1 : MotionSetting
    {
        protected abstract T1 DefaultSetting { get; }

        internal override void Play(MotionRequest request) => PlayAndNotifyFinish(CreateMotionCommand(request));
        protected abstract void PlayAndNotifyFinish(MotionCommand<T, T1> motionCommand);

        internal override void Pause(MotionRequest request) => Pause(CreateMotionCommand(request));
        protected abstract void Pause(MotionCommand<T, T1> motionCommand);

        internal override void Resume(MotionRequest request) => Resume(CreateMotionCommand(request));
        protected abstract void Resume(MotionCommand<T, T1> motionCommand);

        internal override void Kill(MotionRequest request) => Kill(CreateMotionCommand(request));
        protected abstract void Kill(MotionCommand<T, T1> motionCommand);

        internal override void Complete(MotionRequest request) => Complete(CreateMotionCommand(request));
        protected abstract void Complete(MotionCommand<T, T1> motionCommand);
        
        MotionCommand<T, T1> CreateMotionCommand(MotionRequest request)
        {
            return new MotionCommand<T, T1>(request, DefaultSetting);
        }

    }

}
