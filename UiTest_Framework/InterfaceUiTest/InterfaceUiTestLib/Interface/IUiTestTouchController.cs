using UnityEngine;


    public interface IUiTestTouchController
    {
        void RemoveEmulatedTouch();
        void RemoveGesture(int v, Vector2 startPosition, Vector2 position, Vector2 swipeVector);
        void SetEmulatedTouch(Touch emulatedTouch);
        void SimpleTap(int v, Vector2 startPosition, Vector2 position, Vector2 swipeVector);
        void Swipe(int v, Vector2 startPosition, Vector2 position, Vector2 swipeVector);
        void SwipeEnd(int v, Vector2 startPosition, Vector2 position, Vector2 swipeVector);
        void SwipeStart(int v, Vector2 startPosition, Vector2 position, Vector2 swipeVector);
    }
