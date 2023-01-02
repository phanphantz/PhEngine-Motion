using System;
using UnityEngine;

namespace PhEngine.Motion
{
    [Serializable]
    public class SetIntCommand : AnimatorParameterCommand<int>
    {
        public override void Execute(Animator animator)
        {
            animator.SetInteger(parameterName, value);
        }
    }
}