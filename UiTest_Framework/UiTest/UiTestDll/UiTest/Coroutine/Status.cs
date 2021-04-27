namespace UiTest.UiTest.Coroutine
{
    public static class Status
    {
        public static IStatus Complete => _complete;

        public static IStatus Running => _running;

        public static IStatus Stop => _stop;

        private static readonly IStatus _complete;
        private static readonly IStatus _running;
        private static readonly IStatus _stop;

        static Status()
        {
            _complete = new CompleteStatus();
            _running = new RunningStatus();
            _stop = new StopStatus();
        }
    }
}