using System.Collections;

namespace UiTest.UiTest.Coroutine
{
    public interface ITestScheduler
    {
        ITestRoutine StartCoroutine(IEnumerator routine);
        void Update();
        void Remove(ITestRoutine routine);
    }
}