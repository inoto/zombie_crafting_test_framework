using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;
using UiTest.UiTest.Checker;

namespace Assets.UiTest.TestSteps
{
	public class Inventory_ItemStackingStep : UiTestStepBase
	{
		public override string Id => "inventory_item_stacking";
		protected override IEnumerator OnRun()
		{
			int expectedStackSize = 2;
			for (int i = 0; i < expectedStackSize; i++)
			{
				Cheats.GetWood(1);
			}

			int newItemIndex = 4;

			var cell = Context.Inventory.GetCells(Screens.Inventory.Cell.Pockets.Item).GetCell(newItemIndex);
			var currentStackSize = Cheats.CellCount(cell);
			
			if (new CellCountChecker(Context, Screens.Inventory.Cell.Pockets, newItemIndex, expectedStackSize).Check() == false)
			{
				Fail($"Размер стака предмета не совпадает. " +
				     $"Текущее размер: {currentStackSize}, ожидаемый размер: {expectedStackSize}");
			}
			yield break;
		}
	}
}