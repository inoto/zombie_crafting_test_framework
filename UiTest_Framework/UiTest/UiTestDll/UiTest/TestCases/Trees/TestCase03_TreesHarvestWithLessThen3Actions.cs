using System.Collections.Generic;
using Assets.UiTest.TestSteps;
using Assets.UiTest.TestSteps.Trees;

namespace Assets.UiTest.Runner
{
	public class TestCase03_TreesHarvestWithLessThen3Actions : UiStepsTestCase
	{
		protected override IEnumerator<IUiTestStepBase> Condition()
		{
			yield return Steps.WaitGameLoadedStep();
			yield return Steps.InventoryResetStep();
			yield return new TreesHarvestTree1TimeStep();
			yield return new TreesHarvestTree1TimeStep();
		}
	}
}