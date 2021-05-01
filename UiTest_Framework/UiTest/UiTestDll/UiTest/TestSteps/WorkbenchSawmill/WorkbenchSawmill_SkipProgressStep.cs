using System.Collections;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;
using UiTest.UiTest.Checker;

namespace Assets.UiTest.TestSteps
{
	public class WorkbenchSawmill_SkipProgressStep : UiTestStepBase
	{
		public override string Id => "workbench_sawmill_skip_progress";
		protected override IEnumerator OnRun()
		{
			yield return Commands.UseButtonClickCommand(Screens.Inventory.Button.Skip,
				new ResultData<SimpleCommandResult>());
			
			yield return Context.WaitEndFrame;
			yield return Context.WaitEndFrame;
			yield return Context.WaitEndFrame;

			if (new IconEmptyChecker(Context, Screens.Inventory.Cell.WorkbenchRow, 0).Check() == false)
			{
				Fail($"Row ячейка станка не пустая, хотя должна быть.");
			}
			
			yield return Context.WaitEndFrame;
			
			if (Context.ProgressBarAmount() != 0f)
			{
				Fail($"Прогресс идёт, а должен прекратится.");
			}
			
			yield return Context.WaitEndFrame;

			if (new IconEmptyChecker(Context, Screens.Inventory.Cell.WorkbenchResult, 0).Check() == true)
			{
				Fail($"Result ячейка станка пустая, хотя не должна быть.");
			}
		}
	}
}