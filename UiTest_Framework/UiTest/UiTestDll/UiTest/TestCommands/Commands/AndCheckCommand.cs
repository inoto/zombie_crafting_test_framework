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
    public class AndCheckCommand : IUiTestCommand<AndCheckerResult>
    
    {
        private readonly IUiTestContext _context;
        private readonly List<IUiTestChecker> _checks;
        private static int _tick = 0;

        public AndCheckCommand(IUiTestContext context, List<IUiTestChecker> checks)
        {
            _context = context;
            _checks = checks;
        }
        public IEnumerator Run()
        {
            
            bool valueBase = true;
            while (valueBase)
            {
                var valueTemp = true;
                foreach (var check in _checks)
                {
                    valueTemp = valueTemp && check.Check();
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

        public AndCheckerResult GetResult()
        {
            return new AndCheckerResult(_tick);
        }
    }
}