using System;
using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context;
using Assets.UiTest.Results;
using Framework.Core.Factories;
using UnityEngine;

namespace Assets.UiTest.TestCommands
{
    public class WaitItemActiveButtonCommand : IUiTestCommand<WaitItemResult>
    {
        private readonly IUiTestContext _context;
        private readonly string _button;
        private readonly string _buttonId;
        private TimeSpan _count ;
        private WaitItemResult _result;

        public WaitItemActiveButtonCommand(IUiTestContext context, string button, string buttonId)
        {
            _context = context;
            _button = button;
            _buttonId = buttonId;
        }

        private IEnumerator Wait()
        {
            GameObject buttonItem = null;
            if (_buttonId == "battle")
            {
                buttonItem = _context.Main.GetButton(_button).GetButtonGo();
                var canvasGroup = buttonItem.GetComponent<CanvasGroup>().alpha;
                var startTime = DateTime.Now;
                while (canvasGroup != 1f && buttonItem.activeInHierarchy)
                {
                    yield return _context.WaitEndFrame;
                    canvasGroup = buttonItem.GetComponent<CanvasGroup>().alpha;
                }

                var endTime = DateTime.Now;
                _count = endTime - startTime;
            }

            if (_buttonId == "inventory")
            {
                buttonItem = _context.Inventory.GetButton(_button).GetButtonGo();
                var startTime = DateTime.Now;
                while (!buttonItem.activeInHierarchy)
                {
                    yield return _context.WaitEndFrame;
                }
                var endTime = DateTime.Now;
                _count = endTime - startTime;
            }

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