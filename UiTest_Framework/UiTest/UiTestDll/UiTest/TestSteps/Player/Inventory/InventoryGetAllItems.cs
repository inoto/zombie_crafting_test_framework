using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;
using UiTest.UiTest.Checker;
using UnityEngine;

namespace Assets.UiTest.TestSteps
{
    public class InventoryGetAllItemsStep : UiTestStepBase
    {
        public override string Id => "inventory_get_all_items";
        public override double TimeOut => 300;
        protected override Dictionary<string, string> GetArgs()
        {
            var args = new Dictionary<string, string>();
            return args;
        }

        protected override IEnumerator OnRun()
        {
            // Context.GetButtonsGroup()).GetCells(_cellId.Item).ClickCell(_cell);
            yield return Context.Inventory.GetCells("pockets");
            var pocketCells = new List<GameObject>();
            var startGo = Context.Inventory.GetCells(Screens.Inventory.Cell.Pockets.Item).GetCell(0);
            var endGo = Context.Inventory.GetCells(Screens.Inventory.Cell.Backpack.Item).GetCell(0);
        }
    }
}