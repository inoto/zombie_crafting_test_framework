using System;
using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;
using UiTest.UiTest.Checker;
using UnityEngine;

namespace Assets.UiTest.TestSteps
{
    public class Inventory_MoveItemStep : UiTestStepBase
    {
        public override string Id => "inventory_move_item";

        protected override IEnumerator OnRun()
        {
            int moveFromIndex = 0;
            int moveToIndex = 5;
            
            var cellFrom = Context.Inventory.GetCells(Screens.Inventory.Cell.Pockets.Item).GetCell(moveFromIndex);
            var iconNameFrom = Context.GetCellIconName(cellFrom);
            
            var result = new ResultData<SimpleCommandResult>();
            yield return Commands.DragAndDropCommand(Screens.Inventory.Cell.Pockets, moveFromIndex, Screens.Inventory.Cell.Pockets, moveToIndex, result);
            yield return Context.WaitEndFrame;

            var cellTo = Context.Inventory.GetCells(Screens.Inventory.Cell.Pockets.Item).GetCell(moveToIndex);
            var iconNameTo = Context.GetCellIconName(cellTo);
            if (iconNameFrom == iconNameTo && !Cheats.IconIsEmpty(cellTo))
            {}
            else
            {
                // yield return Commands.UseButtonClickCommand(Screens.Inventory.Button.Close, new ResultData<SimpleCommandResult>());
                Fail($"Не удалось переместить предмет из позиции {moveFromIndex} на позицию {moveToIndex} в инвентаре.");
            }
        }
    }
}