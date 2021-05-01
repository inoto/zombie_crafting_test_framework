using System.Collections.Generic;
using Assets.UiTest.TestSteps;
using Assets.UiTest.TestSteps.Trees;

namespace Assets.UiTest.Runner
{
	public class TestCase_Trees_03_MaxHarvestActions : UiStepsTestCase
	{
		protected override IEnumerator<IUiTestStepBase> Condition()
		{
			yield return Steps.WaitGameLoadedStep();
			yield return new Trees_FullyHarvestTreeStep();
		}
	}
}