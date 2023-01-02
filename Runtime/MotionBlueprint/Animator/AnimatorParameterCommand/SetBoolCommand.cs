using System;
using UnityEngine;

namespace PhEngine.Motion
{
    [Serializable]
    public class SetBoolCommand : AnimatorParameterCommand<bool>
    {
        public override void Execute(Animator animator)
        {
            animator.SetBool(parameterName, value);
        }
    }
}