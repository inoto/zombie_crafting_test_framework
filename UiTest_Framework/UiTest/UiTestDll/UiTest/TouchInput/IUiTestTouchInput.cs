using UnityEngine;

namespace Assets.UiTest.TouchInput
{
    public interface IUiTestTouchInput
    {
        void SwipeStart(Vector2 startPosition, Vector2 position, Vector2 swipeVector);
        void Swipe(Vector2 startPosition, Vector2 position, Vector2 swipeVector);
        void SwipeEnd(Vector2 startPosition, Vector2 position, Vector2 swipeVector);
        void SimpleTap(Vector2 startPosition, Vector2 position, Vector2 swipeVector);
        void RemoveGesture(Vector2 startPosition, Vector2 position, Vector2 swipeVector);
        bool CheckOverUi(Vector2 position, string nameUi);
        void ButtonUp();
        void ButtonDown();
        void ButtonData(Camera camera, Vector2 screenCoords);
        void ExecuteTouchEmulationEvents(Vector2 screenCoords);
        void Drag(Vector2 screenCoords);
        void DragStart(Vector2 screenCoords);
        void DragEnd(Vector2 screenCoords);
    }
}