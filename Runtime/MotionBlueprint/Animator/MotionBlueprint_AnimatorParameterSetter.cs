using UnityEngine;

namespace PhEngine.Motion
{
    [CreateAssetMenu(menuName = "PhEngine/Motion/MotionBlueprint/Animator/ParameterSetter", fileName = "MotionBlueprint_AnimatorParameterSetter")]
    public class MotionBlueprint_AnimatorParameterSetter : MotionBlueprint_Animator<MotionSetting_AnimatorParameterSetter>
    {
        protected override MotionSetting_AnimatorParameterSetter DefaultSetting => defaultSetting;
        public MotionSetting_AnimatorParameterSetter defaultSetting;

        protected override void PlayAndNotifyFinish(MotionCommand<Animator, MotionSetting_AnimatorParameterSetter> motionCommand)
        {
            ExecuteParameterManipulation(motionCommand.Component, motionCommand.Setting);
            HandleNotifyFinish();
            
            void HandleNotifyFinish()
            {
                motionCommand.Player.NotifyMotionFinishAfterSeconds(motionCommand.Setting.duration , motionCommand.Motion);
            }
        }

        static void ExecuteParameterManipulation(Animator animator, MotionSetting_AnimatorParameterSetter setting)
        {
            foreach (var command in setting.setBoolCommands)
                command.Execute(animator);

            foreach (var command in setting.setFloatCommands)
                command.Execute(animator);

            foreach (var command in setting.setIntCommands)
                command.Execute(animator);

            foreach (var command in setting.setTriggerCommands)
                animator.SetTrigger(command);

            foreach (var command in setting.resetTriggerCommands)
                animator.ResetTrigger(command);
        }
        
    }

}