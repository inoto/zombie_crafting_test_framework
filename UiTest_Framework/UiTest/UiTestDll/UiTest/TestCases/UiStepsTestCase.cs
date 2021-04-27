using System.Collections;
using System.Collections.Generic;
using System.IO;
using Assets.UiTest.Context;
using Assets.UiTest.TestSteps;
using UnityEngine;

namespace Assets.UiTest.Runner
{
    public abstract class UiStepsTestCase : IUiTestCase
    {
        private IUiTestStepBase _currenStep;
        public Steps Steps;
        public Commands Commands;
        public IUiTestContext Context;
        public ICheats Cheats;

        public IEnumerator Run(IUiTestContext context)
        {
            Steps = new Steps(context);
            Context = context;
            Commands=context.Commands;
            Cheats = context.Cheats;
            
            var items = Condition();
            while (items.MoveNext())
            {
                _currenStep = items.Current;
                yield return _currenStep.RunStep();
                if (_currenStep.CurrentState == TestStepState.Fail)
                {
                    yield break;
                }
            }
        }

        public void Stop()
        {
            if (_currenStep != null) _currenStep.Stop();
        }
       
        protected abstract IEnumerator<IUiTestStepBase> Condition();
    }
}