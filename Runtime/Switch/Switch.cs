using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PhEngine.Motion
{

    public abstract class Switch : MonoBehaviour
    {
        protected abstract SwitchingPerformer Performer { get; }
        protected abstract SwitchOption OnOption { get; }
        protected abstract SwitchOption OffOption { get; }
        protected bool IsOn { get; private set; }

        protected Action OnStartSwitchingOn
        {
            get => OnOption?.onStart;
            set
            {
                if (OnOption != null)
                    OnOption.onStart = value;
            }
        }

        protected Action OnFinishSwitchingOn
        {
            get => OnOption?.onFinish;
            set
            {
                if (OnOption != null)
                    OnOption.onFinish = value;
            }
        }

        protected Action OnStartSwitchingOff
        {
            get => OffOption?.onStart;
            set
            {
                if (OffOption != null)
                    OffOption.onStart = value;
            }
        }

        protected Action OnFinishSwitchingOff
        {
            get => OffOption?.onFinish;
            set
            {
                if (OffOption != null)
                    OffOption.onFinish = value;
            }
        }

        protected void SwitchOff()
        {
            if (IsOn)
                ForceSwitchOff();
        }

        protected virtual void ForceSwitchOff()
        {
            SetIsOn(false);
            PerformSwitching(OffOption);
        }

        protected void SwitchOn()
        {
            if (!IsOn)
                ForceSwitchOn();
        }

        protected virtual void ForceSwitchOn()
        {
            SetIsOn(true);
            PerformSwitching(OnOption);
        }

        protected void SetIsOn(bool isOn) => this.IsOn = isOn;
        void PerformSwitching(SwitchOption option) =>  Performer?.Switch(option);

    }

}