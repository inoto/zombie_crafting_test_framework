using System;
using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context;
using Assets.UiTest.Results;
using UnityEngine;

namespace Assets.UiTest.TestCommands
{
    public class ScreenshotCommand : IUiTestCommand<SimpleCommandResult>
    {
        private readonly IUiTestContext _context;

        public ScreenshotCommand(IUiTestContext context)
        {
            _context = context;
        }
        public SimpleCommandResult GetResult()
        {
            return new SimpleCommandResult(true);
        }

        public IEnumerator Run()
        {
            yield return _context.WaitEndFrame;
        }
        
        
    }
}