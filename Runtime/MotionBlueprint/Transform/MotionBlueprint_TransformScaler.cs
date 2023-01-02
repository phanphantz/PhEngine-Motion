using UnityEngine;
using DG.Tweening;

namespace PhEngine.Motion
{
    [CreateAssetMenu(menuName = "PhEngine/Motion/MotionBlueprint/Tween/Transform/Scaler" , fileName = "MotionBlueprint_TransformScaler")]
    public class MotionBlueprint_TransformScaler : MotionBlueprint_Scaler<Transform>
    {
        protected override void SetScale(Transform component, Vector3 scale)
        {
            component.localScale = scale;
        }

        protected override Tweener CreateScaleTweener(Transform component, Vector3 targetScale, float duration)
        {
            return component.DOScale(targetScale , duration);
        }

    }

}