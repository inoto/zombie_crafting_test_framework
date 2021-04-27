using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context;
using Assets.UiTest.Results;
using Assets.UiTest.TestSteps;
using UiTest.UiTest.Checker;
using UnityEngine;

namespace Assets.UiTest.Runner
{
    public class TestCase1_InventoryOpen : UiStepsTestCase
    {
        protected override IEnumerator<IUiTestStepBase> Condition()
        {
            yield return Steps.ExampleStep();
            yield return Steps.InventoryOpenStep();
            // yield return Steps.InventoryMoveItemStep();
            // List<IUiTestChecker> checker = new List<IUiTestChecker>();

            yield return Steps.FindItemStep();

            // yield return Steps.InventoryCloseStep();
            // yield return Steps.PlayerMoveSawmillStep();
        }
    }
}