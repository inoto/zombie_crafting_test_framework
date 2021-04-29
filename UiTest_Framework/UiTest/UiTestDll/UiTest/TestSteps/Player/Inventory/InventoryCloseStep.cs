using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;

namespace Assets.UiTest.TestSteps
{
	public class InventoryCloseStep : UiTestStepBase
	{
		public override string Id => "inventory_close";

		protected override IEnumerator OnRun()
		{
			var result = new ResultData<SimpleCommandResult>();
			yield return Commands.UseButtonClickCommand(Screens.Inventory.Button.Close, result);
			if (!result.GetData().IsDone)
			{
				Fail($"Инвентарь не закрылся, хотя должен был.");
			}
		}
	}
}