using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;
using UiTest.UiTest.Checker;

namespace Assets.UiTest.TestSteps.Trees
{
	public class Trees_FullyHarvestTreeStep : UiTestStepBase
	{
		public override string Id => "trees_fully_harvest_tree";

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
			
			if (new TreeFelledChecker(Context, trees[treeIndex]).Check() == false)
			{
				Fail($"Дерево ещё стоит, хотя должно быть срублено.");
			}
		}
	}
}