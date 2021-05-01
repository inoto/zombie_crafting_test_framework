using System.Collections;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;

namespace Assets.UiTest.TestSteps
{
	public class WorkbenchSawmill_GetWoodAndPutToRowStep : UiTestStepBase
	{
		public override string Id => "workbench_sawmill_get_wood_and_put_to_row";
		protected override IEnumerator OnRun()
		{
			Cheats.GetWood(1);
			
			yield return Commands.DragAndDropCommand(Screens.Inventory.Cell.Pockets, 4,
				Screens.Inventory.Cell.WorkbenchRow, 0, new ResultData<SimpleCommandResult>());
			yield break;
		}
	}
}