using System.Collections;
using Assets.UiTest.Results;
using UiTest.UiTest.Checker;

namespace Assets.UiTest.TestSteps
{
	public class PlayerEndFocusWhenLeaveObject : UiTestStepBase
	{
		public override string Id => "player_end_focus_when_leave_object";
		protected override IEnumerator OnRun()
		{
			int treeIndex = 1;
			var trees = Cheats.FindTree();
			int anotherAliveTreeIndex = -1;
			for (int i = 0; i < trees.Count; i++)
			{
				if (!Cheats.TreeFelled(trees[i]))
				{
					anotherAliveTreeIndex = i;
					break;
				}
			}
			
			yield return Commands.PlayerMoveCommand(trees[treeIndex].transform.position, new ResultData<PlayerMoveResult>());
			yield return Commands.WaitForSecondsCommand(1, new ResultData<SimpleCommandResult>());
			
			yield return Commands.PlayerMoveCommand(trees[anotherAliveTreeIndex].transform.position, new ResultData<PlayerMoveResult>());
			yield return Commands.WaitForSecondsCommand(1, new ResultData<SimpleCommandResult>());

			if (new UseTargetChecker(Context, trees[treeIndex].transform.position).Check() == true)
			{
				Fail($"Объект {trees[treeIndex].name} в фокусе, хотя не должен быть.");
			}
		}
	}
}