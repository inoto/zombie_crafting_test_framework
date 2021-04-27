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
				// если индекс не в списке, то удаляем предмет
				if (!initialInventory.ContainsKey(i))
				{
					yield return RemoveItem(i);
					continue;
				}
				cell = Context.FindInventoryCellByIndex(i, "inventory_count");
				// если в слоте нужная иконка предмета и иконка показывается - всё норм, оставляем
				if (Context.GetCellIconName(cell) == initialInventory[i] && !Cheats.IconIsEmpty(cell))
				{
					continue;
				}
				// удаляем предмет
				yield return RemoveItem(i);
				// добавляем нужный
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
			}
			yield return Commands.UseButtonClickCommand(Screens.Inventory.Button.Close, new ResultData<SimpleCommandResult>());
		}

		private IEnumerator RemoveItem(int index)
		{
			yield return Context.Commands.ClickCellCommand(Screens.Inventory.Cell.Pockets, index,
				new ResultData<SimpleCommandResult>());
			yield return Context.Commands.UseButtonClickCommand(Screens.Inventory.Button.Delete,
				new ResultData<SimpleCommandResult>());
		}
	}
}