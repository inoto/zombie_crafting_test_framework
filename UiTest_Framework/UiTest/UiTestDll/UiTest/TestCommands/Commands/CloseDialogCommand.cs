using System;
using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context;
using Assets.UiTest.Results;

namespace Assets.UiTest.TestCommands
{
    public class CloseDialogCommand : IUiTestCommand<SimpleCommandResult>
    {
        private readonly IUiTestContext _context;
        private readonly string _buttonCloseId;

        public CloseDialogCommand(IUiTestContext context, string buttonCloseId)
        {
            _context = context;
            _buttonCloseId = buttonCloseId;
        }
        public IEnumerator Run()
        {
            _context.GetButtonsGroup(_buttonCloseId).GetButton("close").Use();
            yield break;
            
        }

        public SimpleCommandResult GetResult()
        {
            return new SimpleCommandResult(true);
        }
    }
}