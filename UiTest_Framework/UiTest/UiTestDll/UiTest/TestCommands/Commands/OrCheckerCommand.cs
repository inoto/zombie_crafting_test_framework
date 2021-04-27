using System;
using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context;
using Assets.UiTest.Results;
using UiTest.UiTest.Checker;
using UiTest.UiTest.Results;
using UnityEngine;

namespace Assets.UiTest.TestCommands
{
    public class OrCheckerCommand : IUiTestCommand<OrCheckResult>
    {
        private readonly IUiTestContext _context;
        private readonly List<IUiTestChecker> _checks;
        private static int _index = 0;
        private static int _tick = 0;

        public OrCheckerCommand(IUiTestContext context, List<IUiTestChecker> checks)
        {
            _context = context;
            _checks = checks;
        }

        public IEnumerator Run()
        {
            bool valueBase = true;
            while (valueBase)
            {
                var valueTemp = false;

                for (int i = 0; i < _checks.Count; i++)
                {
                    valueTemp = valueTemp || _checks[i].Check();
                    if (valueTemp)
                    {
                        _index = i;
                        break;
                    }

                }

                if (valueTemp)
                {
                    valueBase = false;
                }
                else
                {
                    _tick++;
                    yield return _context.WaitEndFrame;
                }
            }
        }

        public OrCheckResult GetResult()
        {
            return new OrCheckResult(_index, _tick);
        }

        
    }
}