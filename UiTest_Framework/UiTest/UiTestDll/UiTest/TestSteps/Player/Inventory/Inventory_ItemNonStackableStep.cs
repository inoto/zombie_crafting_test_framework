using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context.Consts;
using UiTest.UiTest.Checker;

namespace Assets.UiTest.TestSteps
{
	public class Inventory_ItemNonStackableStep : UiTestStepBase
	{
		public override string Id => "inventory_item_non_stackable";
		protected override IEnumerator OnRun()
		{
			int itemStackSize = 1;

			Cheats.GetAxe(1);

			int itemIndex = 0;

			var cell = Context.Inventory.GetCells(Screens.Inventory.Cell.Pockets.Item).GetCell(itemIndex);
			var currentStackSize = Cheats.CellCount(cell);
			
			if (new CellCountChecker(Context, Screens.Inventory.Cell.Pockets, itemIndex, itemStackSize).Check() == false)
			{
				Fail($"Максимальный размер стака предмета в ячейке {itemIndex} не совпадает. " +
				     $"Текущее размер: {currentStackSize}, ожидаемый размер: {itemStackSize}");
			}
			yield break;
		}
	}
}