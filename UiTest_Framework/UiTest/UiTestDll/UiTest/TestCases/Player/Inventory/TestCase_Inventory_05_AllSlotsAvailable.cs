using System.Collections.Generic;
using Assets.UiTest.TestSteps;

namespace Assets.UiTest.Runner
{
	public class TestCase_Inventory_05_AllSlotsAvailable : UiStepsTestCase
	{
		protected override IEnumerator<IUiTestStepBase> Condition()
		{
			yield return Steps.WaitGameLoadedStep();
			yield return Steps.InventoryResetStep();
			yield return Steps.InventoryOpenStep();
			yield return new InventoryUseAllSlotsStep();
			yield return Steps.InventoryCloseStep();
		}
	}
}