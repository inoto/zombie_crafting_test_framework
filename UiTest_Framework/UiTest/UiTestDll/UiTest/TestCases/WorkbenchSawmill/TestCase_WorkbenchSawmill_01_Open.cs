using System.Collections.Generic;
using Assets.UiTest.TestSteps;

namespace Assets.UiTest.Runner
{
	public class TestCase_WorkbenchSawmill_01_Open : UiStepsTestCase
	{
		protected override IEnumerator<IUiTestStepBase> Condition()
		{
			yield return Steps.PlayerMoveSawmillStep();
			yield return Steps.WorkbenchSawmillOpenStep();
		}
	}
}