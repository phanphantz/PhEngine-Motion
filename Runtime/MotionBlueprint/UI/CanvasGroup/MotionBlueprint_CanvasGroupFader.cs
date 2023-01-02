using UnityEngine;
using DG.Tweening;

namespace PhEngine.Motion
{
    [CreateAssetMenu(menuName = "PhEngine/Motion/MotionBlueprint/Tween/CanvasGroupFader" , fileName = "MotionBlueprint_CanvasGroupFader")]
    public class MotionBlueprint_CanvasGroupFader : MotionBlueprint_Tweener<CanvasGroup, MotionSetting_CanvasGroupFader>
    {
        protected override Tweener CreateTweener(CanvasGroup canvasGroup, MotionSetting_CanvasGroupFader setting)
        {
            MakeSureCanvasGroupCanBeUsed(canvasGroup);
            SetStartValue(canvasGroup ,setting);
            return canvasGroup.DOFade(setting.targetAlpha, setting.duration);
        }
        
        static void MakeSureCanvasGroupCanBeUsed(CanvasGroup canvasGroup)
        {
            if (!canvasGroup.gameObject.activeSelf)
                canvasGroup.gameObject.SetActive(true);

            canvasGroup.enabled = true;
        }

        static void SetStartValue(CanvasGroup canvasGroup, MotionSetting_CanvasGroupFader setting)
        {
            canvasGroup.blocksRaycasts = setting.isBlockRaycastsOnStart;
            if (setting.isSetAlphaOnStart)
                canvasGroup.alpha = setting.startAlpha;
        }
        
        protected override void HandleOnComplete(CanvasGroup canvasGroup, MotionSetting_CanvasGroupFader setting)
        {
            SetFinishValue(canvasGroup , setting);
        }
        
        static void SetFinishValue(CanvasGroup canvasGroup, MotionSetting_CanvasGroupFader setting)
        {
            canvasGroup.blocksRaycasts = setting.isBlockRaycastsOnFinish;
            if (setting.isDeactivateGameObjectOnFinish)
                canvasGroup.gameObject.SetActive(false);
        }
        
    }

}