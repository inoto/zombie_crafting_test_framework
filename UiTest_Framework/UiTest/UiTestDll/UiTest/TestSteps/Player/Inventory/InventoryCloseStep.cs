using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;

namespace Assets.UiTest.TestSteps
{
	public class InventoryCloseStep : UiTestStepBase
	{
		public override string Id => "inventory_open";
		public override double TimeOut => 300;
		protected override Dictionary<string, string> GetArgs()
		{
			var args = new Dictionary<string, string>();
			return args;
		}

		protected override IEnumerator OnRun()
		{
			yield return Commands.UseButtonClickCommand(Screens.Inventory.Button.Close, new ResultData<SimpleCommandResult>());
		}
	}
}