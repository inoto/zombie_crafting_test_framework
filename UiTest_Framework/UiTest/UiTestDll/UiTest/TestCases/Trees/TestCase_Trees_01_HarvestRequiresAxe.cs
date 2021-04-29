using System.Collections.Generic;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;
using Assets.UiTest.TestSteps;
using Assets.UiTest.TestSteps.Trees;
using UnityEngine.Assertions;

namespace Assets.UiTest.Runner
{
	public class TestCase_Trees_01_HarvestRequiresAxe : UiStepsTestCase
	{
		protected override IEnumerator<IUiTestStepBase> Condition()
		{
			yield return Steps.WaitGameLoadedStep();
			yield return Steps.InventoryResetStep();
			yield return new TreesHarvestWithoutAxeStep();
		}
	}
}