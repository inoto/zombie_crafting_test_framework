using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;
using UiTest.UiTest.Checker;

namespace Assets.UiTest.TestSteps
{
	public class InventoryItemStackingStep : UiTestStepBase
	{
		public override string Id => "inventory_item_stacking";
		protected override IEnumerator OnRun()
		{
			int stackSize = 2;
			for (int i = 0; i < stackSize; i++)
			{
				Cheats.GetWood(1);
			}

			var cell = Context.FindCellInInventoriesBySpriteName("res_wood_1",
				new HashSet<string>() {Screens.Inventory.Content.InventoryCount.Item});
			int index = Context.GetCellIndex(cell);
			var currentStackSize = Cheats.CellCount(cell);
			
			if (new CellCountChecker(Context, Screens.Inventory.Cell.Pockets, index, stackSize).Check() == false)
			{
				Fail($"Размер стака предмета в ячейке {index} не совпадает." +
				     $"Текущее размер: {currentStackSize}, ожидаемый размер: {stackSize}");
			}
			yield break;
		}
	}
}