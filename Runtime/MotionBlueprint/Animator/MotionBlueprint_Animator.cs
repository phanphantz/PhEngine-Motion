using PhEngine.Core;
using UnityEngine;

namespace PhEngine.Motion
{
    public abstract class MotionBlueprint_Animator<T> : MotionBlueprintGen<Animator, T> where T : MotionSetting_Animator
    {
        protected override void Pause(MotionCommand<Animator,T> motionCommand)
        {
           motionCommand.Component.speed = 0;
        }

        protected override void Resume(MotionCommand<Animator,T> motionCommand)
        {
            motionCommand.Component.speed = motionCommand.Setting.normalAnimatorSpeed;
        }

        protected override void Kill(MotionCommand<Animator,T> motionCommand)
        {
            PhDebug.LogWarning<MotionBlueprint_Animator<T>>(MotionLogMessage.WARN_CANT_KILL_ANIMATOR);
            Resume(motionCommand);
        }

        protected override void Complete(MotionCommand<Animator,T> motionCommand)
        {
            Resume(motionCommand);
        }
        
    }

}