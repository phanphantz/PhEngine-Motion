using TMPro;
using UnityEngine;

namespace PhEngine.Motion
{
    [CreateAssetMenu(menuName = "PhEngine/Motion/MotionBlueprint/Tween/TMP_Text/TextTyper" , fileName = "MotionBlueprint_TMP_TextTyper")]
    public class MotionBlueprint_TMP_TextTyper : MotionBlueprint_TextTyper<TMP_Text>
    {
        protected override void AppendCharacter(TMP_Text component, char character)
        {
            component.text += character;
        }

        protected override void SetText(TMP_Text component, string text)
        {
            component.text = text;
        }
    }
}