﻿using System;
using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context;
using Assets.UiTest.Results;
using UiTest.UiTest.Coroutine;
using UiTest.UiTest.Shop;
using UnityEngine;

namespace Assets.UiTest.TestSteps
{
    public abstract class UiTestStepBase : IUiTestStepBase
    {
        public static void SetContext(IUiTestContext context)
        {
            Context = context;
        }
        public TestStepState CurrentState { get; private set; }
        public abstract string Id { get; }
        public virtual double TimeOut => 300;

        protected static IUiTestContext Context;
        private ITestRoutine _coroutine;
        protected readonly ICheats Cheats;
        protected readonly Commands Commands;

        private DateTime _startTime;
        

        protected UiTestStepBase()
        {
            Cheats = Context.Cheats;
            Commands = Context.Commands;
            CurrentState = TestStepState.None;
            
        }

        protected virtual Dictionary<string, string> GetArgs()
        {
            return new Dictionary<string, string>();
        }

        public void Run()
        {
            CurrentState = TestStepState.Progress;
            _coroutine = Context.Scheduler.StartCoroutine(OnRunStep());
        }

        private IEnumerator OnRunStep()
        {
            yield return OnRun();
            Context.SendStepArgs(GetArgs());
            if (CurrentState == TestStepState.Progress)
            {
                Pass();
            }
        }

        public void Stop()
        {
            if (_coroutine != null) Context.Scheduler.Remove(_coroutine);
            CurrentState = TestStepState.Stop;
        }

        protected abstract IEnumerator OnRun();

        protected void Fail(string assert)
        {
            var endTime = DateTime.UtcNow;
            Context.SendCommandReport(Id, _startTime, endTime, CurrentState.ToString());
            Context.FailScenario(assert);
            if (_coroutine != null) Context.Scheduler.Remove(_coroutine);
            CurrentState = TestStepState.Fail;
            string channelStr = "<color=#FF0F00>[FAIL]</color> "+"Step: "+Id+" - " + assert;
            Debug.Log(channelStr);
        }

        private void Pass()
        {
            CurrentState = TestStepState.Done;
            string channelStr = "<color=#FFFFFF>[DONE]</color> "+"Step: "+Id;
            Debug.Log(channelStr);
        }
        
        public IEnumerator RunStep()
        {
            _startTime = DateTime.UtcNow;
            Run();
            while (CurrentState == TestStepState.Progress)
            {
                yield return Context.WaitEndFrame;
                var failTime = DateTime.UtcNow;
                var duration = failTime - _startTime;
                if (duration.TotalSeconds>=TimeOut)
                {
                    yield return Commands.ScreenshotCommand(new ResultData<SimpleCommandResult>());
                    Fail("Time out");
                }
            }
            
            if (CurrentState == TestStepState.Done)
            {
                var endTime = DateTime.UtcNow;
                Context.SendCommandReport(Id, _startTime, endTime, CurrentState.ToString());
            }
        }
    }
}