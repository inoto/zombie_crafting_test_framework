using System.Collections.Generic;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;
using Assets.UiTest.TestSteps;
using Assets.UiTest.TestSteps.Trees;
using UnityEngine.Assertions;

namespace Assets.UiTest.Runner
{
	public class TestCase02_HarvestTree : UiStepsTestCase
	{
		protected override IEnumerator<IUiTestStepBase> Condition()
		{
			yield return Steps.ExampleStep();
			// yield return Steps.TreesHarvestTree1TimeStep();
			// yield return Steps.TreesHarvestTree1TimeStep();
			// yield return Steps.TreesFullyHarvestTreeStep();
			yield return Steps.TreesHarvestWithoutAxeStep();
		}
	}
}