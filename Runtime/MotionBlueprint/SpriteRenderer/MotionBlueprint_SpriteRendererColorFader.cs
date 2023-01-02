using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace PhEngine.Motion
{
    [CreateAssetMenu(menuName = "PhEngine/Motion/MotionBlueprint/Tween/SpriteRenderer/ColorFader" , fileName = "MotionBlueprint_SpriteRendererColorFader")]
    public class MotionBlueprint_SpriteRendererColorFader : MotionBlueprint_ColorFader<SpriteRenderer>
    {
        protected override void SetColor(SpriteRenderer component, Color color)
        {
            component.color = color;
        }

        protected override Tweener CreateFaderTweener(SpriteRenderer spriteRenderer, Color targetColor, float duration)
        {
            return spriteRenderer.DOColor(targetColor, duration);
        }
    }
}