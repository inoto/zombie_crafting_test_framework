using System.Collections;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;
using UiTest.UiTest.Checker;

namespace Assets.UiTest.TestSteps
{
	public class WorkbenchSawmill_ResultMaxStackStep : UiTestStepBase
	{
		public override string Id => "workbench_sawmill_result_max_stack";
		protected override IEnumerator OnRun()
		{
			int maxStackSize = 20;
			
			Cheats.GetWood(maxStackSize);
			Cheats.GetCoins(maxStackSize * 5);
			yield return Commands.DragAndDropCommand(Screens.Inventory.Cell.Pockets, 4,
				Screens.Inventory.Cell.WorkbenchRow, 0, new ResultData<SimpleCommandResult>());
			yield return Context.WaitEndFrame;
			for (int i = 0; i < maxStackSize; i++)
			{
				yield return Commands.UseButtonClickCommand(Screens.Inventory.Button.Skip,
					new ResultData<SimpleCommandResult>());
				yield return Context.WaitEndFrame;
			}
			
			Cheats.GetWood(1);
			yield return Commands.DragAndDropCommand(Screens.Inventory.Cell.Pockets, 4,
				Screens.Inventory.Cell.WorkbenchRow, 0, new ResultData<SimpleCommandResult>());
			yield return Context.WaitEndFrame;
			
			yield return Commands.UseButtonClickCommand(Screens.Inventory.Button.Skip,
				new ResultData<SimpleCommandResult>());
			yield return Context.WaitEndFrame;

			if (new IconEmptyChecker(Context, Screens.Inventory.Cell.WorkbenchRow, 0).Check() == true)
			{
				Fail($"Предмет не ходится в Row ячейке, хотя должен.");
			}
			
			if (Context.ProgressBarAmount() > 0f)
			{
				Fail($"Прогресс идёт, а не должен начаться.");
			}
		}
	}
}