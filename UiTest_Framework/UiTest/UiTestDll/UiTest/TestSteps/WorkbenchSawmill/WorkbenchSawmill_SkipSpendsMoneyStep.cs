using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;

namespace Assets.UiTest.TestSteps
{
	public class WorkbenchSawmill_SkipSpendsMoneyStep : UiTestStepBase
	{
		public override string Id => "workbench_sawmill_skip_spends_money";
		protected override IEnumerator OnRun()
		{
			int spendMoneyAmount = 5;
			
			var cell = Context.Inventory.GetCells(Screens.Inventory.Cell.Pockets.Item).GetCell(3);
			int initialMoneyAmount = Cheats.CellCount(cell);
			
			yield return Commands.UseButtonClickCommand(Screens.Inventory.Button.Skip,
				new ResultData<SimpleCommandResult>());
			
			yield return Context.WaitEndFrame;
			
			int afterSkipMoneyAmount = Cheats.CellCount(cell);

			if (afterSkipMoneyAmount != (initialMoneyAmount - spendMoneyAmount))
			{
				Fail($"Не верное кол-во монет потрачено. " +
				     $"Текущее кол-во: {afterSkipMoneyAmount}, ожидаемое кол-во: {initialMoneyAmount-spendMoneyAmount}");
			}
		}
	}
}