using System.Collections;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;
using UiTest.UiTest.Checker;

namespace Assets.UiTest.TestSteps
{
	public class WorkbenchSawmill_RemoveRowDuringProgressStep : UiTestStepBase
	{
		public override string Id => "workbench_sawmill_remove_row_during_progress";
		protected override IEnumerator OnRun()
		{
			for (int i = 0; i < 20; i++)
			{
				yield return Context.WaitEndFrame;
			}
			
			yield return Commands.DragAndDropCommand(Screens.Inventory.Cell.WorkbenchRow, 0,
				Screens.Inventory.Cell.Pockets, 4, new ResultData<SimpleCommandResult>());
			
			if (Context.ProgressBarAmount() > 0f)
			{
				Fail($"Прогресс продолжается, хотя должен отмениться.");
			}
		}
	}
}