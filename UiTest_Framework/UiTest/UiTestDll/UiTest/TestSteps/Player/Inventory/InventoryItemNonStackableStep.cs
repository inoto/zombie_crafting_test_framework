using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context.Consts;
using UiTest.UiTest.Checker;

namespace Assets.UiTest.TestSteps
{
	public class InventoryItemNonStackableStep : UiTestStepBase
	{
		public override string Id => "inventory_item_non_stackable";
		protected override IEnumerator OnRun()
		{
			int itemStackSize = 1;

			Cheats.GetAxe(1);
			Cheats.GetAxe(1);

			var cell = Context.FindCellInInventoriesBySpriteName("tool_hatchet_iron",
				new HashSet<string>() {Screens.Inventory.Content.InventoryCount.Item});
			int index = Context.GetCellIndex(cell);
			var currentStackSize = Cheats.CellCount(cell);
			
			if (new CellCountChecker(Context, Screens.Inventory.Cell.Pockets, index, itemStackSize).Check() == false)
			{
				Fail($"Максимальный размер стака предмета в ячейке {index} не совпадает. " +
				     $"Текущее размер: {currentStackSize}, ожидаемый размер: {itemStackSize}");
			}
			var checker = new CellCountChecker(Context, Screens.Inventory.Cell.Pockets, index + 1, itemStackSize);
			if (checker.Check() == false)
			{
				Fail($"Неправильный размер стака предмета в ячейке {index+1}. " +
				     $"Текущее размер: {checker.GetCellCount()}, ожидаемый размер: {itemStackSize}");
			}
			yield break;
		}
	}
}