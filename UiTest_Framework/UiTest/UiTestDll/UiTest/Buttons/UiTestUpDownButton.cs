using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.UiTest.Buttons
{
    public class UiTestUpDownButton : IUiTestButton, IUiUpDownTestButton
    {
        private readonly GameObject _self;
        private readonly IPointerDownHandler _pointerDown;
        private readonly IPointerUpHandler _pointerUp;

        public UiTestUpDownButton(GameObject self)
        {
            _self = self;
            _pointerDown = _self.GetComponent<IPointerDownHandler>();
            _pointerUp = _self.GetComponent<IPointerUpHandler>();
        }

        public void Use()
        {
           
            var pointerEventData = new PointerEventData(null);
            _pointerDown.OnPointerDown(pointerEventData);
            _pointerUp.OnPointerUp(pointerEventData);
        }

        public GameObject GetButtonGo()
        {
            return _self;
        }

        public void Down()
        {
            var pointerEventData = new PointerEventData(null);
            _pointerDown.OnPointerDown(pointerEventData);
        }
        
        public void Up()
        {
            var pointerEventData = new PointerEventData(null);
            _pointerUp.OnPointerUp(pointerEventData);
        }
    }
}