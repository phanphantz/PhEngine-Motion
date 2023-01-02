using DG.Tweening;
using UnityEngine;

namespace PhEngine.Motion
{
    public abstract class MotionBlueprint_Mover<T> : MotionBlueprint_Tweener<T, MotionSetting_Mover>
    {
        protected override Tweener CreateTweener(T component, MotionSetting_Mover setting)
        {
            if (setting.isSetPositionOnStart)
                SetPosition(component , setting.startPosition);

            return CreateMoveTweener(component, setting.targetPosition, setting.duration);
        }
        
        protected abstract void SetPosition(T component, Vector3 position);

        protected abstract Tweener CreateMoveTweener(T component,Vector3 targetPosition, float duration);

    }

}