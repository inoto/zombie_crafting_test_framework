using System.Collections;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;

namespace Assets.UiTest.TestSteps
{
	public class WorkbenchSawmill_CloseStep : UiTestStepBase
	{
		public override string Id => "workbench_sawmill_close";
		protected override IEnumerator OnRun()
		{
			var result = new ResultData<SimpleCommandResult>();
			yield return Commands.UseButtonClickCommand(Screens.Inventory.Button.Close, result);
			if (!result.GetData().IsDone)
			{
				Fail($"Окно станка не закрылось, хотя должно было.");
			}
		}
	}
}