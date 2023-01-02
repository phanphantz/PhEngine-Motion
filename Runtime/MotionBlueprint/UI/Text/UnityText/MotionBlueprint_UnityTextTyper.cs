using UnityEngine;
using UnityEngine.UI;

namespace PhEngine.Motion
{
    [CreateAssetMenu(menuName = "PhEngine/Motion/MotionBlueprint/Tween/Text/UnityTextTyper" , fileName = "MotionBlueprint_UnityTextTyper")]
    public class MotionBlueprint_UnityTextTyper : MotionBlueprint_TextTyper<Text>
    {
        protected override void AppendCharacter(Text component, char character)
        {
            component.text += character;
        }

        protected override void SetText(Text component, string text)
        {
            component.text = text;
        }
    }
}