namespace UiTest.UiTest.Coroutine
{
    public class StopStatus : IStatus
    {
        public bool IsRunning => false;
        public bool IsComplete => false;
        public bool IsStop  => true;

    }
}