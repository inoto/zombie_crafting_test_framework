using System;
using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;
using UiTest.UiTest.Checker;
using UnityEngine;

namespace Assets.UiTest.TestSteps
{
    public class InventoryMoveItemStep : UiTestStepBase
    {
        public override string Id => "inventory_move_item";
        public override double TimeOut => 300;
        protected override Dictionary<string, string> GetArgs()
        {
            var args = new Dictionary<string, string>();
            return args;
        }

        protected override IEnumerator OnRun()
        {
            yield return Commands.DragAndDropCommand(Screens.Inventory.Cell.Pockets, 3, Screens.Inventory.Cell.Backpack, 10, new ResultData<SimpleCommandResult>());

            var inventoryType = Screens.Inventory.Cell.Pockets.Item;
            for (int i = 0; i < 25; i++)
            {
                if (i == 16 || i == 17 || i == 21 || i == 22)
                    continue;
                if (i >= 10 && i < 25)
                    inventoryType = Screens.Inventory.Cell.Backpack.Item;
                var go = Context.Inventory.GetCells(inventoryType).GetCell(i);
                int cellCount = Context.Cheats.CellCount(go);
                Context.SendDebugLog($"cell {i} count: {cellCount}");
                var iconIsEmpty = Context.Cheats.IconIsEmpty(go);
                Context.SendDebugLog($"cell {i} iconIsEmpty: {iconIsEmpty}");
                var countIsEmpty = Context.Cheats.CountIsEmpty(go);
                Context.SendDebugLog($"cell {i} countIsEmpty: {countIsEmpty}");
            }
            
            var goRow = Context.Inventory.GetCells(Screens.Inventory.Cell.WorkbenchRow.Item).GetCell(0);
            int cellCountRow = Context.Cheats.CellCount(goRow);
            Context.SendDebugLog($"cell row count: {cellCountRow}");
            var iconIsEmptyRow = Context.Cheats.IconIsEmpty(goRow);
            Context.SendDebugLog($"cell row iconIsEmpty: {iconIsEmptyRow}");
            var countIsEmptyRow = Context.Cheats.CountIsEmpty(goRow);
            Context.SendDebugLog($"cell row countIsEmpty: {countIsEmptyRow}");
            
            
            
            yield break;
           
        }
    }
}