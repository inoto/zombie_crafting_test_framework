using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;
using UiTest.UiTest.Checker;

namespace Assets.UiTest.TestSteps.Trees
{
	public class Trees_GetWoodAfterHarvestStep : UiTestStepBase
	{
		public override string Id => "trees_get_wood_after_harvest";

		protected override IEnumerator OnRun()
		{
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

			yield return Commands.UseButtonClickCommand(Screens.Main.Button.Inventory, new ResultData<SimpleCommandResult>());
			if (new TreeCountChecker(Context, 3).Check() == false)
			{
				Fail($"В инвентаре не хватает бревна, а должно быть 3шт.");
			}
			yield return Commands.UseButtonClickCommand(Screens.Inventory.Button.Close, new ResultData<SimpleCommandResult>());
		}
	}
}