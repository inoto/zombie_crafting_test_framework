using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context.Consts;
using UiTest.UiTest.Checker;

namespace Assets.UiTest.TestSteps
{
	public class InventoryItemMaxStackStep : UiTestStepBase
	{
		public override string Id => "inventory_item_max_stack";
		protected override IEnumerator OnRun()
		{
			int maxStackSize = 20;
			int additionalStackSize = 1;

			Cheats.GetWood(maxStackSize);
			Cheats.GetWood(2);

			var cell = Context.FindCellInInventoriesBySpriteName("res_wood_1",
				new HashSet<string>() {Screens.Inventory.Content.InventoryCount.Item});
			int index = Context.GetCellIndex(cell);
			var currentStackSize = Cheats.CellCount(cell);
			
			if (new CellCountChecker(Context, Screens.Inventory.Cell.Pockets, index, maxStackSize).Check() == false)
			{
				Fail($"Максимальный размер стака предмета в ячейке {index} не совпадает. " +
				     $"Текущее размер: {currentStackSize}, ожидаемый размер: {maxStackSize}");
			}

			var checker = new CellCountChecker(Context, Screens.Inventory.Cell.Pockets, index + 1, additionalStackSize);
			if (checker.Check() == false)
			{
				Fail($"Неправильный размер стака предмета в ячейке {index+1}. " +
				     $"Текущее размер: {checker.GetCellCount()}, ожидаемый размер: {additionalStackSize}");
			}
			yield break;
		}
	}
}