using DG.Tweening;
using UnityEngine;

namespace PhEngine.Motion
{
    public abstract class MotionBlueprint_ColorFader<T> : MotionBlueprint_Tweener<T, MotionSetting_ColorFader>
    {
        protected override Tweener CreateTweener(T colorFaderComponent, MotionSetting_ColorFader setting)
        {
            if (setting.isSetColorOnStart)
               SetColor(colorFaderComponent, setting.startColor);

            return CreateFaderTweener(colorFaderComponent,setting.targetColor, setting.duration);
        }

        protected abstract void SetColor(T component, Color color);

        protected abstract Tweener CreateFaderTweener(T component,Color targetColor, float duration);
    }
}