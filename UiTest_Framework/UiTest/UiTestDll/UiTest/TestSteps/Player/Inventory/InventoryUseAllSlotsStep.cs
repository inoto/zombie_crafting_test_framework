using System;
using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;
using UnityEngine;

namespace Assets.UiTest.TestSteps
{
	public class InventoryUseAllSlotsStep : UiTestStepBase
	{
		public override string Id => "inventory_use_all_slots";
		protected override IEnumerator OnRun()
		{
			int currentIndex = 0;
			StringParam currentInventoryId = Screens.Inventory.Cell.Pockets;
			int nextIndex = currentIndex + 1;
			StringParam nextInventoryId = Screens.Inventory.Cell.Pockets;
			
			var itemCell = Context.FindInventoryCellByIndex(currentIndex, currentInventoryId);
			var itemIconName = Context.GetCellIconName(itemCell);
			
			List<int> failedSlots = new List<int>();
			for (int i = 0; i < 24; i++)
			{
				Context.SendDebugLog($"текущий слот {currentIndex} и инв: {currentInventoryId.Item}");
				Context.SendDebugLog($"след слот {nextIndex} и инв: {nextInventoryId.Item}");
				yield return Commands.DragAndDropCommand(currentInventoryId, currentIndex, nextInventoryId, nextIndex,
					new ResultData<SimpleCommandResult>());
				yield return Commands.WaitForSecondsCommand(0.1f, new ResultData<SimpleCommandResult>());

				var nextCell = Context.FindInventoryCellByIndex(nextIndex, nextInventoryId);
				var nextIconName = Context.GetCellIconName(nextCell);
				if (nextIconName == itemIconName && !Cheats.IconIsEmpty(nextCell))
				{}
				else
				{
					failedSlots.Add(nextIndex);
					if (nextIndex >= 10 && nextInventoryId == Screens.Inventory.Cell.Pockets)
					{
						nextInventoryId = Screens.Inventory.Cell.Backpack;
					}
				}

				currentIndex++;
				if (currentIndex >= 10 && currentInventoryId == Screens.Inventory.Cell.Pockets)
				{
					currentInventoryId = Screens.Inventory.Cell.Backpack;
				}
				nextIndex++;
				if (nextIndex >= 10 && nextInventoryId == Screens.Inventory.Cell.Pockets)
				{
					nextInventoryId = Screens.Inventory.Cell.Backpack;
				}
			}

			if (failedSlots.Count > 0)
			{
				string text = "[";
				for (int i = 0; i < failedSlots.Count; i++)
				{
					text += $"{i},";
				}
				text = text.Substring(0, text.Length - 2);
				text += "]";
				Fail($"Слоты {text} не работают как надо, не удалось поместить в них предмет.");
			}
		}
	}
}