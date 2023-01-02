using DG.Tweening;
using TMPro;
using UnityEngine;

namespace PhEngine.Motion
{
    [CreateAssetMenu(menuName = "PhEngine/Motion/MotionBlueprint/Tween/TMP_Text/ColorFader" , fileName = "MotionBlueprint_TMP_TextColorFader")]
    public class MotionBlueprint_TMP_TextColorFader : MotionBlueprint_ColorFader<TMP_Text>
    {
        protected override void SetColor(TMP_Text component, Color color)
        {
            component.color = color;
        }

        protected override Tweener CreateFaderTweener(TMP_Text component,Color targetColor, float duration)
        {
            return component.DOColor(targetColor, duration);
        }
        
    }
}