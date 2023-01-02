using System.Collections;
using UnityEngine;

namespace PhEngine.Motion
{
    [CreateAssetMenu(menuName = "PhEngine/Motion/MotionBlueprint/Animator/StatePlayer",
        fileName = "MotionBlueprint_AnimatorStatePlayer")]
    public class MotionBlueprint_AnimatorStatePlayer : MotionBlueprint_Animator<MotionSetting_AnimatorStatePlayer>
    {
        protected override MotionSetting_AnimatorStatePlayer DefaultSetting => defaultSetting;
        public MotionSetting_AnimatorStatePlayer defaultSetting;

        protected override void PlayAndNotifyFinish(
            MotionCommand<Animator, MotionSetting_AnimatorStatePlayer> motionCommand)
        {
            PlayTargetAnimation(motionCommand.Component, motionCommand.Setting);
            WaitUntilFinishAndNotifyPlayer();

            void WaitUntilFinishAndNotifyPlayer()
            {
                motionCommand.Player.StartCoroutine(WaitUntilFinishRoutine());

                IEnumerator WaitUntilFinishRoutine()
                {
                    yield return new WaitUntil(IsFinished);
                    motionCommand.Player.NotifyMotionFinish(motionCommand.Motion);
                }
            }

            bool IsFinished()
            {
                var currentStateInfo = GetCurrentStateInfo(motionCommand.Component, motionCommand.Setting);
                return currentStateInfo.IsName(motionCommand.Setting.targetAnimationStateName) &&
                       currentStateInfo.normalizedTime >= 1f;
            }
        }

        static AnimatorStateInfo GetCurrentStateInfo(Animator animator, MotionSetting_AnimatorStatePlayer setting)
        {
            return animator.GetCurrentAnimatorStateInfo(setting.targetAnimationLayerIndex);
        }

        static void PlayTargetAnimation(Animator animator, MotionSetting_AnimatorStatePlayer setting)
        {
            animator.Play(setting.targetAnimationStateName, setting.targetAnimationLayerIndex);
        }

        protected override void Complete(MotionCommand<Animator, MotionSetting_AnimatorStatePlayer> motionCommand)
        {
            FastForwardAnimationToTheEnd(motionCommand);
            base.Complete(motionCommand);
        }

        static void FastForwardAnimationToTheEnd(
            MotionCommand<Animator, MotionSetting_AnimatorStatePlayer> motionCommand)
        {
            motionCommand.Component.Play
            (
                motionCommand.Setting.targetAnimationStateName,
                motionCommand.Setting.targetAnimationLayerIndex,
                1f
            );
        }
    }
}