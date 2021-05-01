using System.Collections;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;

namespace Assets.UiTest.TestSteps
{
	public class WorkbenchSawmill_SkipResetsProgressStep : UiTestStepBase
	{
		public override string Id => "workbench_sawmill_skip_resets_progress";
		protected override IEnumerator OnRun()
		{
			yield return Commands.UseButtonClickCommand(Screens.Inventory.Button.Skip,
				new ResultData<SimpleCommandResult>());
			yield return Context.WaitEndFrame;
			
			if (Context.ProgressBarAmount() != 0f)
			{
				Fail($"Прогресс идёт, но не должен продолжаться.");
			}
		}
	}
}