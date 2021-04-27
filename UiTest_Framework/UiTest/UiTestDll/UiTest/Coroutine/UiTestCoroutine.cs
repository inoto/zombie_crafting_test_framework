using System;
using System.Collections;
using System.Collections.Generic;

namespace UiTest.UiTest.Coroutine
{
    public class UiTestCoroutine : ITestRoutine
    {
        private Stack<IEnumerator> _tests = new Stack<IEnumerator>();
        private IStatus _currentStatus;

        public UiTestCoroutine(IEnumerator routine)
        {
            _tests.Push(routine);
            _currentStatus = Status.Running;
        }

        public IStatus Run()
        {
            if (!_currentStatus.IsRunning) return _currentStatus;

            if (_tests.Count != 0)
            {
                var test = _tests.Peek();
                if (test.MoveNext())
                {
                    if (test.Current is IEnumerator)
                    {
                        _tests.Push((IEnumerator) test.Current);
                    }
                }
                else
                {
                    _tests.Pop();
                }

                if (_currentStatus.IsRunning)
                    _currentStatus = Status.Running;
            }
            else
            {
                if (_currentStatus.IsRunning)
                    _currentStatus = Status.Complete;
            }

            return _currentStatus;

        }

        public void Stop()
        {
            _currentStatus = Status.Stop;
        }
    }
}