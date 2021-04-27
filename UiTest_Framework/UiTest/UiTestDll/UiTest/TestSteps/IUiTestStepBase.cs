using System.Collections;

namespace Assets.UiTest.TestSteps
{
    public interface IUiTestStepBase
    {
        TestStepState CurrentState { get; }
        void Run();
        void Stop();
        IEnumerator RunStep();
        string Id { get; }
        double TimeOut { get; }
    }
}