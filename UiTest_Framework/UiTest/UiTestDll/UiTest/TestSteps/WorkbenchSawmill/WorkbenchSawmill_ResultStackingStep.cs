using System.Collections;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;
using UiTest.UiTest.Checker;

namespace Assets.UiTest.TestSteps
{
	public class WorkbenchSawmill_ResultStackingStep : UiTestStepBase
	{
		public override string Id => "workbench_sawmill_result_stacking";
		public override double TimeOut => 20;

		protected override IEnumerator OnRun()
		{
			int expectedStackSize = 2;
			yield return Commands.WaitWorkbenchSawmillProgressCompleteCommand(new ResultData<WaitItemResult>());
			yield return Context.WaitEndFrame;
			yield return Commands.WaitWorkbenchSawmillProgressCompleteCommand(new ResultData<WaitItemResult>());
			
			var checker = new CellCountChecker(Context, Screens.Inventory.Cell.WorkbenchResult, 0, expectedStackSize);
			if (checker.Check() == false)
			{
				Fail($"Размер стака ячейки Result не верный. " +
				     $"Текущий размер: {checker.GetCellCount()}, а должен быть: {expectedStackSize}");
			}
		}
	}
}