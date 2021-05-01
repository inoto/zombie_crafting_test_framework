using System.Collections.Generic;
using Assets.UiTest.TestSteps;

namespace Assets.UiTest.Runner
{
	public class TestCase_WorkbenchSawmill_12_ResultMaxStack : UiStepsTestCase
	{
		protected override IEnumerator<IUiTestStepBase> Condition()
		{
			yield return Steps.WaitGameLoadedStep();
			yield return Steps.PlayerMoveSawmillStep();
			yield return Steps.WorkbenchSawmill_OpenStep();
			yield return new WorkbenchSawmill_ResultMaxStackStep();
			yield return Steps.WorkbenchSawmill_CloseStep();
		}
	}
}