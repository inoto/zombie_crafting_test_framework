using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context.Consts;
using UiTest.UiTest.Checker;

namespace Assets.UiTest.TestSteps
{
	public class Inventory_ItemMaxStackStep : UiTestStepBase
	{
		public override string Id => "inventory_item_max_stack";
		protected override IEnumerator OnRun()
		{
			int maxStackSize = 20;
			int additionalStackSize = 1;

			Cheats.GetWood(maxStackSize);
			Cheats.GetWood(2);

			int newItemIndexMax = 4;

			var cell = Context.Inventory.GetCells(Screens.Inventory.Cell.Pockets.Item).GetCell(newItemIndexMax);
			var currentStackSize = Cheats.CellCount(cell);
			
			if (new CellCountChecker(Context, Screens.Inventory.Cell.Pockets, newItemIndexMax, maxStackSize).Check() == false)
			{
				Fail($"Максимальный размер стака предмета в ячейке {newItemIndexMax} не совпадает. " +
				     $"Текущее размер: {currentStackSize}, ожидаемый размер: {maxStackSize}");
			}

			var checker = new CellCountChecker(Context, Screens.Inventory.Cell.Pockets, newItemIndexMax + 1, additionalStackSize);
			if (checker.Check() == false)
			{
				Fail($"Неправильный размер стака предмета в ячейке {newItemIndexMax + 1}. " +
				     $"Текущее размер: {checker.GetCellCount()}, ожидаемый размер: {additionalStackSize}");
			}
			yield break;
		}
	}
}