using System.Collections.Generic;
using Assets.UiTest.TestSteps;

namespace Assets.UiTest.Runner
{
	public class TestCase_Player_03_ChangeFocusWithinAliveObjects : UiStepsTestCase
	{
		protected override IEnumerator<IUiTestStepBase> Condition()
		{
			yield return Steps.WaitGameLoadedStep();
			yield return new Player_ChangeFocusWithinAliveObjects();
		}
	}
}