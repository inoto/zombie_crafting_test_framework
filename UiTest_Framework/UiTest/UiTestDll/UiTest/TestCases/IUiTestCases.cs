using System.Collections.Generic;

namespace Assets.UiTest.Runner
{
    public interface IUiTestCases
    {
        IUiTestCase GetTestCase(int test);
    }
}