using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;
using UiTest.UiTest.Checker;

namespace Assets.UiTest.TestSteps.Trees
{
	public class TreesFullyHarvestTreeStep : UiTestStepBase
	{
		public override string Id => "trees_fully_harvest_tree";
		public override double TimeOut => 300;
		protected override Dictionary<string, string> GetArgs()
		{
			return new Dictionary<string, string>();
		}

		protected override IEnumerator OnRun()
		{
			int treeIndex = 0;
			var trees = Cheats.FindTree();
			
			var moveResult = new ResultData<PlayerMoveResult>();
			yield return Commands.PlayerMoveCommand(trees[treeIndex].transform.position, moveResult);
			var simpleResult = new ResultData<SimpleCommandResult>();
			yield return Commands.WaitForSecondsCommand(1, simpleResult);
			
			yield return Commands.UseButtonClickCommand(Screens.Main.Button.Use, new ResultData<SimpleCommandResult>());
			yield return Commands.WaitForSecondsCommand(1, new ResultData<SimpleCommandResult>());

			yield return Commands.WaitForSecondsCommand(3, new ResultData<SimpleCommandResult>());
			if (new TreeFelledChecker(Context, trees[treeIndex]).Check() == false)
			{
				yield return Commands.ScreenshotCommand(new ResultData<SimpleCommandResult>());
				Fail($"Дерево ещё стоит, хотя должно быть срублено.");
			}

			yield return Commands.UseButtonClickCommand(Screens.Main.Button.Inventory, new ResultData<SimpleCommandResult>());
			if (new TreeCountChecker(Context, 3).Check() == false)
			{
				Fail($"В инвентаре не хватает дерева, а должно быть 3шт.");
			}

			if (new UseTargetChecker(Context, trees[treeIndex].transform.position).Check() == true)
			{
				Fail($"Дерево ещё в таргете, хотя не должно быть.");
			}
			yield return Commands.ScreenshotCommand(new ResultData<SimpleCommandResult>());
			
			yield break;
		}
	}
}