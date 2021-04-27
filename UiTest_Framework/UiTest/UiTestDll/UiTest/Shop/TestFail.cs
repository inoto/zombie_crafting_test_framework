using System.Collections;
using Assets.UiTest.Context;
using Assets.UiTest.Results;

namespace UiTest.UiTest.Shop
{
    public static class TestFail
    {
        public static IEnumerator Run(IUiTestContext context)
        {
          yield return  context.Commands.WaitForSecondsCommand(1, new ResultData<SimpleCommandResult>());
        }
    }
}