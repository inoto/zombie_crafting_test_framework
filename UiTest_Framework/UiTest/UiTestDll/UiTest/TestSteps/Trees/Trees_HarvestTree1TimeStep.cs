using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;
using UiTest.UiTest.Checker;
using UnityEngine.Assertions;

namespace Assets.UiTest.TestSteps.Trees
{
	public class Trees_HarvestTree1TimeStep : UiTestStepBase
	{
		public override string Id => "trees_harvest_tree_1_time";

		protected override IEnumerator OnRun()
		{
			int treeIndex = 0;
			var trees = Cheats.FindTree();
			yield return Commands.PlayerMoveCommand(trees[treeIndex].transform.position, new ResultData<PlayerMoveResult>());
			yield return Commands.WaitForSecondsCommand(1, new ResultData<SimpleCommandResult>());
			
			yield return Commands.UseButtonClickCommand(Screens.Main.Button.Use, new ResultData<SimpleCommandResult>());
			yield return Commands.WaitForSecondsCommand(1, new ResultData<SimpleCommandResult>());
			
			if (new TreeFelledChecker(Context, trees[treeIndex]).Check() == true)
			{
				Fail($"Дерево срублено меньше чем за 3 заруба, хотя не должно было.");
			}
		}
	}
}