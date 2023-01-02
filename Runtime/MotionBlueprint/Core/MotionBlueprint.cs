using UnityEngine;

namespace PhEngine.Motion
{

    public abstract class MotionBlueprint : ScriptableObject
    {
        internal abstract void Play(MotionRequest request);
        internal abstract void Pause(MotionRequest request);
        internal abstract void Resume(MotionRequest request);
        internal abstract void Kill(MotionRequest request);
        internal abstract void Complete(MotionRequest request);
    }

}
