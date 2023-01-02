using System;
using PhEngine.Core;

namespace PhEngine.Motion
{
    [Serializable]
    public class Transition : SwitchOption
    {
        public Motion[] motions;

        public Transition(params Motion[] motions)
        {
            this.motions = motions;
        }
        
        public bool IsCanPlay() => motions != null && motions.Length != 0;
        public bool IsContainMotion(Motion setting)
        {
            return Array.Exists(motions, t => t == setting);
        }

        public int GetIndexOfMotion(Motion motion)
        {
            return Array.IndexOf(motions, motion);
        }

        public static bool IsCanPlay(Transition transition)
        {
            return transition != null && transition.IsCanPlay();
        }
        
    }

}