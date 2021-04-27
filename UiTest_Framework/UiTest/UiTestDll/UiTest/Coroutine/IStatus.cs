namespace UiTest.UiTest.Coroutine
{
    public interface IStatus
    {
        bool IsRunning { get; }
        bool IsComplete { get; }
        bool IsStop { get; }
    }
}