using System.Collections;
using Assets.UiTest.Results;
using UnityEngine;

namespace Assets.UiTest.TestSteps
{
	public class PlayerMoveWithDpadStep : UiTestStepBase
	{
		public override string Id => "player_move_with_dpad";
		protected override IEnumerator OnRun()
		{
			var trees = Cheats.FindTree();
			GameObject farthestTree = null;
			float farthestDist = 0f;
			for (int i = 0; i < trees.Count; i++)
			{
				var dist = Vector3.Distance(trees[i].transform.position, Context.GetPlayerPosition());
				if (dist > farthestDist)
				{
					farthestDist = dist;
					farthestTree = trees[i];
				}
			}
			
			var playerMoveResult = new ResultData<PlayerMoveResult>();
			yield return Commands.PlayerMoveCommand(farthestTree.transform.position, playerMoveResult);
			yield return Commands.WaitForSecondsCommand(1, new ResultData<SimpleCommandResult>());
			if (playerMoveResult.GetData().FailMove == true)
			{
				Fail($"Игрок не смог переместится используя Dpad.");
			}
		}
	}
}