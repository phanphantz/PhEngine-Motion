using System.Linq;
using DG.Tweening;
using UnityEngine;

namespace PhEngine.Motion
{
    [CreateAssetMenu(menuName = "PhEngine/Motion/MotionBlueprint/Tween/CanvasFlipper",
        fileName = "MotionBlueprint_CanvasFlipper")]
    public class MotionBlueprint_CanvasFlipper : MotionBlueprint_Tweener<Canvas, MotionSetting_CanvasFlipper>
    {
        protected override Tweener CreateTweener(Canvas component, MotionSetting_CanvasFlipper setting)
        {
            component.renderMode = RenderMode.WorldSpace;
            CreateAndPrepareCameraForPerspectiveFlipping();
            
            if (setting.isSetEulerAngleOnStart)
                component.transform.eulerAngles = setting.startEulerAngle;

            return component.transform.DORotate(setting.targetEulerAngle, setting.duration);
            
            void CreateAndPrepareCameraForPerspectiveFlipping()
            {
                var camera = CreateAndPrepareCameraForCanvasFlipper();
                ScheduleRemoveCameraAfterFinishPlaying();
                SendAllOtherLowerOverlayCanvasesToBackThenRestoreAfterFinishPlaying(camera);

                Camera CreateAndPrepareCameraForCanvasFlipper()
                {
                    var obj = new GameObject();
                    obj.name = "CanvasFlipper_Camera_For_" + component.name;
                    var camera = obj.AddComponent<Camera>();
                    PrepareCamera();
                    return camera;
                    
                    void PrepareCamera()
                    {
                        camera.orthographic = false;
                        camera.clearFlags = CameraClearFlags.Depth;
                        camera.farClipPlane = setting.farClipPlane;

                        SortCameraToTopMostDepth();
                        CorrectCameraPositionAndFieldOfView();
                        
                        void SortCameraToTopMostDepth()
                        {
                            var cameras = Camera.allCameras;
                            var highestSortOrder = cameras.Select(cam => cam.depth).Prepend(float.MinValue).Max();
                            camera.depth = highestSortOrder + 1;
                        }

                        void CorrectCameraPositionAndFieldOfView()
                        {
                            //Move camera to the back of the canvas
                            var cameraPosZOffset = setting.farClipPlane / 2f;
                            camera.transform.position = component.transform.position + new Vector3(0, 0, -cameraPosZOffset);

                            //Determine the field of view
                            var halfScreenHeight = Screen.height / 2f;
                            var halfFieldOfView = Mathf.Atan2(halfScreenHeight, cameraPosZOffset) * Mathf.Rad2Deg;
                            var fieldOfView = halfFieldOfView * 2f;
                            camera.fieldOfView = fieldOfView;
                        }
                    }
                }
                
                void ScheduleRemoveCameraAfterFinishPlaying()
                {
                    var cameraHolder = camera.gameObject.AddComponent<MotionBlueprint_CanvasFlipper_CameraRemover>();
                    cameraHolder.SetCanvas(component);
                }
            }
            
            void SendAllOtherLowerOverlayCanvasesToBackThenRestoreAfterFinishPlaying(Camera camera)
            {
                var overlayCanvasesWithLowerOrEqualSortOrder = FindObjectsOfType<Canvas>().Where
                    (c =>
                        c.renderMode == RenderMode.ScreenSpaceOverlay && 
                        c.sortingOrder <= component.sortingOrder && 
                        c != component
                        )
                    .ToArray();
                
                ScheduleCanvasesRestoreAfterFinishPlaying(overlayCanvasesWithLowerOrEqualSortOrder);
                SendOverlayCanvasesToBack();
                
                void ScheduleCanvasesRestoreAfterFinishPlaying(Canvas[] canvases)
                {
                    var memorizer = camera.gameObject.AddComponent<MotionBlueprint_CanvasFlipper_CanvasRenderModeMemorizer>();
                    memorizer.Memorize(canvases);
                }
                
                void SendOverlayCanvasesToBack()
                {
                    foreach (var canvas in overlayCanvasesWithLowerOrEqualSortOrder)
                    {
                        canvas.worldCamera = Camera.main;
                        canvas.renderMode = RenderMode.ScreenSpaceCamera;
                    }
                }
            }

            
        }
        

        protected override void HandleOnComplete(Canvas component, MotionSetting_CanvasFlipper setting)
        {
            component.renderMode = RenderMode.ScreenSpaceCamera;
            var cameraHolders = FindObjectsOfType<MotionBlueprint_CanvasFlipper_CameraRemover>();
            var targetHolder = cameraHolders.FirstOrDefault(holder => holder.AssignedCanvas == component);
            if (targetHolder == null)
                return;
            
            targetHolder.SelfDestruct();
            targetHolder.GetComponent<MotionBlueprint_CanvasFlipper_CanvasRenderModeMemorizer>().Restore();
        }
    }
}