using System;
using UnityEngine;

namespace PhEngine.Motion
{
    [Serializable]
    public class SetFloatCommand : AnimatorParameterCommand<float>
    {
        public override void Execute(Animator animator)
        {
            animator.SetFloat(parameterName, value);
        }
    }
}