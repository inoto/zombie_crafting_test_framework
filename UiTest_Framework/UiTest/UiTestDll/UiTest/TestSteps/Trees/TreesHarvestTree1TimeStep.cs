using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;
using UiTest.UiTest.Checker;
using UnityEngine.Assertions;

namespace Assets.UiTest.TestSteps.Trees
{
	public class TreesHarvestTree1TimeStep : UiTestStepBase
	{
		public override string Id => "trees_harvest_tree_1_time";
		public override double TimeOut => 300;
		protected override Dictionary<string, string> GetArgs()
		{
			return new Dictionary<string, string>();
		}

		protected override IEnumerator OnRun()
		{
			int treeIndex = 1;
			var trees = Cheats.FindTree();
			var moveResult = new ResultData<PlayerMoveResult>();
			yield return Commands.PlayerMoveCommand(trees[treeIndex].transform.position, moveResult);
			var simpleResult = new ResultData<SimpleCommandResult>();
			yield return Commands.WaitForSecondsCommand(1, simpleResult);
			
			yield return Commands.UseButtonClickCommand(Screens.Main.Button.Use, new ResultData<SimpleCommandResult>());
			yield return Commands.WaitForSecondsCommand(1, new ResultData<SimpleCommandResult>());
			
			if (new TreeFelledChecker(Context, trees[treeIndex]).Check() == true)
			{
				Fail($"Дерево срублено после 1 заруба, хотя должно быть срублено за 3 заруба.");
			}

			if (new TreeCountChecker(Context, 0).Check() == false)
			{
				Fail($"Не срубленное дерево попало в инвентарь, хотя не должно было.");
			}

			if (new UseActiveChecker(Context).Check() == false)
			{
				Fail($"Кнопка действия не активна, хотя должна быть.");
			}

			if (new UseTargetChecker(Context, trees[treeIndex].transform.position).Check() == false)
			{
				Fail($"Дерево не в таргете, хотя должно быть.");
			}
			yield return Commands.ScreenshotCommand(new ResultData<SimpleCommandResult>());
			
			yield break;
		}
	}
}