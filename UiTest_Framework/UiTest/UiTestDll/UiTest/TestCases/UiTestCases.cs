using System.Collections.Generic;

namespace Assets.UiTest.Runner
{
    public class UiTestCases : IUiTestCases
    {
        private Dictionary<int, IUiTestCase> _tests = new Dictionary<int, IUiTestCase>();

        public UiTestCases()
        {
            int i = 0;
            // _tests.Add(0, new TestCase0());
            // _tests.Add(i++, new TestCase1_InventoryOpen());
            _tests.Add(i++, new TestCase02_HarvestTree());
            _tests.Add(i++, new TestCase03_TreesHarvestWithLessThen3Actions());
            _tests.Add(i++, new TestCase04_TreesHarvestWith3Actions());
            _tests.Add(i++, new TestCase05_TreesUnfocusAfterHarvest());
            // _tests.Add(i++, new TestCase02_HarvestTree());
            // _tests.Add(i++, new TestCase02_HarvestTree());
            // _tests.Add(i++, new TestCase02_HarvestTree());
            // _tests.Add(i++, new TestCase02_HarvestTree());
            // _tests.Add(i++, new TestCase02_HarvestTree());
            // _tests.Add(i++, new TestCase02_HarvestTree());
            // _tests.Add(i++, new TestCase02_HarvestTree());
            // _tests.Add(i++, new TestCase02_HarvestTree());
            // _tests.Add(i++, new TestCase02_HarvestTree());
            // _tests.Add(i++, new TestCase02_HarvestTree());
            // _tests.Add(i++, new TestCase02_HarvestTree());
            // _tests.Add(i++, new TestCase02_HarvestTree());
            // _tests.Add(i++, new TestCase02_HarvestTree());
        }

        public IUiTestCase GetTestCase(int test)
        {
            return _tests[test];
        }
    }
}