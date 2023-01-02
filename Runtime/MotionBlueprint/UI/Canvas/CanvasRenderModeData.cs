using System;
using UnityEngine;

namespace PhEngine.Motion
{
    [Serializable]
    public class CanvasRenderModeData
    {
        public Canvas Canvas { get; private set; }
        public RenderMode renderMode;
        public Camera worldCamera;

        public CanvasRenderModeData(Canvas canvas)
        {
            Canvas = canvas;
            renderMode = canvas.renderMode;
            worldCamera = canvas.worldCamera;
        }

        public void RestoreCanvas()
        {
            if (Canvas == null)
                return;

            Canvas.worldCamera = worldCamera;
            Canvas.renderMode = renderMode;
        }
    }
}