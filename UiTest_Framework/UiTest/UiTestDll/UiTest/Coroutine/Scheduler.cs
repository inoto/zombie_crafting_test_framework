using System.Collections;
using System.Collections.Generic;

namespace UiTest.UiTest.Coroutine
{
    public class Scheduler : ITestScheduler
    {
        private HashSet<ITestRoutine> _routines = new HashSet<ITestRoutine>();
        private Queue<ITestRoutine> _remove = new Queue<ITestRoutine>();
        private Queue<ITestRoutine> _add = new Queue<ITestRoutine>();

        public ITestRoutine StartCoroutine(IEnumerator routine)
        {
            var coroutine = new UiTestCoroutine(routine);
            _add.Enqueue(coroutine);
            return coroutine;
        }

        public void Update()
        {
            while (_add.Count > 0)
            {
                _routines.Add(_add.Dequeue());
            }
            
            foreach (var testRoutine in _routines)
            {
                var status = testRoutine.Run();
                if (!status.IsRunning)
                {
                    _remove.Enqueue(testRoutine);
                }
            }

            while (_remove.Count > 0)
            {
                _routines.Remove(_remove.Dequeue());
            }
        }

        public void Remove(ITestRoutine routine)
        {
            if(_routines.Contains(routine))
                routine.Stop();
        }
    }
}