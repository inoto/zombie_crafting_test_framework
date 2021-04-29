using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;
using UiTest.UiTest.Checker;

namespace Assets.UiTest.TestSteps.Trees
{
	public class TreesGetWoodAfterHarvestStep : UiTestStepBase
	{
		public override string Id => "trees_get_wood_after_harvest";

		protected override IEnumerator OnRun()
		{
			int treeIndex = 4;
			var trees = Cheats.FindTree();
			
			var moveResult = new ResultData<PlayerMoveResult>();
			yield return Commands.PlayerMoveCommand(trees[treeIndex].transform.position, moveResult);
			var simpleResult = new ResultData<SimpleCommandResult>();
			yield return Commands.WaitForSecondsCommand(1, simpleResult);

			for (int i = 0; i < 3; i++)
			{
				yield return Commands.UseButtonClickCommand(Screens.Main.Button.Use, new ResultData<SimpleCommandResult>());
                yield return Commands.WaitForSecondsCommand(1, new ResultData<SimpleCommandResult>());
			}

			yield return Commands.UseButtonClickCommand(Screens.Main.Button.Inventory, new ResultData<SimpleCommandResult>());
			if (new TreeCountChecker(Context, 3).Check() == false)
			{
				yield return Commands.UseButtonClickCommand(Screens.Inventory.Button.Close, new ResultData<SimpleCommandResult>());
				Fail($"В инвентаре не хватает дерева, а должно быть 3шт.");
			}
			yield return Commands.UseButtonClickCommand(Screens.Inventory.Button.Close, new ResultData<SimpleCommandResult>());
		}
	}
}