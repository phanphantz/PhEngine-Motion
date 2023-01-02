using System;
using PhEngine.Core;
using UnityEngine;

namespace PhEngine.Motion
{
    public class VisualTransitionSwitch : TransitionSwitch
    {
        protected override Transition SwitchOnTransition => showTransition;
        protected override Transition SwitchOffTransition => hideTransition;
        
        public bool IsPlayingShowTransition => IsPlayingOnTransition;
        public bool IsPlayingHideTransition => IsPlayingOffTransition;

        [Header("Show/Hide Transitions")]
        public Transition showTransition = new Transition();
        public Transition hideTransition = new Transition();
        public bool IsVisible => IsOn;

        public Action OnStartShowing
        {
            get => OnStartSwitchingOn;
            set => OnStartSwitchingOn = value;
        }

        public Action OnFinishShowing
        {
            get => OnFinishSwitchingOn;
            set => OnFinishSwitchingOn = value;
        }

        public Action OnStartHiding
        {
            get => OnStartSwitchingOff;
            set => OnStartSwitchingOff = value;
        }

        public Action OnFinishHiding
        {
            get => OnFinishSwitchingOff;
            set => OnFinishSwitchingOff = value;
        }

        protected virtual void Awake()
        {
            SetIsOn(true);
        }

        public void Hide() => SwitchOff();
        public void ForceHide() => ForceSwitchOff();
        protected override void HandlePlaySwitchOffTransitionFail()
        {
            base.HandlePlaySwitchOffTransitionFail();
            gameObject.SetActive(false);
        }
        
        public void Show() => SwitchOn();
        public void ForceShow()
        {
            gameObject.SetActive(true);
            ForceSwitchOn();
        }
        
    }
}