using System.Collections;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;
using UiTest.UiTest.Checker;

namespace Assets.UiTest.TestSteps
{
	public class WorkbenchSawmill_ProcessSchemaItemsOnlyStep : UiTestStepBase
	{
		public override string Id => "workbench_sawmill_process_schema_items_only";
		protected override IEnumerator OnRun()
		{
			yield return Commands.DragAndDropCommand(Screens.Inventory.Cell.Pockets, 0,
				Screens.Inventory.Cell.WorkbenchRow, 0, new ResultData<SimpleCommandResult>());
			yield return Context.WaitEndFrame;
			
			if (new IconEmptyChecker(Context, Screens.Inventory.Cell.WorkbenchRow, 0).Check() == true)
			{
				Fail($"Row ячейка станка пустая, хотя не должна быть.");
			}
			
			if (Context.ProgressBarAmount() != 0f)
			{
				Fail($"Прогресс идёт, но не должен начаться.");
			}
		}
	}
}