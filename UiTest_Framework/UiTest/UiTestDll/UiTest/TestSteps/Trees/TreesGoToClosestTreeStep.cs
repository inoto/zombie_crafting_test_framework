using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;
using UnityEngine.Assertions;

namespace Assets.UiTest.TestSteps.Trees
{
	public class TreesGoToClosestTreeStep : UiTestStepBase
	{
		public override string Id { get; }
		public override double TimeOut { get; }
		protected override Dictionary<string, string> GetArgs()
		{
			throw new System.NotImplementedException();
		}

		protected override IEnumerator OnRun()
		{
			var trees = Cheats.FindTree();
			var moveResult = new ResultData<PlayerMoveResult>();
			yield return Commands.PlayerMoveCommand(trees[0].transform.position, moveResult);
			var simpleResult = new ResultData<SimpleCommandResult>();
			yield return Commands.WaitForSecondsCommand(1, simpleResult);
		}
	}
}