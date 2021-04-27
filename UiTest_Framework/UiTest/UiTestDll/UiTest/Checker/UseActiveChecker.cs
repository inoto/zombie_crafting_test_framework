using Assets.UiTest.Context;
using Assets.UiTest.Context.Consts;
using UnityEngine;

namespace UiTest.UiTest.Checker
{
    public class UseActiveChecker : IUiTestChecker
    {
        private readonly IUiTestContext _context;
        private readonly GameObject _useActiveGo;

        public UseActiveChecker(IUiTestContext context)
        {
            _context = context;
            _useActiveGo = context.Main.GetContent(Screens.Main.Content.UseActive.Item).GetGO();
        }
        public void Init()
        {
            throw new System.NotImplementedException();
        }

        public bool Check()
        {
            var alpha = _useActiveGo.GetComponent<CanvasGroup>().alpha;
            return alpha == 1;
        }
    }
}