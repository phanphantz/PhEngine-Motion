using PhEngine.Core;
using UnityEngine;

namespace PhEngine.Motion
{
    [RequireComponent(typeof(TransitionPlayer))]
    public abstract class TransitionSwitch : Switch
    {
        public bool IsPlaying => IsPlayingOffTransition || IsPlayingOnTransition;
        protected bool IsPlayingOnTransition => TransitionPlayer != null && TransitionPlayer.IsPlayingTransition(SwitchOnTransition);
        protected bool IsPlayingOffTransition => TransitionPlayer != null && TransitionPlayer.IsPlayingTransition(SwitchOffTransition);

        protected override SwitchingPerformer Performer => TransitionPlayer;

        public TransitionPlayer TransitionPlayer
        {
            get
            {
                if (transitionPlayer == null)
                    transitionPlayer = GetComponent<TransitionPlayer>();

                return transitionPlayer;
            }
        }

        TransitionPlayer transitionPlayer;

        public bool IsInBetweenTransition => IsTransitionPlayerExists && TransitionPlayer.IsStarted;
        bool IsTransitionPlayerExists => TransitionPlayer != null;

        protected override SwitchOption OnOption => SwitchOnTransition;
        protected abstract Transition SwitchOnTransition { get; }

        protected override SwitchOption OffOption => SwitchOffTransition;
        protected abstract Transition SwitchOffTransition { get; }

        protected override void ForceSwitchOff()
        {
            if (TransitionPlayer)
                TransitionPlayer.currentTransition = SwitchOffTransition;

            if (IsCanPlayOffTransition())
                base.ForceSwitchOff();
            else
                HandlePlaySwitchOffTransitionFail();
        }

        public bool IsCanPlayOffTransition()
        {
            return IsTransitionPlayerExists && Transition.IsCanPlay(SwitchOffTransition);
        }

        protected virtual void HandlePlaySwitchOffTransitionFail()
        {
            if (TransitionPlayer)
                TransitionPlayer.CallAllAssignedActionsOnCurrentTransition();
        }

        protected override void ForceSwitchOn()
        {
            if (TransitionPlayer)
                TransitionPlayer.currentTransition = SwitchOnTransition;

            if (IsCanPlayOnTransition())
                base.ForceSwitchOn();
            else
                HandlePlaySwitchOnTransitionFail();
        }

        public bool IsCanPlayOnTransition()
        {
            return IsTransitionPlayerExists && Transition.IsCanPlay(SwitchOnTransition);
        }

        protected virtual void HandlePlaySwitchOnTransitionFail()
        {
            if (TransitionPlayer)
                TransitionPlayer.CallAllAssignedActionsOnCurrentTransition();
        }
    }
}