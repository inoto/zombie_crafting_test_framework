using System.Collections.Generic;
using Assets.UiTest.TestSteps;

namespace Assets.UiTest.Runner
{
	public class TestCase15_PlayerInventoryItemMaxStack : UiStepsTestCase
	{
		protected override IEnumerator<IUiTestStepBase> Condition()
		{
			yield return Steps.WaitGameLoadedStep();
			yield return Steps.InventoryResetStep();
			yield return Steps.InventoryOpenStep();
			yield return new InventoryItemMaxStackStep();
			yield return Steps.InventoryCloseStep();
		}
	}
}