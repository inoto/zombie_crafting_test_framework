using System.Collections.Generic;
using Assets.UiTest.TestSteps;

namespace Assets.UiTest.Runner
{
	public class TestCase_Inventory_06_ItemStacking : UiStepsTestCase
	{
		protected override IEnumerator<IUiTestStepBase> Condition()
		{
			yield return Steps.WaitGameLoadedStep();
			yield return Steps.InventoryOpenStep();
			yield return new Inventory_ItemStackingStep();
			yield return Steps.InventoryCloseStep();
		}
	}
}