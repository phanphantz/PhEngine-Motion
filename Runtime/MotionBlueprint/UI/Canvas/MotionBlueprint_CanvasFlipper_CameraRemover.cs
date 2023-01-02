using System.Linq;
using UnityEngine;

namespace PhEngine.Motion
{
    public class MotionBlueprint_CanvasFlipper_CameraRemover : MonoBehaviour
    {
        public Canvas AssignedCanvas { get; private set; }   
        
        public void SetCanvas(Canvas canvas)
        {
            AssignedCanvas = canvas;
        }

        public void SelfDestruct()
        {
            Destroy(gameObject);
        }
        
    }
}