
namespace UiTest.UiTest.Coroutine
{
    public class RunningStatus : IStatus
    {
        public bool IsRunning => true;
        public bool IsComplete => false;
        public bool IsStop  => false;
    }
}