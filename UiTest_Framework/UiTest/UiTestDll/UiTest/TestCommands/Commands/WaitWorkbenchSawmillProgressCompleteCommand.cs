using System;
using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;
using UnityEngine;

namespace Assets.UiTest.TestCommands
{
    public class WaitWorkbenchSawmillProgressCompleteCommand : IUiTestCommand<WaitItemResult>
    {
        private readonly IUiTestContext _context;
        private float _waitTime;

        public WaitWorkbenchSawmillProgressCompleteCommand(IUiTestContext context)
        {
            _context = context;
            _waitTime = 0;
        }
        public IEnumerator Run()
        {
            yield return _context.WaitEndFrame;
            
			// _context.SendDebugLog($"прогресс: {_context.ProgressBarAmount()}");
			while (_context.ProgressBarAmount() < 0.99f)
			{
				_waitTime += Time.deltaTime;
				yield return null;
			}
			// _context.SendDebugLog($"прогресс занял примерно: {_waitTime}");
			
			yield return _context.WaitEndFrame;
            
            yield break;
        }

        public WaitItemResult GetResult()
        {
            return new WaitItemResult(TimeSpan.FromSeconds(_waitTime));
        }
    }
}