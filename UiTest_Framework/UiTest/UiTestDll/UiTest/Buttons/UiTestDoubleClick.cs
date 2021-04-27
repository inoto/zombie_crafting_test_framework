using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.UiTest.Buttons
{
    public class UiTestDoubleClick : IUiTestButton
    {
        private readonly GameObject _self;
        private readonly IPointerClickHandler _cellPointerClick;
        private readonly PointerEventData _pointerEventData;

        public UiTestDoubleClick( GameObject self)
        {
            _self = self;
            _cellPointerClick = _self.GetComponent<IPointerClickHandler>();
            _pointerEventData = new PointerEventData(null);
        }
        public void Use()
        {
            _cellPointerClick.OnPointerClick(_pointerEventData);
        }

        public GameObject GetButtonGo()
        {
            return _self;
        }
    }
}