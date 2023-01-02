using UnityEngine;

namespace PhEngine.Motion
{
    public abstract class AnimatorParameterCommand<T>
    {
        public string parameterName;
        public T value;
        public abstract void Execute(Animator animator);
    }
}