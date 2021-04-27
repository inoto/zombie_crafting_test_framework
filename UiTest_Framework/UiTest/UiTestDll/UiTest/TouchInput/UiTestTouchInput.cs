
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.UiTest.TouchInput
{
    public class UiTestTouchInput : IUiTestTouchInput
    {
        private IUiTestTouchController _touchController;
        private Vector2 _dragStartPosition;
        private List<GameObject> _focusedObjects;
        private Touch _emulatedTouch;
        private GameObject _holdDownObject;
        private Camera _camera;
        private RaycastHit[] _raycastHits;
        private Vector2 _screenCoords;
        private Vector2 _oldScrollDragPosition;
        private Vector2 _oldPosition;
        private float _currentClickEventTime;

        public UiTestTouchInput(IGameManager gameManager)
        {
             _touchController = gameManager.GetTouchController();
            _camera= null;
            _raycastHits = new RaycastHit[20];
            _focusedObjects = new List<GameObject>();
            _screenCoords = new Vector2(0,0);
        }

        public void SwipeStart(Vector2 startPosition, Vector2 position, Vector2 swipeVector)
        {
            _touchController.SwipeStart(2147483647,startPosition,position,swipeVector);
        }
        
        public void Swipe(Vector2 startPosition, Vector2 position, Vector2 swipeVector)
        {
            _touchController.Swipe(2147483647,startPosition,position,swipeVector);
        }
        
        public void SwipeEnd(Vector2 startPosition, Vector2 position, Vector2 swipeVector)
        {
            _touchController.SwipeEnd(2147483647,startPosition,position,swipeVector);
        }
        
        public void SimpleTap(Vector2 startPosition, Vector2 position, Vector2 swipeVector)
        {
            _touchController.SimpleTap( 2147483647,startPosition,position,swipeVector);
        }
        
        public void RemoveGesture(Vector2 startPosition, Vector2 position, Vector2 swipeVector)
        {
            _touchController.RemoveGesture( 2147483647,startPosition,position,swipeVector);
        }

        public bool CheckOverUi(Vector2 position, string nemeUI)
        {
            PointerEventData data = new PointerEventData(EventSystem.current)
            {
                eligibleForClick = false,
                pointerId = -1,
                position = position,
                delta = Vector2.zero,
                pressPosition = Vector2.zero,
                clickTime = 0.0f,
                clickCount = 0,
                scrollDelta = Vector2.zero,
                useDragThreshold = true,
                dragging = false,
                button = PointerEventData.InputButton.Left
            };
            List<RaycastResult> result = new List<RaycastResult>();
            EventSystem.current.RaycastAll(data, result);
            foreach (var raycastResult in result)
            {
                if (raycastResult.gameObject.layer == LayerMask.NameToLayer("UI"))
                {
                    if (nemeUI == raycastResult.gameObject.name)
                    {
                        return false;
                    }

                    return true;
                }
            }

            return false;
        }

        public PointerEventData GetPointerEventData(Vector2 position)
        {
            PointerEventData data = new PointerEventData(EventSystem.current)
            {
                eligibleForClick = false,
                pointerId = -1,
                position = position,
                delta = Vector2.zero,
                pressPosition = Vector2.zero,
                clickTime = GetUseClickTime(),
                clickCount = 0,
                scrollDelta = Vector2.zero,
                useDragThreshold = true,
                dragging = false,
                button = PointerEventData.InputButton.Left
            };
            
            return data;
        }
         public void ButtonDown()
        {
                _dragStartPosition = _screenCoords;
                UILayerRaycast(_screenCoords);
                if (_focusedObjects.Count == 0)
                {
                    ExecutePhysicsRaycastEvent("OnMouseDown", _screenCoords);
                }
                _emulatedTouch.position = _screenCoords;
                _emulatedTouch.fingerId = int.MaxValue;
                _emulatedTouch.pressure = 1.0f;
                _emulatedTouch.phase = TouchPhase.Began;
            _touchController.SetEmulatedTouch(_emulatedTouch);

                ExecuteDownEvent(_focusedObjects, _screenCoords);
        }

        private void UILayerRaycast(Vector2 screenCoords)
        {
            _focusedObjects.Clear();
            var raycastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(GetPointerEventData(screenCoords), raycastResults);
            GameObject go;
            for (int i = 0; i < raycastResults.Count; i++)
            {
                go = raycastResults[i].gameObject;
                for (int j = 0; j < 5; j++)
                {
                    _focusedObjects.Add(go);
                    if (go.transform.parent != null)
                    {
                        go = go.transform.parent.gameObject;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private void ExecuteDownEvent(List<GameObject> raycastResults, Vector2 screenCoords)
        {
            _holdDownObject = null;
            foreach (var obj in raycastResults)
            {
                GameObject go = obj;
                for (int i = 0; i < 5; i++)
                {
                    if (ExecuteEvents.Execute<IPointerDownHandler>(go, GetPointerEventData(screenCoords),
                        (o, a) => o.OnPointerDown(GetPointerEventData(screenCoords))))
                    {
                        _holdDownObject = go;
                        return;
                    }

                    if (go.transform.parent != null)
                        go = go.transform.parent.gameObject;
                    else
                    {
                        break;
                    }
                }

            }
        }

        public void ButtonUp()
        {
            var raycastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(GetPointerEventData(_screenCoords), raycastResults);
            ExecutePointerClickEvent(raycastResults, _screenCoords);
            UILayerRaycast(_screenCoords);
            ExecutePointerUpEvent(_screenCoords);
            ExecuteTouchSwipeEndEvent();
            if (raycastResults.Count == 0)
            {
                ExecutePhysicsRaycastEvent("OnMouseUp", _screenCoords);
            }
            _focusedObjects.Clear();
            _touchController.RemoveEmulatedTouch();
        }
        private void ExecuteDragEndEvent(Vector2 screenCoords)
        {
                foreach (var focused in _focusedObjects)
                {
                    if (ExecuteEvents.Execute<IEndDragHandler>(focused, GetPointerEventData(screenCoords),
                        (o, a) => o.OnEndDrag(GetPointerEventData(screenCoords))))
                    {
                        break;
                    }
                }
        }
        
        private void ExecutePhysicsRaycastEvent(string eventName, Vector2 screenCoords)
        {
            var raycastResultsCount = Physics.RaycastNonAlloc(_camera.ScreenPointToRay(screenCoords), _raycastHits,
                float.PositiveInfinity);
            for (int i = 0; i < raycastResultsCount; i++)
            {
                var obj = _raycastHits[i];
                obj.collider.gameObject.BroadcastMessage(eventName, SendMessageOptions.DontRequireReceiver);
            }
        }
        private void ExecutePointerUpEvent(Vector2 screenCoords)
        {
            ExecuteEvents.Execute<IPointerUpHandler>(_holdDownObject, GetPointerEventData(screenCoords),
                (o, a) => o.OnPointerUp(GetPointerEventData(screenCoords)));
        }

        private void ExecutePointerClickEvent(List<RaycastResult> raycastResults, Vector2 screenCoords)
        {
            foreach (var obj in raycastResults)
            {
                var go = obj.gameObject;
                go = obj.gameObject;
                for (int i = 0; i < 5; i++)
                {
                    if (ExecuteEvents.Execute<IPointerClickHandler>(go, GetPointerEventData(screenCoords),
                        (o, a) => o.OnPointerClick(GetPointerEventData(screenCoords))))
                    {
                        return;
                    }
                    if (go.transform.parent != null)
                        go = go.transform.parent.gameObject;
                    else break;
                }
            }
        }

        public void ButtonData(Camera camera, Vector2 screenCoords)
        {
            _camera = camera;
            _screenCoords = screenCoords;
        }
        
        private void ExecuteTouchSwipeEndEvent()
        {
                _emulatedTouch.phase = TouchPhase.Ended;
                _touchController.SetEmulatedTouch(_emulatedTouch);
        }

        public void ExecuteTouchEmulationEvents(Vector2 screenCoords)
        {
            _emulatedTouch.phase = TouchPhase.Moved;
            _emulatedTouch.position = screenCoords;
            _touchController.SetEmulatedTouch(_emulatedTouch);
        }

        private void ExecuteDragBeginEvents(Vector2 screenCoords)
        {
            foreach (var focused in _focusedObjects)
            {
                if (ExecuteEvents.Execute<IBeginDragHandler>(focused, GetPointerEventData(screenCoords),
                    (o, a) => o.OnBeginDrag(GetPointerEventData(screenCoords))))
                {
                    _oldScrollDragPosition = screenCoords;
                    _oldPosition = screenCoords;
                    
                    break;
                }
            }
        }

        public void Drag(Vector2 screenCoords)
        {
            
            foreach (var focused in _focusedObjects)
            {
                if (ExecuteEvents.Execute<IDragHandler>(focused, GetPointerEventData(screenCoords),
                    (o, a) => o.OnDrag(GetPointerEventData(screenCoords))))
                {
                    break;
                }
            }
        }
        
        private void ExecuteDropEvent(Vector2 screenCoords)
        {
            
                foreach (var obj in _focusedObjects)
                {
                    var go = obj.gameObject;
                    for (int i = 0; i < 5; i++)
                    {
                        if (ExecuteEvents.Execute<IDropHandler>(go, GetPointerEventData(screenCoords),
                            (o, a) => o.OnDrop(GetPointerEventData(screenCoords))))
                        {
                            return;
                        }
                        if (go.transform.parent != null)
                            go = go.transform.parent.gameObject;
                        else
                        {
                            break;
                        }
                    }
                }
        }
        
        private float GetUseClickTime()
        {
            var time = _currentClickEventTime;
            _currentClickEventTime += 0.5f;
            return time;
        }

        public void DragStart(Vector2 screenCoords)
        {
            UILayerRaycast(screenCoords);
            ExecuteDragBeginEvents(screenCoords);
        }
        
        public void DragEnd(Vector2 screenCoords)
        {
            UILayerRaycast(screenCoords);
            ExecuteDropEvent(screenCoords);
            ExecuteDragEndEvent(screenCoords);
            _focusedObjects.Clear();
        }
    }
}