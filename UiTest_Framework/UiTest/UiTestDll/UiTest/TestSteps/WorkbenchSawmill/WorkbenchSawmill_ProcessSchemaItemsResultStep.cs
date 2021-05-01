using System.Collections;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;

namespace Assets.UiTest.TestSteps
{
	public class WorkbenchSawmill_ProcessSchemaItemsResultStep : UiTestStepBase
	{
		public override string Id => "workbench_sawmill_process_schema_Items_result";
		protected override IEnumerator OnRun()
		{
			string expectedIconName = "res_plank_1";
			
			yield return Commands.DragAndDropCommand(Screens.Inventory.Cell.Pockets, 3,
				Screens.Inventory.Cell.WorkbenchResult, 0, new ResultData<SimpleCommandResult>());

			yield return Commands.WaitWorkbenchSawmillProgressCompleteCommand(new ResultData<WaitItemResult>());

			var cell = Context.Inventory.GetCells(Screens.Inventory.Cell.WorkbenchResult.Item).GetCell(0);
			var actualIconName = Context.GetCellIconName(cell);
			if (actualIconName != expectedIconName)
			{
				Fail($"Не правильный предмет в Result у станка. " +
				     $"Текущий предмет: {actualIconName}, ожидаемый предмет: {expectedIconName}");
			}
		}
	}
}