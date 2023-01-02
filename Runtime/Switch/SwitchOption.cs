using System;

namespace PhEngine.Motion
{
    public abstract class SwitchOption
    {
        public Action onStart;
        public Action onFinish;
    }
}