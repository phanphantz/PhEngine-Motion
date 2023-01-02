using UnityEngine;

namespace PhEngine.Motion
{

    public class MotionBlueprint_AnimationPlayer_OnFinishListener : MonoBehaviour
    {
        internal void NotifyFinish(AnimationEvent animationEvent)
        {
            var playerMonoBehaviour = (animationEvent.objectReferenceParameter as MonoBehaviour);
            var motionIndex = animationEvent.intParameter;
            if (playerMonoBehaviour != null)
            {
                var player = playerMonoBehaviour.GetComponent<TransitionPlayer>();
                if (player)
                    player.NotifyMotionFinish(motionIndex);
            }

            Destroy(this);
        }
    }
}