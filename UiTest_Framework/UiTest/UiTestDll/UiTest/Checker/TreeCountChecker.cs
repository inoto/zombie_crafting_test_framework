using Assets.UiTest.Context;
using Assets.UiTest.Context.Consts;
using UnityEngine;

namespace UiTest.UiTest.Checker
{
    public class TreeCountChecker :IUiTestChecker
    {
        private readonly IUiTestContext _context;
        private int _treeCount;
        private GameObject _inventory;

        public TreeCountChecker(IUiTestContext context,int treeCount)
        {
            _context = context;
            _treeCount = treeCount;
            _inventory = _context.Inventory.GetContent(Screens.Inventory.Content.InventoryCount.Item).GetGO();

        }
        public void Init()
        {
           _treeCount += 3;
        }

        public bool Check()
        {
            return _treeCount == _context.Cheats.TreeCount(_inventory);
        }
    }
}