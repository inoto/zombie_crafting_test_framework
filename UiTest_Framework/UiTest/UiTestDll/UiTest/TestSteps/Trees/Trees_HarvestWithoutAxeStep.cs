using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;
using UiTest.UiTest.Checker;
using UnityEngine;

namespace Assets.UiTest.TestSteps.Trees
{
	public class Trees_HarvestWithoutAxeStep : UiTestStepBase
	{
		public override string Id => "trees_harvest_without_axe";

		protected override IEnumerator OnRun()
		{
			yield return RemoveAxesFromInventory();

			int treeIndex = 0;
			var trees = Cheats.FindTree();
			yield return Commands.PlayerMoveCommand(trees[treeIndex].transform.position, new ResultData<PlayerMoveResult>());
			yield return Commands.WaitForSecondsCommand(1, new ResultData<SimpleCommandResult>());
			
			for (int i = 0; i < 3; i++)
			{
				yield return Commands.UseButtonClickCommand(Screens.Main.Button.Use, new ResultData<SimpleCommandResult>());
				yield return Commands.WaitForSecondsCommand(1, new ResultData<SimpleCommandResult>());
			}
			yield return Commands.WaitForSecondsCommand(3, new ResultData<SimpleCommandResult>());
			
			if (new TreeFelledChecker(Context, trees[treeIndex]).Check() == true)
			{
				Fail($"Дерево срублено, хотя не должно быть.");
			}
			
			yield return Commands.UseButtonClickCommand(Screens.Main.Button.Inventory, new ResultData<SimpleCommandResult>());
			if (new TreeCountChecker(Context, 0).Check() == false)
			{
				Fail($"В инвентаре есть бревно, хотя не должно быть.");
			}
			yield return Commands.UseButtonClickCommand(Screens.Inventory.Button.Close, new ResultData<SimpleCommandResult>());
		}

		private IEnumerator RemoveAxesFromInventory()
		{
			yield return Commands.UseButtonClickCommand(Screens.Main.Button.Inventory, new ResultData<SimpleCommandResult>());
			for (int i = 0; i < 3; i++)
			{
				yield return Context.Commands.ClickCellCommand(Screens.Inventory.Cell.Pockets, i,
					new ResultData<SimpleCommandResult>());
				yield return Context.Commands.UseButtonClickCommand(Screens.Inventory.Button.Delete,
					new ResultData<SimpleCommandResult>());
			}
			yield return Commands.UseButtonClickCommand(Screens.Inventory.Button.Close, new ResultData<SimpleCommandResult>());
		}
	}
}