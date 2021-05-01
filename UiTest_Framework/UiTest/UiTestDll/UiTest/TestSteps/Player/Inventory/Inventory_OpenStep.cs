using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;
using UiTest.UiTest.Checker;

namespace Assets.UiTest.TestSteps
{
    public class Inventory_OpenStep : UiTestStepBase
    {
        public override string Id => "inventory_open";

        protected override IEnumerator OnRun()
        {
            var result = new ResultData<SimpleCommandResult>();
            yield return Commands.UseButtonClickCommand(Screens.Main.Button.Inventory, result);
            if (!result.GetData().IsDone)
            {
                Fail($"Инвентарь не открылся, хотя должен был.");
            }
        }
    }
}