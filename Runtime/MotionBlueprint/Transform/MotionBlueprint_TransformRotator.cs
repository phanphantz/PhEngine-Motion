using DG.Tweening;
using UnityEngine;

namespace PhEngine.Motion
{
    public class MotionBlueprint_TransformRotator : MotionBlueprint_Rotator<Transform>
    {
        protected override void SetEulerAngle(Transform component, Vector3 eulerAngle)
        {
            component.eulerAngles = eulerAngle;
        }

        protected override Tweener CreateRotateTweener(Transform component, Vector3 targetEulerAngle, float duration)
        {
            return component.DORotate(targetEulerAngle, duration);
        }
        
    }
}