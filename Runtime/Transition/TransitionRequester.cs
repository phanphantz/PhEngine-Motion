namespace PhEngine.Motion
{
    internal static class TransitionRequester
    {
        internal static void RequestPlay(TransitionPlayer player, Transition transition)
        {
            foreach (var motion in transition.motions)
                MotionRequester.RequestPlay(player, motion);
        }

        internal static void RequestPause(TransitionPlayer player, Transition transition)
        {
            foreach (var motion in transition.motions)
                MotionRequester.RequestPause(player, motion);
        }

        internal static void RequestResume(TransitionPlayer player, Transition transition)
        {
            foreach (var motion in transition.motions)
                MotionRequester.RequestResume(player, motion);
        }

        internal static void RequestKill(TransitionPlayer player, Transition transition)
        {   
            foreach (var motion in transition.motions)
                MotionRequester.RequestKill(player, motion);
        }

        internal static void RequestComplete(TransitionPlayer player, Transition transition)
        {
            foreach (var motion in transition.motions)
                MotionRequester.RequestComplete(player, motion);
        }
    }
}