using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;
using UnityEngine;

namespace Assets.UiTest.TestSteps
{
	public class InventoryResetStep : UiTestStepBase
	{
		public override string Id => "inventory_reset_step"; 

		protected override IEnumerator OnRun()
		{
			var initialInventory = new Dictionary<int, string>()
			{
				{0, "tool_hatchet_iron"},
				{1, "tool_hatchet_iron"},
				{2, "tool_hatchet_iron"},
				{3, "Icon_Coin"}
			};
			
			yield return Commands.UseButtonClickCommand(Screens.Main.Button.Inventory, new ResultData<SimpleCommandResult>());
			GameObject cell = null;
			for (int i = 0; i < 10; i++)
			{
				// Context.SendDebugLog($"слот {i}");

				cell = Context.FindInventoryCellByIndex(i, Screens.Inventory.Cell.Pockets);
				// если ячейка не прописана в списке
				if (!initialInventory.ContainsKey(i))
				{
					// то если там что-то есть - удаляем
					if (!Cheats.IconIsEmpty(cell))
					{
						// иконка не пустая, не в списке - удаляем
						// Context.SendDebugLog($"иконка: {Context.GetCellIconName(cell)}, не пустая - не в списке, удаляем!");
						yield return RemoveItem(i);
					}
					// иконка пустая, не в списке - ок
					// Context.SendDebugLog($"иконка: {Context.GetCellIconName(cell)}, пустая - ок, потому что не в списке!");
					continue;
				}

				if (!Cheats.IconIsEmpty(cell))
				{
					// иконка не пустая и совпадает со списком - всё ок
					if (Context.GetCellIconName(cell) == initialInventory[i])
					{
						// Context.SendDebugLog($"иконка: {Context.GetCellIconName(cell)}, не пустая - всё ок");
						continue;
					}

					// иконка не пустая, удаляем чтобы поставить нужную
					// Context.SendDebugLog(
						// $"иконка: {Context.GetCellIconName(cell)}, не пустая - удаляем чтобы дать нужный");
					yield return RemoveItem(i);
				}

				// Context.SendDebugLog($"иконка: {Context.GetCellIconName(cell)}, пустая - добавляем");
				// иконка пустая - добавляем
				switch (initialInventory[i])
				{
					case "tool_hatchet_iron":
						Cheats.GetAxe(1);
						break;
					case "Icon_Coin":
						Cheats.GetCoins(55);
						break;
					default:
						Cheats.GetWood(3);
						break;
				}

				yield return Commands.WaitForSecondsCommand(0.1f, new ResultData<SimpleCommandResult>());

			}
			yield return Commands.UseButtonClickCommand(Screens.Inventory.Button.Close, new ResultData<SimpleCommandResult>());
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