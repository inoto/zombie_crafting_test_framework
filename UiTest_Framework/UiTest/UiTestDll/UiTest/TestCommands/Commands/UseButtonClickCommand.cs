using System;
using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Buttons;
using Assets.UiTest.Context;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;

namespace Assets.UiTest.TestCommands
{
    public class UseButtonClickCommand : IUiTestCommand<SimpleCommandResult>
    {
        protected readonly IUiTestContext Context;
        private readonly string _key;
        private readonly string _button;

        public UseButtonClickCommand(IUiTestContext context, string key, string button)
        {
            Context = context;
            _key = key;
            _button = button;
        }

        public IEnumerator Run()
        {
            if (_key=="main" && _button=="use")
            {
                Context.Main.GetButton<IUiUpDownTestButton>(_button).Down();
                yield return Context.WaitEndFrame;
                Context.Main.GetButton<IUiUpDownTestButton>(_button).Up();
            }
            else
            {
                
            Context.GetButtonsGroup(_key).GetButton(_button).Use();
            }
            
        }

        public SimpleCommandResult GetResult()
        {
            return new SimpleCommandResult(true);
        }

        
    }
}