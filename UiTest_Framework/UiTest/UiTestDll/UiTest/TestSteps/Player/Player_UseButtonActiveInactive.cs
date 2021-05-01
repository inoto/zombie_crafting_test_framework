using System.Collections;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;
using UiTest.UiTest.Checker;

namespace Assets.UiTest.TestSteps
{
	public class Player_UseButtonActiveInactiveStep : UiTestStepBase
	{
		public override string Id => "use_button_active_inactive";
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

			if (new UseActiveChecker(Context).Check() == true)
			{
				Fail($"Кнопка действия ещё активна, хотя не должна быть.");
			}
			
			yield return Commands.PlayerMoveCommand(trees[treeIndex+1].transform.position, new ResultData<PlayerMoveResult>());
			yield return Commands.WaitForSecondsCommand(1, new ResultData<SimpleCommandResult>());

			if (new UseActiveChecker(Context).Check() == false)
			{
				Fail($"Кнопка действия не активна, хотя должна быть.");
			}
		}
	}
}