using System.Collections;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;

namespace Assets.UiTest.TestSteps
{
	public class InventoryRemoveItemStep : UiTestStepBase
	{
		public override string Id => "inventory_remove_item";
		protected override IEnumerator OnRun()
		{
			var cellIndex = 0;
			yield return Commands.UseButtonClickCommand(Screens.Main.Button.Inventory, new ResultData<SimpleCommandResult>());
			
			yield return RemoveItem(cellIndex);
			var cell = Context.FindInventoryCellByIndex(cellIndex, Screens.Inventory.Cell.Pockets);

			if (Cheats.IconIsEmpty(cell) == false)
			{
				yield return Commands.UseButtonClickCommand(Screens.Inventory.Button.Close, new ResultData<SimpleCommandResult>());
				Fail($"Не удалось удалить предмет {Context.GetCellIconName(cell)} в инвентаре на позиции {cellIndex}.");
			}
			yield return Commands.UseButtonClickCommand(Screens.Inventory.Button.Close, new ResultData<SimpleCommandResult>());
			yield return Commands.WaitForSecondsCommand(1f, new ResultData<SimpleCommandResult>());
		}
		
		private IEnumerator RemoveItem(int index)
		{
			Context.SendDebugLog($"remove item index: {index}");
			yield return Context.Commands.ClickCellCommand(Screens.Inventory.Cell.Pockets, index,
				new ResultData<SimpleCommandResult>());
			yield return Context.Commands.UseButtonClickCommand(Screens.Inventory.Button.Delete,
				new ResultData<SimpleCommandResult>());
		}
	}
}