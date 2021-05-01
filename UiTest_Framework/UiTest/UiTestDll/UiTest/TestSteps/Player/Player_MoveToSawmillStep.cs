using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;

namespace Assets.UiTest.TestSteps
{
	public class Player_MoveToSawmillStep : UiTestStepBase
	{
		public override string Id => "player_move_to_sawmill";
		public override double TimeOut => 300;
		protected override Dictionary<string, string> GetArgs()
		{
			var args = new Dictionary<string, string>();
			return args;
		}

		protected override IEnumerator OnRun()
		{
			var sawmillCoord = Context.GetObjectCordConfig("home", "workbench_sawmill");
			var result = new ResultData<PlayerMoveResult>();
			yield return Context.Commands.PlayerMoveCommand(sawmillCoord, result);
			if (result.GetData().FailMove == true)
			{
				Fail($"Игроку не удалось добраться до станка.");
			}
		}
	}
}