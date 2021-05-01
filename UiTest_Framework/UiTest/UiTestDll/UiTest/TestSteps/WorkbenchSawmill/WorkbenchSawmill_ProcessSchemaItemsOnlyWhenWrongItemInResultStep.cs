using System.Collections;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;
using UiTest.UiTest.Checker;

namespace Assets.UiTest.TestSteps
{
	public class WorkbenchSawmill_ItemsProcessingWhenResultIsBusy : UiTestStepBase
	{
		public override string Id => "workbench_sawmill_items_processing_when_result_is_busy";
		protected override IEnumerator OnRun()
		{
			
			yield return Commands.DragAndDropCommand(Screens.Inventory.Cell.Pockets, 3,
				Screens.Inventory.Cell.WorkbenchResult, 0, new ResultData<SimpleCommandResult>());
			yield return Context.WaitEndFrame;
			
			Cheats.GetWood(1);
			yield return Commands.DragAndDropCommand(Screens.Inventory.Cell.Pockets, 3,
				Screens.Inventory.Cell.WorkbenchRow, 0, new ResultData<SimpleCommandResult>());
			yield return Context.WaitEndFrame;
			
			if (Context.ProgressBarAmount() != 0f)
			{
				Fail($"Прогресс идёт, но не должен был начаться.");
			}
		}
	}
}