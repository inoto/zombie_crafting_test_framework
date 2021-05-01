using System.Collections;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;
using UiTest.UiTest.Checker;

namespace Assets.UiTest.TestSteps
{
	public class WorkbenchSawmill_ProgressStopStartWhenReplaceResultStep : UiTestStepBase
	{
		public override string Id => "workbench_sawmill_progress_stop_start_when_replace_result";
		protected override IEnumerator OnRun()
		{
			yield return Commands.DragAndDropCommand(Screens.Inventory.Cell.Pockets, 0,
				Screens.Inventory.Cell.WorkbenchResult, 0, new ResultData<SimpleCommandResult>());
			yield return Context.WaitEndFrame;
			
			if (Context.ProgressBarAmount() > 0f)
			{
				Fail($"Прогресс продолжается, хотя должен отмениться.");
			}
			
			if (new IconEmptyChecker(Context, Screens.Inventory.Cell.WorkbenchRow, 0).Check() == true)
			{
				Fail($"Row ячейка станка пустая, хотя не должна быть.");
			}
			
			yield return Commands.DragAndDropCommand(Screens.Inventory.Cell.WorkbenchResult, 0,
				Screens.Inventory.Cell.Pockets, 0, new ResultData<SimpleCommandResult>());
			yield return Context.WaitEndFrame;
			
			if (Context.ProgressBarAmount() == 0f)
			{
				Fail($"Прогресс не начался, хотя должен был начаться.");
			}
		}
	}
}