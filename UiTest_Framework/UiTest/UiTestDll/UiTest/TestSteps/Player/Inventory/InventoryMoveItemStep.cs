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

        protected override IEnumerator OnRun()
        {
            int moveFromIndex = 0;
            int moveToIndex = 5;
            
            var cellFrom = Context.FindInventoryCellByIndex(moveFromIndex, Screens.Inventory.Cell.Pockets);
            var iconNameFrom = Context.GetCellIconName(cellFrom);
            
            // yield return Commands.UseButtonClickCommand(Screens.Main.Button.Inventory, new ResultData<SimpleCommandResult>());
            var result = new ResultData<SimpleCommandResult>();
            yield return Commands.DragAndDropCommand(Screens.Inventory.Cell.Pockets, moveFromIndex, Screens.Inventory.Cell.Pockets, moveToIndex, result);
            yield return Commands.WaitForSecondsCommand(0.5f, new ResultData<SimpleCommandResult>());

            var cellTo = Context.FindInventoryCellByIndex(moveToIndex, Screens.Inventory.Cell.Pockets);
            var iconNameTo = Context.GetCellIconName(cellTo);
            if (iconNameFrom == iconNameTo && !Cheats.IconIsEmpty(cellTo))
            {}
            else
            {
                // yield return Commands.UseButtonClickCommand(Screens.Inventory.Button.Close, new ResultData<SimpleCommandResult>());
                Fail($"Не удалось переместить предмет из позиции {moveFromIndex} на позицию {moveToIndex} в инвентаре.");
            }
            // yield return Commands.UseButtonClickCommand(Screens.Inventory.Button.Close, new ResultData<SimpleCommandResult>());
            yield return Commands.WaitForSecondsCommand(1f, new ResultData<SimpleCommandResult>());
        }
    }
}