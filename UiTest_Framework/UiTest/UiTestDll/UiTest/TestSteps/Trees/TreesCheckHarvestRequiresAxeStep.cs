using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Results;

namespace Assets.UiTest.TestSteps.Trees
{
	public class TreesCheckHarvestRequiresAxeStep : UiTestStepBase
	{
		public override string Id => "check_harvest_requires_axe";
		public override double TimeOut => 300;
		protected override Dictionary<string, string> GetArgs()
		{
			return new Dictionary<string, string>();
		}

		protected override IEnumerator OnRun()
		{
			var cell = Context.FindCellInInventoriesBySpriteName("tool_hatchet_iron",
				new HashSet<string>() {"inventory_count", "backpack_count"});

			if (cell == null)
			{
				Fail($"");
			}
			
			
			
			
			yield break;
		}
	}
}