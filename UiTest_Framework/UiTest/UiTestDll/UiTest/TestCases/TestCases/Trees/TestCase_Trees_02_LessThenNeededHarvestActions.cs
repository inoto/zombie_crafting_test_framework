using System.Collections.Generic;
using Assets.UiTest.TestSteps;
using Assets.UiTest.TestSteps.Trees;

namespace Assets.UiTest.Runner
{
	public class TestCase_Trees_02_LessThenNeededHarvestActions : UiStepsTestCase
	{
		protected override IEnumerator<IUiTestStepBase> Condition()
		{
			yield return Steps.WaitGameLoadedStep();
			yield return new Trees_HarvestTree1TimeStep();
			yield return new Trees_HarvestTree1TimeStep();
		}
	}
}