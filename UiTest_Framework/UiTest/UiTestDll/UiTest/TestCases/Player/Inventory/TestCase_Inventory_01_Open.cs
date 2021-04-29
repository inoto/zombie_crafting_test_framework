using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context;
using Assets.UiTest.Results;
using Assets.UiTest.TestSteps;
using UiTest.UiTest.Checker;
using UnityEngine;

namespace Assets.UiTest.Runner
{
    public class TestCase_Inventory_01_Open : UiStepsTestCase
    {
        protected override IEnumerator<IUiTestStepBase> Condition()
        {
            yield return Steps.WaitGameLoadedStep();
            yield return Steps.InventoryOpenStep();
        }
    }
}