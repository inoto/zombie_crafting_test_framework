namespace UiTest.UiTest.Coroutine
{
    public class CompleteStatus : IStatus
    {
        public bool IsRunning => false;
        public bool IsComplete => true;
        public bool IsStop  => false;

    }
}