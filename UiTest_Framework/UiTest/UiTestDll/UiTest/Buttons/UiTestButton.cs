using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.UiTest.Buttons
{
    public class UiTestButton : IUiTestButton
    {
        private readonly GameObject _self;
        private readonly Button _button;

        public UiTestButton( GameObject self)
        {
            _self = self;
            _button=self.GetComponent<Button>();
        }
        public void Use()
        {
            _button.onClick.Invoke();
        }

        public GameObject GetButtonGo()
        {
            return _self;
        }
    }
}