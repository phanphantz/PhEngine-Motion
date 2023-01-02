using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace PhEngine.Motion
{
    public abstract class MotionBlueprint_TextTyper<T> : MotionBlueprint_Tweener<T, MotionSetting_TextTyper>
    {
        protected override Tweener CreateTweener(T component, MotionSetting_TextTyper setting)
        {
            if (string.IsNullOrEmpty(setting.targetText))
                return null;

            var currentText = string.Empty;
            if (setting.isSetTextOnStart)
            {
                SetText(component, setting.startText);
                currentText = setting.startText;
            }

            var currentIndex = 0;
            var characterCount = setting.targetText.Length;
            var targetDuration = GetTargetDuration();
        
            return DOTween.To(() => currentIndex, i => currentIndex = i, characterCount, targetDuration).OnUpdate
            (
                () =>
                {
                    if (currentText.Length -1 >= currentIndex) 
                        return;
                    
                    currentText += setting.targetText[currentIndex];
                    SetText(component, currentText);
                }
            ).SetTarget(component);

            float GetTargetDuration()
            {
                return setting.durationType == MotionSetting_TextTyper.DurationType.MaxTime
                    ? setting.duration
                    : setting.duration * characterCount;
            }

            float GetTimePerChar()
            {
                return setting.durationType == MotionSetting_TextTyper.DurationType.MaxTime
                    ? setting.duration / setting.targetText.Length
                    : setting.duration;
            }
        }

        protected override void HandleOnComplete(T component, MotionSetting_TextTyper setting)
        {
            base.HandleOnComplete(component, setting);
            SetText(component, setting.targetText);
        }

        protected abstract void AppendCharacter(T component, char character);
        protected abstract void SetText(T component, string text);
    }
}