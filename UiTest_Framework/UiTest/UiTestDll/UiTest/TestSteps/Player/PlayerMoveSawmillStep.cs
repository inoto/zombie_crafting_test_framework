using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;

namespace Assets.UiTest.TestSteps
{
	public class PlayerMoveSawmillStep : UiTestStepBase
	{
		public override string Id => "player_move_sawmill";
		public override double TimeOut => 300;
		protected override Dictionary<string, string> GetArgs()
		{
			var args = new Dictionary<string, string>();
			return args;
		}

		protected override IEnumerator OnRun()
		{
			var sawmillCoord = Context.GetObjectCordConfig("home", "workbench_sawmill");
			yield return Context.Commands.PlayerMoveCommand(sawmillCoord, new ResultData<PlayerMoveResult>());
		}
	}
}