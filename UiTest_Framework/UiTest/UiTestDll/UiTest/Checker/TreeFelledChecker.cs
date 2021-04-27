using Assets.UiTest.Context;
using UnityEngine;

namespace UiTest.UiTest.Checker
{
    public class TreeFelledChecker : IUiTestChecker
    {
        private readonly IUiTestContext _context;
        private readonly GameObject _tree;

        public TreeFelledChecker(IUiTestContext context, GameObject tree)
        {
            _context = context;
            _tree = tree;
        }
        public void Init()
        {
            throw new System.NotImplementedException();
        }

        public bool Check()
        {
            return _context.Cheats.TreeFelled(_tree);
        }
    }
}