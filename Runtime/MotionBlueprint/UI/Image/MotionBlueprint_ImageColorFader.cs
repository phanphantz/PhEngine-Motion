using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace PhEngine.Motion
{
    [CreateAssetMenu(menuName = "PhEngine/Motion/MotionBlueprint/Tween/Image/ColorFader" , fileName = "MotionBlueprint_ImageColorFader")]
    public class MotionBlueprint_ImageColorFader : MotionBlueprint_ColorFader<Image>
    {
        protected override void SetColor(Image component, Color color)
        {
            component.color = color;
        }

        protected override Tweener CreateFaderTweener(Image component,Color targetColor, float duration)
        {
            return component.DOColor(targetColor, duration);
        }
        
    }
}