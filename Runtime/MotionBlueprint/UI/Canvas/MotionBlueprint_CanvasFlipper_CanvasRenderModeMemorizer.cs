using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PhEngine.Motion
{
    public class MotionBlueprint_CanvasFlipper_CanvasRenderModeMemorizer : MonoBehaviour
    {
        [SerializeField] List<CanvasRenderModeData> canvasRenderModeDataList = new List<CanvasRenderModeData>();

        public void Memorize(params Canvas[] canvases)
        {
            canvasRenderModeDataList.Clear();
            foreach (var canvas in canvases)
                canvasRenderModeDataList.Add(new CanvasRenderModeData(canvas));
        }

        public void Restore()
        {
            foreach (var canvasData in canvasRenderModeDataList)
                canvasData.RestoreCanvas();
                    
            canvasRenderModeDataList.Clear();
        }

    }
}