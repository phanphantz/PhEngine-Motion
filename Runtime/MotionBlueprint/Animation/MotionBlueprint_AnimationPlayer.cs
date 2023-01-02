using PhEngine.Core;
using UnityEngine;

namespace PhEngine.Motion
{
    [CreateAssetMenu(menuName = "PhEngine/Motion/MotionBlueprint/AnimationPlayer", fileName = "MotionBlueprint_AnimationPlayer")]
    public class MotionBlueprint_AnimationPlayer : MotionBlueprintGen<Animation, MotionSetting_AnimationPlayer>
    {
        protected override MotionSetting_AnimationPlayer DefaultSetting => defaultSetting;
        public MotionSetting_AnimationPlayer defaultSetting;
        
        protected override void PlayAndNotifyFinish(MotionCommand<Animation, MotionSetting_AnimationPlayer> motionCommand)
        {
            var clip = GetTargetClip(motionCommand.Component, motionCommand.Setting);
            if (clip == null)
            {
                PhDebug.LogError<MotionBlueprint_AnimationPlayer>(MotionLogMessage.NULL_CLIP);
                return;
            }

            PrepareNotifyFinishEvent(motionCommand.Player, motionCommand.Motion, clip);
            AddOnFinishListener(motionCommand.Component);
            Play(motionCommand.Component, clip);
        }
        
        static AnimationClip GetTargetClip(Animation animation, MotionSetting_AnimationPlayer setting)
        {
            return setting.preferredAnimationClip != null ? setting.preferredAnimationClip : animation.clip;
        }

        static void PrepareNotifyFinishEvent(TransitionPlayer player, Motion motion, AnimationClip clip)
        {
            var animationLength = clip.length;
            AnimationEvent onEndAnimationEvent = CreateNotifyFinishEvent(player, motion, animationLength);
            clip.AddEvent(onEndAnimationEvent);
        }
        
        static void AddOnFinishListener(Animation animation)
        {
            animation.gameObject.AddComponent<MotionBlueprint_AnimationPlayer_OnFinishListener>();
        }

        static void Play(Animation animation, AnimationClip clip)
        {
            animation.clip = clip;
            animation.Play();
        }
        
        static AnimationEvent CreateNotifyFinishEvent(TransitionPlayer player, Motion motion, float animationLength)
        {
            var onEndAnimationEvent = new AnimationEvent();
            onEndAnimationEvent.objectReferenceParameter = player;
            onEndAnimationEvent.intParameter = player.currentTransition.GetIndexOfMotion(motion);
            onEndAnimationEvent.time = animationLength;
            onEndAnimationEvent.functionName = nameof(MotionBlueprint_AnimationPlayer_OnFinishListener.NotifyFinish);
            return onEndAnimationEvent;
        }
        
        protected override void Pause(MotionCommand<Animation, MotionSetting_AnimationPlayer> motionCommand)
        {
            motionCommand.Component[motionCommand.Component.clip.name].speed = 0;
        }

        protected override void Resume(MotionCommand<Animation, MotionSetting_AnimationPlayer> motionCommand)
        {
            motionCommand.Component[motionCommand.Component.clip.name].speed = motionCommand.Setting.normalAnimationClipSpeed;
        }

        protected override void Kill(MotionCommand<Animation, MotionSetting_AnimationPlayer> motionCommand)
        {
            motionCommand.Component.Stop();
            Resume(motionCommand);
        }

        protected override void Complete(MotionCommand<Animation, MotionSetting_AnimationPlayer> motionCommand)
        {
            var clip = motionCommand.Component.clip;
            motionCommand.Component[clip.name].time = clip.length;
            Resume(motionCommand);
        }

    }
}