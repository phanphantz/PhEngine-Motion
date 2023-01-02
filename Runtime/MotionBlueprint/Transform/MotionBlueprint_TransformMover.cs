using UnityEngine;
using DG.Tweening;

namespace PhEngine.Motion
{
    [CreateAssetMenu(menuName = "PhEngine/Motion/MotionBlueprint/Tween/Transform/Mover" , fileName = "MotionBlueprint_TransformMover")]
    public class MotionBlueprint_TransformMover : MotionBlueprint_Mover<Transform>
    {
        protected override void SetPosition(Transform component, Vector3 position)
        {
            component.position = position;
        }

        protected override Tweener CreateMoveTweener(Transform component, Vector3 targetPosition, float duration)
        {
            return component.DOMove(targetPosition , duration);
        }
    }

}