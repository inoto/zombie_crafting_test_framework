using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;
using UiTest.UiTest.Checker;
using UnityEngine;

namespace Assets.UiTest.TestSteps.Trees
{
	public class TreesHarvestWithoutAxeStep : UiTestStepBase
	{
		public override string Id => "trees_harvest_without_axe";
		public override double TimeOut => 300;
		protected override Dictionary<string, string> GetArgs()
		{
			return new Dictionary<string, string>();
		}

		protected override IEnumerator OnRun()
		{
			yield return Commands.UseButtonClickCommand(Screens.Main.Button.Inventory, new ResultData<SimpleCommandResult>());

			// Context.SendDebugLog($"RemoveAxesFromInventory before");
			yield return RemoveAxesFromInventory();
			// Context.SendDebugLog($"RemoveAxesFromInventory after");
			
			var trees = Cheats.FindTree();
			var moveResult = new ResultData<PlayerMoveResult>();
			yield return Commands.PlayerMoveCommand(trees[0].transform.position, moveResult);
			var simpleResult = new ResultData<SimpleCommandResult>();
			yield return Commands.WaitForSecondsCommand(1, simpleResult);
			for (int i = 0; i < 3; i++)
			{
				yield return Commands.UseButtonClickCommand(Screens.Main.Button.Use, new ResultData<SimpleCommandResult>());
				yield return Commands.WaitForSecondsCommand(1, new ResultData<SimpleCommandResult>());
			}
			
			yield return Commands.WaitForSecondsCommand(3, new ResultData<SimpleCommandResult>());
			if (new TreeFelledChecker(Context, trees[0]).Check() == true)
			{
				yield return Commands.ScreenshotCommand(new ResultData<SimpleCommandResult>());
				Fail($"Дерево срублено, хотя не должно быть.");
			}
			
			if (new TreeCountChecker(Context, 0).Check() == false)
			{
				Fail($"В инвентаре есть бревно, хотя не должно быть.");
			}
		}

		private IEnumerator RemoveAxesFromInventory()
		{
			GameObject cell = null;
			// удаляем все топоры из инвентаря
			// Context.SendDebugLog($"RemoveAxesFromInventory start");
			// bool active = true;
			for (int i = 0; i < 3; i++)
			{
				// yield return Commands.WaitForSecondsCommand(1, new ResultData<SimpleCommandResult>());
				cell = Context.FindCellInInventoriesBySpriteName("tool_hatchet_iron",
					new HashSet<string>() {"inventory_count", "backpack_count"});
				if (cell == null)
				{
					break;
				}
				Context.SendDebugLog($"cell: {cell}");

				int cellIndex = Context.GetCellIndex(cell);
				yield return Context.Commands.ClickCellCommand(Screens.Inventory.Cell.Pockets, cellIndex,
					new ResultData<SimpleCommandResult>());
				yield return Context.Commands.UseButtonClickCommand(Screens.Inventory.Button.Delete,
					new ResultData<SimpleCommandResult>());
				
			}
			// Context.SendDebugLog($"RemoveAxesFromInventory end");
		}
	}
}