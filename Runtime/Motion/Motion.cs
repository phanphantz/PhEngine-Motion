using System;
using UnityEngine;

namespace PhEngine.Motion
{
    [Serializable]
    public class Motion
    {
        public GameObject targetGameObject;
        public MotionConcept concept;
       
        public Motion(GameObject targetGameObject, MotionConcept concept)
        {
            this.targetGameObject = targetGameObject;
            this.concept = concept;
        }
        
    }

}