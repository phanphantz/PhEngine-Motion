using DG.Tweening;
using UnityEngine;

namespace PhEngine.Motion
{
    public abstract class MotionBlueprint_Rotator<T> : MotionBlueprint_Tweener<T, MotionSetting_Rotator>
    {
        protected override Tweener CreateTweener(T component, MotionSetting_Rotator setting)
        {
            if (setting.isSetEulerAngleOnStart)
                SetEulerAngle(component, setting.startEulerAngle);

            return CreateRotateTweener(component,setting.targetEulerAngle, setting.duration);
        }

        protected abstract void SetEulerAngle(T component, Vector3 eulerAngle);

        protected abstract Tweener CreateRotateTweener(T component,Vector3 targetEulerAngle, float duration);
    }
}