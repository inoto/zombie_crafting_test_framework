using System.Collections;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;
using UiTest.UiTest.Checker;

namespace Assets.UiTest.TestSteps
{
	public class Inventory_RemoveItemStep : UiTestStepBase
	{
		public override string Id => "inventory_remove_item";
		protected override IEnumerator OnRun()
		{
			var cellIndex = 0;

			yield return RemoveItem(cellIndex);
			
			if (new IconEmptyChecker(Context, Screens.Inventory.Cell.Pockets, cellIndex).Check() == false)
			{
				yield return Commands.UseButtonClickCommand(Screens.Inventory.Button.Close, new ResultData<SimpleCommandResult>());
				Fail($"Не удалось удалить предмет в инвентаре на позиции {cellIndex}.");
			}
		}
		
		private IEnumerator RemoveItem(int index)
		{
			Context.SendDebugLog($"remove item index: {index}");
			yield return Context.Commands.ClickCellCommand(Screens.Inventory.Cell.Pockets, index,
				new ResultData<SimpleCommandResult>());
			yield return Context.Commands.UseButtonClickCommand(Screens.Inventory.Button.Delete,
				new ResultData<SimpleCommandResult>());
			yield return Context.WaitEndFrame;
		}
	}
}