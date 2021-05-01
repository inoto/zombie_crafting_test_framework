using System.Collections;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;

namespace Assets.UiTest.TestSteps
{
	public class WorkbenchSawmill_OpenStep : UiTestStepBase
	{
		public override string Id => "workbench_sawmill_open";
		protected override IEnumerator OnRun()
		{
			var result = new ResultData<SimpleCommandResult>();
			yield return Commands.UseButtonClickCommand(Screens.Main.Button.Use, result);
			if (!result.GetData().IsDone)
			{
				Fail($"Окно станка не открылось, хотя должно было.");
			}
		}
	}
}