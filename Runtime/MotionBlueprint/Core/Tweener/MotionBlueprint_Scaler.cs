using DG.Tweening;
using UnityEngine;

namespace PhEngine.Motion
{
    public abstract class MotionBlueprint_Scaler<T> : MotionBlueprint_Tweener<T, MotionSetting_Scaler>
    {
        protected override Tweener CreateTweener(T component, MotionSetting_Scaler setting)
        {
            if (setting.isSetScaleOnStart)
                SetScale(component , setting.startScale);

            return CreateScaleTweener(component, setting.targetScale, setting.duration);
        }
        
        protected abstract void SetScale(T component, Vector3 scale);

        protected abstract Tweener CreateScaleTweener(T component,Vector3 targetScale, float duration);

    }

}