using System;
using PhEngine.Core;
using UnityEngine;

namespace PhEngine.Motion
{
    public class SelectionTransitionSwitch : TransitionSwitch
    {
        protected override Transition SwitchOnTransition => selectTransition;
        protected override Transition SwitchOffTransition => deselectTransition;

        public bool IsPlayingSelectTransition => IsPlayingOnTransition;
        public bool IsPlayingDeselectTransition => IsPlayingOffTransition;
        
        [Header("Select/Deselect Transitions")]
        public Transition selectTransition = new Transition();
        public Transition deselectTransition = new Transition();
        public bool IsSelected => IsOn;

        public Action OnStartSelecting
        {
            get => OnStartSwitchingOn;
            set => OnStartSwitchingOn = value;
        }

        public Action OnFinishSelecting
        {
            get => OnFinishSwitchingOn;
            set => OnFinishSwitchingOn = value;
        }

        public Action OnStartDeselecting
        {
            get => OnStartSwitchingOff;
            set => OnStartSwitchingOff = value;
        }

        public Action OnFinishDeselecting
        {
            get => OnFinishSwitchingOff;
            set => OnFinishSwitchingOff = value;
        }

        public void Deselect() => SwitchOff();
        public void ForceDeselect() => ForceSwitchOff();
        public void Select() => SwitchOn();
        public void ForceSelect() => ForceSwitchOn();
        
        protected override void HandlePlaySwitchOnTransitionFail()
        {
            base.HandlePlaySwitchOnTransitionFail();
            SetIsOn(true);
        }
        
        protected override void HandlePlaySwitchOffTransitionFail()
        {
            base.HandlePlaySwitchOffTransitionFail();
            SetIsOn(false);
        }
        
    }
}