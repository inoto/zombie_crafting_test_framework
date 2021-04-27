using System.Collections;
using Assets.UiTest.Results;

namespace Assets.UiTest.TestCommands
{
    public interface IUiTestCommand<T>:ITestCommand where T:ICommandResult
    {
        
        T GetResult();
    }

    public interface ITestCommand
    {
        IEnumerator Run();
    }
}