using System;
using System.Collections;

namespace Assets.UiTest.Context
{
    public class WaitForSecond : IEnumerator
    {
        private readonly float _duration;
        private DateTime _currentTime;

        public WaitForSecond(float duration)
        {
            _duration = duration;
            _currentTime = DateTime.UtcNow;
            _currentTime= _currentTime.AddSeconds(_duration);
        }
        public bool MoveNext()
        {
            return _currentTime > DateTime.UtcNow;
        }

        public void Reset()
        {
            _currentTime = DateTime.UtcNow;
            _currentTime= _currentTime.AddSeconds(_duration);
        }

        public object Current => null;
    }
    
}