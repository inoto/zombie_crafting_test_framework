using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;

namespace Assets.UiTest.TestSteps
{
    public class WaitGameLoadedStep : UiTestStepBase
    {
        public override string Id => "wait_game_loaded";
        public override double TimeOut => 300;
        protected override Dictionary<string, string> GetArgs()
        {
            var args = new Dictionary<string, string>();
            return args;
        }

        protected override IEnumerator OnRun()
        {
            yield return Commands.WaitDialogCommand(Screens.Start.Content.StartScreen, false, new ResultData<WaitItemResult>());
        }
    }
}