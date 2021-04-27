using Assets.UiTest.Context;
using Assets.UiTest.Context.Consts;
using UnityEngine;

namespace UiTest.UiTest.Checker
{
    public class CountIsEmptyChecker :IUiTestChecker
    {
        private IUiTestContext _context;
        private GameObject _cellGo;

        public CountIsEmptyChecker(IUiTestContext context, StringParam cell, int cellIndex)
        {
            _context = context;
            _cellGo = _context.Inventory.GetCells(cell.Item).GetCell(cellIndex);
        }
        public void Init()
        {
            throw new System.NotImplementedException();
        }

        public bool Check()
        {
            return _context.Cheats.CountIsEmpty(_cellGo);
        }
    }
}