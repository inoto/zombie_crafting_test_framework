using System.Collections;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;
using UiTest.UiTest.Checker;

namespace Assets.UiTest.TestSteps
{
	public class PlayerFocusOnObjectStep : UiTestStepBase
	{
		public override string Id => "player_focus_on_object";
		protected override IEnumerator OnRun()
		{
			int treeIndex = 1;
			var trees = Cheats.FindTree();
			
			yield return Commands.PlayerMoveCommand(trees[treeIndex].transform.position, new ResultData<PlayerMoveResult>());
			yield return Commands.WaitForSecondsCommand(1, new ResultData<SimpleCommandResult>());

			if (new UseTargetChecker(Context, trees[treeIndex].transform.position).Check() == false)
			{
				Fail($"Объект {trees[treeIndex].name} не в фокусе, хотя должен быть.");
			}
		}
	}
}