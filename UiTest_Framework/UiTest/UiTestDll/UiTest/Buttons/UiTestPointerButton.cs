using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.UiTest.Buttons
{
    public class UiTestPointerButton : IUiTestButton
    {
        private readonly GameObject _self;
        private readonly IPointerClickHandler _cellPointerClick;
        private  PointerEventData _pointerEventData;
        private float _currentClickEventTime;
        
        public UiTestPointerButton( GameObject self)
        {
            _currentClickEventTime = UnityEngine.Time.time;
            _self = self;
            _cellPointerClick = _self.GetComponent<IPointerClickHandler>();
            
        }
        public void Use()
        {
            _pointerEventData = new PointerEventData(null);
            _pointerEventData.clickTime = GetUseClickTime();
            _cellPointerClick.OnPointerClick(_pointerEventData);
        }
        private float GetUseClickTime()
        {
            var time = _currentClickEventTime;
            _currentClickEventTime += 0.5f;
            return time;
        }
        public GameObject GetButtonGo()
        {
            return _self;
        }
    }
}