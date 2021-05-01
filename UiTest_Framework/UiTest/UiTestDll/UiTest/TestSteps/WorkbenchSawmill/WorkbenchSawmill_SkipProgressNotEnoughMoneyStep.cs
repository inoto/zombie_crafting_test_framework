using System.Collections;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;

namespace Assets.UiTest.TestSteps
{
	public class WorkbenchSawmill_SkipProgressNotEnoughMoneyStep : UiTestStepBase
	{
		public override string Id => "workbench_sawmill_skip_progress_not_enough_money";
		protected override IEnumerator OnRun()
		{
			var cell = Context.Inventory.GetCells(Screens.Inventory.Cell.Pockets.Item).GetCell(3);
			int times = 0;
			while (Cheats.CellCount(cell) >= 5)
			{
				Cheats.GetWood(1);
				
				yield return Commands.DragAndDropCommand(Screens.Inventory.Cell.Pockets, 4,
					Screens.Inventory.Cell.WorkbenchRow, 0, new ResultData<SimpleCommandResult>());
				yield return Context.WaitEndFrame;
				
				yield return Commands.UseButtonClickCommand(Screens.Inventory.Button.Skip,
					new ResultData<SimpleCommandResult>());
				yield return Context.WaitEndFrame;
				
				times++;
			}
			
			Cheats.GetWood(1);
				
			yield return Commands.DragAndDropCommand(Screens.Inventory.Cell.Pockets, 4,
				Screens.Inventory.Cell.WorkbenchRow, 0, new ResultData<SimpleCommandResult>());
			yield return Context.WaitEndFrame;
			
			int initialMoneyAmount = Cheats.CellCount(cell);

			yield return Commands.UseButtonClickCommand(Screens.Inventory.Button.Skip,
				new ResultData<SimpleCommandResult>());

			int afterSkipMoneyAmount = Cheats.CellCount(cell);

			if (afterSkipMoneyAmount != initialMoneyAmount)
			{
				Fail($"Не верное кол-во монет. " +
				     $"Текущее кол-во: {afterSkipMoneyAmount}, ожидаемое кол-во: {initialMoneyAmount}");
			}
		}
	}
}