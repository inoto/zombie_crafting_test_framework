using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;

namespace Assets.UiTest.TestSteps
{
    public class ExampleStep :UiTestStepBase
    {
        public override string Id => "example";
        public override double TimeOut => 300;
        protected override Dictionary<string, string> GetArgs()
        {
            var args = new Dictionary<string, string>();
            return args;
        }

        protected override IEnumerator OnRun()
        {
            yield return Commands.WaitDialogCommand(Screens.Start.Content.StartScreen, false, new ResultData<WaitItemResult>());
            // var trees = Cheats.FindTree();
            // yield return Commands.PlayerMoveCommand(trees[0].transform.position, new ResultData<PlayerMoveResult>());
            // yield return Commands.WaitForSecondsCommand(1, new ResultData<SimpleCommandResult>());
            // for (int i = 0; i < 3; i++)
            // {
            //     yield return Commands.UseButtonClickCommand(Screens.Main.Button.Use, new ResultData<SimpleCommandResult>());
            //     yield return Commands.WaitForSecondsCommand(1, new ResultData<SimpleCommandResult>());
            // }
        }
    }
}