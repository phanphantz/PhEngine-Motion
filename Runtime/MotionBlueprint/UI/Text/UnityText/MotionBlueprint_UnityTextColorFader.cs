using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace PhEngine.Motion
{
    [CreateAssetMenu(menuName = "PhEngine/Motion/MotionBlueprint/Tween/Text/ColorFader" , fileName = "MotionBlueprint_UnityTextColorFader")]
    public class MotionBlueprint_UnityTextColorFader : MotionBlueprint_ColorFader<Text>
    {
        protected override void SetColor(Text component, Color color)
        {
            component.color = color;
        }

        protected override Tweener CreateFaderTweener(Text component,Color targetColor, float duration)
        {
            return component.DOColor(targetColor, duration);
        }
    }
}