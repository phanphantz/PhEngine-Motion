using UnityEngine;
using DG.Tweening;

namespace PhEngine.Motion
{
    public abstract class MotionBlueprint_Tweener<T, T1> : MotionBlueprintGen<T, T1> where T1 : MotionSetting_Tweener
    {
        protected override T1 DefaultSetting => defaultSetting;
        public T1 defaultSetting;
        
        protected override void Pause(MotionCommand<T, T1> motionCommand)
        {
            if (motionCommand.Component != null)
                DOTween.Pause(motionCommand.Component);
        }
        
        protected override void Resume(MotionCommand<T, T1> motionCommand) 
        {
            if (motionCommand.Component != null)
                DOTween.Play(motionCommand.Component);
        }

        protected override void Kill(MotionCommand<T, T1> motionCommand)
        {
            if (motionCommand.Component != null)
                DOTween.Kill(motionCommand.Component);
        }

        protected override void Complete(MotionCommand<T, T1> motionCommand)
        {
            if (motionCommand.Component != null)
                DOTween.Complete(motionCommand.Component);
        }

        protected override void PlayAndNotifyFinish(MotionCommand<T, T1> motionCommand)
        {
            if (motionCommand.Component == null)
                return;
                
            var tweener = CreateTweener(motionCommand.Component, motionCommand.Setting);
            ConfigureTweener(tweener, motionCommand);
        }

        protected abstract Tweener CreateTweener(T component, T1 setting);

        void ConfigureTweener(Tweener tweener, MotionCommand<T, T1> motionCommand)
        {
            tweener.SetDelay(motionCommand.Setting.delay);
            tweener.SetLoops(motionCommand.Setting.loops, motionCommand.Setting.loopType);
            tweener.SetEase(motionCommand.Setting.ease);
            if (motionCommand.Setting.isInverted)
                tweener.SetInverted();
            
            tweener.OnComplete
            (
                () =>
                {
                    HandleOnComplete(motionCommand.Component, motionCommand.Setting);
                    motionCommand.Player.NotifyMotionFinish(motionCommand.Motion);
                }
            );
        }

        protected virtual void HandleOnComplete(T component, T1 setting)
        {
        }
    }
}