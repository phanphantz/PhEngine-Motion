using System;
using System.Collections;
using UnityEngine;
using PhEngine.Core;

namespace PhEngine.Motion
{

    [Serializable]
    public class TransitionPlayer : MonoBehaviour, SwitchingPerformer
    {
        public void Switch(SwitchOption option)=> Play(option as Transition);
        public Transition currentTransition;
        public bool isPlayOnAwake;

        public int FinishedMotionCount {get; private set;}
        public int TargetMotionCountToFinish {get; private set;}
        public bool IsStarted => TargetMotionCountToFinish != 0;
        public bool IsPlaying => IsTransitionOnGoing && !isPause;

        public bool IsPlayingTransition(Transition transition)
        {
            return currentTransition == transition && IsPlaying;
        }
        
        public bool IsFinished => !IsTransitionOnGoing && IsStarted && !isPause;
        
        bool IsTransitionOnGoing => FinishedMotionCount != TargetMotionCountToFinish;
        bool isPause;
        Action CurrentMotionOnFinish => currentTransition?.onFinish;
        Action CurrentTransitionOnStart => currentTransition?.onStart;

        void Awake() 
        {
            if (isPlayOnAwake)
                PlayCurrentTransition();
        }

        public void Play(Transition transition)
        {
            Kill();
            currentTransition = transition;
            PlayCurrentTransition();
        }
        
        public void PlayCurrentTransition()
        {
            CallOnStartPlaying();
            NotifyTransitionStart();
            TransitionRequester.RequestPlay(this, currentTransition);
        }

        void CallOnStartPlaying()
        {
            CurrentTransitionOnStart?.Invoke();
        }

        void NotifyTransitionStart()
        {
            FinishedMotionCount = 0;
            TargetMotionCountToFinish = currentTransition.motions.Length;
        }

        void NotifyTransitionEnd()
        {
            ResetTransitionProgress();
        }

        void ResetTransitionProgress()
        {
            TargetMotionCountToFinish = 0;
            FinishedMotionCount = 0;
        }

        public void NotifyMotionFinish(int motionIndex)
        {
            if (motionIndex <0 || motionIndex >= currentTransition.motions.Length)
                return;
            
            NotifyMotionFinish(currentTransition.motions[motionIndex]);
        }

        public void NotifyMotionFinish(Motion motion)
        {
            if (!IsStarted)
                return;

            if (!currentTransition.IsContainMotion(motion))
                return;

            FinishedMotionCount++;

            if (!IsFinished)
                return;

            CallOnFinishActionAndNotifyEnd();
        }

        void CallOnFinishActionAndNotifyEnd()
        {
            NotifyTransitionEnd();
            CallOnFinishPlaying();
        }

        void CallOnFinishPlaying()
        {
            CurrentMotionOnFinish?.Invoke();
        }

        public void CallAllAssignedActionsOnCurrentTransition()
        {
            CallOnStartPlaying();
            CallOnFinishPlaying();
        }

        internal void NotifyMotionFinishAfterSeconds(float delayInSec, Motion motion)
        {  
            StartCoroutine(CountdownRoutine());
            IEnumerator CountdownRoutine()
            {
                yield return new WaitForSeconds(delayInSec);
                NotifyMotionFinish(motion);
            }
        }

        public void Pause()
        {
            if (!IsStarted)
                return;

            isPause = true;
            TransitionRequester.RequestPause(this, currentTransition);
        }

        public void Resume()
        {
            if (!IsStarted)
                return;

            isPause = false;
            TransitionRequester.RequestResume(this, currentTransition);
        }

        public void Kill()
        {
            if (!IsStarted)
                return;

            ResetTransitionProgress();
            TransitionRequester.RequestKill(this, currentTransition);
        }

        public void Complete()
        {
            if (!IsStarted)
                return;

            CallOnFinishActionAndNotifyEnd();
            TransitionRequester.RequestComplete(this, currentTransition);
        }

        public void TogglePause()
        {
            if (IsPlaying)
                Pause();
            else
                Resume();
        }

        public static void PlayAll()
        {
            var players = GetAllTransitionPlayersInOpenedScenes();
            if (players == null)
                return;

            foreach(var player in players)
            {
                if (player)
                    player.PlayCurrentTransition();
            }
            
        }

        public static void PauseAll()
        {
            var players = GetAllTransitionPlayersInOpenedScenes();
            if (players == null)
                return;

            foreach(var player in players)
            {
                if (player)
                    player.Pause();
            }

        }

        public static void ResumeAll()
        {
            var players = GetAllTransitionPlayersInOpenedScenes();
            if (players == null)
                return;

            foreach(var player in players)
            {
                if (player)
                    player.Resume();
            }

        }

        public static void KillAll()
        {
            var players = GetAllTransitionPlayersInOpenedScenes();
            if (players == null)
                return;

            foreach(var player in players)
            {
                if (player)
                    player.Kill();
            }

        }

        public static void CompleteAll()
        {
            var players = GetAllTransitionPlayersInOpenedScenes();
            if (players == null)
                return;

            foreach(var player in players)
            {
                if (player)
                    player.Complete();
            }

        }

        public static TransitionPlayer[] GetAllTransitionPlayersInOpenedScenes()
        {
            return FindObjectsOfType<TransitionPlayer>();
        }
        
    }

}