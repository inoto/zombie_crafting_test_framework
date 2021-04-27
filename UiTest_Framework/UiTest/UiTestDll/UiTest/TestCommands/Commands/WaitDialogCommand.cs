using System;
using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;
using UnityEngine;
using UnityEngine.Collections;

namespace Assets.UiTest.TestCommands
{
   
    public class WaitDialogCommand : IUiTestCommand<WaitItemResult>
    {
        private TimeSpan _count;
        private WaitItemResult _result;
        private readonly IUiTestContext _context;
        private readonly StringParam _dialog;
        private readonly bool _active;

        public WaitDialogCommand(IUiTestContext context, StringParam dialog, bool active)
        {
            _active = active;
            _context = context;
            _dialog = dialog;
        }

        private IEnumerator Wait()
        {
            _context.Rebuild(new List<string>{"start"});
            var dialogGo = _context.GetButtonsGroup(_dialog.Screen).GetContent(_dialog.Item).GetGO();
            if (_active)
            {
                var startTime = DateTime.Now;
                while (!dialogGo.activeInHierarchy)
                {
                    yield return _context.WaitEndFrame;
                }
            }
            else
            {
                var startTime = DateTime.Now;
                while (dialogGo.activeInHierarchy)
                {
                    yield return _context.WaitEndFrame;

                }

                var endTime = DateTime.Now;
                _count = endTime - startTime;
            }
            _context.Rebuild(new List<string>{"main","inventory"});
        }

        public IEnumerator Run()
        {
           yield return Wait();
            yield break;
        }

        public WaitItemResult GetResult()
        {
            _result = new WaitItemResult(_count);
            return _result;
        }
        
        
    }
}