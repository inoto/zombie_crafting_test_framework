using System;
using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context;
using Assets.UiTest.Results;
using UnityEngine;

namespace Assets.UiTest.TestCommands
{
    public class WaitForSecondsCommand : IUiTestCommand<SimpleCommandResult>
    {
        private readonly float _seconds;
        private readonly IUiTestContext _context;

        

        public WaitForSecondsCommand(IUiTestContext context,float seconds)
        {
            _context = context;
            _seconds = seconds;
        }

        public IEnumerator Run()
        {
            yield return new WaitForSecond(_seconds);
        }

        public SimpleCommandResult GetResult()
        {
            return new SimpleCommandResult(true);
        }
        
        
    }
}