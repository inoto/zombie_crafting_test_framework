using System.Collections.Generic;
using Assets.UiTest.TestSteps;

namespace Assets.UiTest.Runner
{
	public class TestCase_Inventory_04_MoveItem : UiStepsTestCase
	{
		protected override IEnumerator<IUiTestStepBase> Condition()
		{
			yield return Steps.WaitGameLoadedStep();
			yield return Steps.InventoryOpenStep();
			yield return new Inventory_MoveItemStep();
			yield return Steps.InventoryCloseStep();
		}
	}
}