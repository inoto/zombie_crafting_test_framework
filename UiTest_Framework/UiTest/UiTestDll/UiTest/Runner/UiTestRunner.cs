using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Assets.UiTest.TestCommands;
using Assets.UiTest.Context;

using Framework.Core.Decoder;
using Framework.Core.Value;
using UiTest.UiTest.Coroutine;
using UnityEngine;

namespace Assets.UiTest.Runner
{
    public class UiTestRunner
    {
        private readonly IGameManager _gameManager;
        private readonly int _testNumber;
        private IUiTestContext _context;
        private IUiTestCases _testCases = new UiTestCases();
        private ITestRoutine _testCaseRoutine;
        private IUiTestCase _uiTestCase;

        public UiTestRunner( IGameManager gameManager, int testNumber, IUiTestContext context)
        {
            _gameManager = gameManager;
            _testNumber = testNumber;
            _context = context;
        }

        public void Setup(string path)
        {
            _context.CreatFilePath(path);
        }

        public void Run()
        {
            Run(_testNumber);
        }

        public void Run(int testcase)
        {
            Stop();
            _testCaseRoutine = _context.Scheduler.StartCoroutine(RunTestCase(testcase));
        }

        public void Stop()
        {
            if (_testCaseRoutine != null)
            {
                _context.Scheduler.Remove(_testCaseRoutine);
            }
        }

        private IEnumerator RunTestCase(int testNumber)
        {
            _context.ExceptionLogs();
            _context.OnErrorDetect += ContextOnOnErrorDetect;
            _uiTestCase = _testCases.GetTestCase(testNumber);
            yield return _uiTestCase.Run(_context);
            _context.OnErrorDetect -= ContextOnOnErrorDetect;
            _context.SendAllLogs();
            // Application.Quit();
        }

        private void ContextOnOnErrorDetect()
        {
            _context.OnErrorDetect -= ContextOnOnErrorDetect;
            _context.SendAllLogs();
            Stop();
            // Application.Quit();
        }
    }
}
