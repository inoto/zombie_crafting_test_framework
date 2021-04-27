using Assets.UiTest.Context;
using Assets.UiTest.Context.Consts;
using UnityEngine;

namespace UiTest.UiTest.Checker
{
    public class CellCountChecker :IUiTestChecker
    {
        private readonly IUiTestContext _context;
        private readonly int _count;
        private GameObject _cellGo;

        public CellCountChecker(IUiTestContext context, StringParam cell, int cellIndex,int count)
        {
            _context = context;
            _count = count;
            _cellGo = context.Inventory.GetCells(cell.Item).GetCell(cellIndex);
        }
        public void Init()
        {
            throw new System.NotImplementedException();
        }

        public bool Check()
        {
            var count = _context.Cheats.CellCount(_cellGo);
            return count == _count;
        }
    }
}