using Assets.UiTest.Context;
using Assets.UiTest.Context.Consts;
using UnityEngine;

namespace UiTest.UiTest.Checker
{
    public class UseTargetChecker : IUiTestChecker
    {
        private readonly Vector3 _targetPosition;
        private GameObject _targetGO;

        public UseTargetChecker(IUiTestContext context, Vector3 targetPosition)
        {
             _targetGO = context.Main.GetContent(Screens.Main.Content.UseTarget.Item).GetGO();
            _targetPosition = targetPosition;
        }
        public void Init()
        {
            throw new System.NotImplementedException();
        }

        public bool Check()
        {
            return _targetGO.transform.position == _targetPosition;
        }
    }
}