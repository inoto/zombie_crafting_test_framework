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
            // Trees
            // _tests.Add(i++, new TestCase02_HarvestTree());
            // _tests.Add(i++, new TestCase03_TreesHarvestWithLessThen3Actions());
            // _tests.Add(i++, new TestCase04_TreesHarvestWith3Actions());
            // _tests.Add(i++, new TestCase05_TreesUnfocusAfterHarvest());
            // _tests.Add(i++, new TestCase32_TreesGetWoodAfterHarvest());
            // Player
            // _tests.Add(i++, new TestCase06_PlayerMoveWithDpad());
            // _tests.Add(i++, new TestCase07_PlayerFocusOnObject());
            // _tests.Add(i++, new TestCase08_PlayerChangeFocusWithinAliveObjects());
            // _tests.Add(i++, new TestCase09_PlayerEndFocusWhenLeaveObject());
            // Player Inventory
            // _tests.Add(i++, new TestCase1_InventoryOpen());
            // _tests.Add(i++, new TestCase10_PlayerInventoryClose());
            // _tests.Add(i++, new TestCase11_PlayerInventoryRemoveItem());
            // _tests.Add(i++, new TestCase12_PlayerInventoryMoveItem());
            // _tests.Add(i++, new TestCase13_PlayerInventoryAllSlotsAvailableToPutItem());
            // _tests.Add(i++, new TestCase14_PlayerInventoryItemStacking());
            // _tests.Add(i++, new TestCase15_PlayerInventoryItemMaxStack());
            // _tests.Add(i++, new TestCase17_PlayerInventoryItemNonStackable());
            // WorkbenchSawmill
            // _tests.Add(i++, new TestCase02_HarvestTree());
        }

        public IUiTestCase GetTestCase(int test)
        {
            if (_tests.ContainsKey(test))
                return _tests[test];
            return null;
        }

        public string GetTestCaseName(int number)
        {
            var clas = _tests[number];
            return clas.GetType().ToString();
        }
    }
}