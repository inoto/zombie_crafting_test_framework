using System.Collections.Generic;

namespace Assets.UiTest.Runner
{
    public class UiTestCases : IUiTestCases
    {
        private Dictionary<int, IUiTestCase> _tests = new Dictionary<int, IUiTestCase>();

        public UiTestCases()
        {
            // _tests.Add(0, new TestCase0());
            // Trees
            // _tests.Add(1, new TestCase_Trees_01_HarvestRequiresAxe());
            // _tests.Add(2, new TestCase_Trees_02_LessThenNeededHarvestActions());
            // _tests.Add(3, new TestCase_Trees_03_MaxHarvestActions());
            // _tests.Add(4, new TestCase_Trees_04_UnfocusAfterHarvest());
            // _tests.Add(5, new TestCase_Trees_05_GetWoodItemAfterHarvest());
            // Player
            // _tests.Add(6, new TestCase_Player_01_MoveWithDpad());
            // _tests.Add(7, new TestCase_Player_02_FocusOnObject());
            // _tests.Add(8, new TestCase_Player_03_ChangeFocusWithinAliveObjects());
            // _tests.Add(9, new TestCase_Player_04_EndFocusWhenLeaveObject());
            // Player Inventory
            // _tests.Add(10, new TestCase_Inventory_01_Open());
            // _tests.Add(11, new TestCase_Inventory_02_Close());
            // _tests.Add(12, new TestCase_Inventory_03_RemoveItem());
            // _tests.Add(13, new TestCase_Inventory_04_MoveItem());
            // _tests.Add(14, new TestCase_Inventory_05_AllSlotsAvailable());
            // _tests.Add(15, new TestCase_Inventory_06_ItemStacking());
            // _tests.Add(16, new TestCase_Inventory_07_ItemMaxStack());
            // _tests.Add(17, new TestCase_Inventory_08_ItemNonStackable());
            // WorkbenchSawmill
            // _tests.Add(0, new TestCase_WorkbenchSawmill_01_Open());
            // _tests.Add(0, new TestCase_WorkbenchSawmill_02_Close());
            // _tests.Add(0, new TestCase_WorkbenchSawmill_03_ItemsProcessing());
            //
            // _tests.Add(0, new TestCase_WorkbenchSawmill_06_ResultStacking());
            // _tests.Add(0, new TestCase_WorkbenchSawmill_07_RemoveRowDuringProgress());
            // _tests.Add(0, new TestCase_WorkbenchSawmill_08_HaveWrongItemInResult());
            // _tests.Add(0, new TestCase_WorkbenchSawmill_09_SkipProgress());
            // _tests.Add(0, new TestCase_WorkbenchSawmill_10_SkipSpendsMoney());
            // _tests.Add(0, new TestCase_WorkbenchSawmill_10_SkipProgressNotEnoughMoney());
            // _tests.Add(0, new TestCase_WorkbenchSawmill_12_ResultMaxStack());
            // _tests.Add(0, new TestCase_WorkbenchSawmill_13_ProcessSchemaItemsOnly());
            // _tests.Add(0, new TestCase_WorkbenchSawmill_14_SkipResetsProgress());
            // _tests.Add(0, new TestCase_WorkbenchSawmill_04_ItemsProcessingWhenResultIsBusy());
            _tests.Add(0, new TestCase_WorkbenchSawmill_06_ProgressStopStartWhenReplaceResult());
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