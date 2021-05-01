using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;
using UiTest.UiTest.Checker;
using UnityEngine;

namespace Assets.UiTest.TestSteps
{
	public class WorkbenchSawmill_ProcessItemStep : UiTestStepBase 
	{
		public override string Id => "workbench_sawmill_put_item_to_row";
		protected override IEnumerator OnRun()
		{
			Cheats.GetWood(1);
			
			yield return Commands.DragAndDropCommand(Screens.Inventory.Cell.Pockets, 4,
				Screens.Inventory.Cell.WorkbenchRow, 0, new ResultData<SimpleCommandResult>());
			
			if (new IconEmptyChecker(Context, Screens.Inventory.Cell.WorkbenchRow, 0).Check() == false)
			{
				Fail($"Row ячейка станка не пустая, хотя должна быть пустая.");
			}
			
			yield return Context.WaitEndFrame;
			
			if (Context.ProgressBarAmount() == 0f)
			{
				Fail($"Прогресс не идёт, а должен.");
			}

			yield return Commands.WaitWorkbenchSawmillProgressCompleteCommand(new ResultData<WaitItemResult>());
			
			if (new IconEmptyChecker(Context, Screens.Inventory.Cell.WorkbenchResult, 0).Check() == true)
			{
				Fail($"Result ячейка станка пустая, хотя не должна быть.");
			}
		}
	}
}