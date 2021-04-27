using System;
using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;
using UnityEngine;

namespace Assets.UiTest.TestCommands
{
    public class DragAndDropCommand : IUiTestCommand<SimpleCommandResult>
    {
        private readonly IUiTestContext _context;
        private readonly StringParam _inventoryIdStart;
        private readonly int _cellNumberStart;
        private readonly StringParam _inventoryIdEnd;
        private readonly int _cellNumberEnd;

        public DragAndDropCommand(IUiTestContext context, StringParam inventoryIdStart, int cellNumberStart, StringParam inventoryIdEnd, int cellNumberEnd)
        {
            _context = context;
            _inventoryIdStart = inventoryIdStart;
            _cellNumberStart = cellNumberStart;
            _inventoryIdEnd = inventoryIdEnd;
            _cellNumberEnd = cellNumberEnd;
        }

        public IEnumerator Run()
        {
            var startGo = _context.Inventory.GetCells(_inventoryIdStart.Item).GetCell(_cellNumberStart);
            var endGo = _context.Inventory.GetCells(_inventoryIdEnd.Item).GetCell(_cellNumberEnd);
            var dragStart = _context.Cheats.CordButton(startGo);
            var dragEnd = _context.Cheats.CordButton(endGo);
            _context.TestTouchInput.DragStart(dragStart);
            yield return _context.WaitEndFrame;
            _context.TestTouchInput.Drag(dragEnd);
            yield return _context.WaitEndFrame;
            _context.TestTouchInput.DragEnd(dragEnd);
            yield return _context.WaitEndFrame;
        }

        public SimpleCommandResult GetResult()
        {
            return new SimpleCommandResult(true);
        }
    }
}