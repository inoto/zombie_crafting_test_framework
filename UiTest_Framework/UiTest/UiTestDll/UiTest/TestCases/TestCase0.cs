using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context;
using Assets.UiTest.Results;
using Assets.UiTest.TestSteps;
using UnityEngine;

namespace Assets.UiTest.Runner
{
    public class TestCase0 : UiStepsTestCase
    {
        protected override IEnumerator<IUiTestStepBase> Condition()
        {
            yield return Steps.ExampleStep();
        }
    }
}