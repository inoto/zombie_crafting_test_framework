﻿namespace Assets.UiTest.Runner
{
    public interface IUiTestCases
    {
        IUiTestCase GetTestCase(int test);
        string GetTestCaseName(int number);
    }
}