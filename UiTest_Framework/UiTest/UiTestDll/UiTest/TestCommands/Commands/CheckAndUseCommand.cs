using System;
using System.Collections;
using Assets.UiTest.Context;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;
using Assets.UiTest.TestCommands;
using UiTest.UiTest.Checker;
using UnityEngine;

namespace UiTest.UiTest.TestCommands
{
    public class CheckAndUseCommand : IUiTestCommand<SimpleCommandResult>
    {
        private readonly IUiTestContext _context;
        private readonly Tuple<string,IUiTestChecker> _checker;
        private readonly bool _waitCheck;
        private readonly StringParam _button;
        private bool _result= false;

        public CheckAndUseCommand(IUiTestContext context, Tuple<string,IUiTestChecker>  checker, bool waitCheck, StringParam button)
        {
            _context = context;
            _checker = checker;
            _waitCheck = waitCheck;
            _button = button;
        }
        public SimpleCommandResult GetResult()
        {
          return new SimpleCommandResult(_result);
        }

        public IEnumerator Run()
        {
            _result = _checker.Item2.Check();
            if (_waitCheck)
            {
                while (_result)
                {
                    yield return _context.WaitEndFrame;
                    _result = _checker.Item2.Check();
                }
                yield return _context.Commands.UseButtonClickCommand(_button, new ResultData<SimpleCommandResult>());
            }
            else
            {
                if (_result)
                {
                    yield return _context.Commands.UseButtonClickCommand(_button, new ResultData<SimpleCommandResult>());
                }
            }
        }
    }
}