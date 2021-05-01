using System;
using System.Collections.Generic;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.ExitPosition;
using Assets.UiTest.Sprite;
using Assets.UiTest.TouchInput;
using Assets.UiTest.UiTestButtonsGroup;
using Framework.Core.Value;
using UiTest.UiTest.Coroutine;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.UiTest.Context
{
    public interface IUiTestContext
    {
        event Action OnErrorDetect;
        IUiTestTouchInput TestTouchInput { get; }
        ITemporaryData TemporaryData { get; }
        IButtonsGroup Main { get; }
        IButtonsGroup Inventory { get; }
        ICheats Cheats { get; }
        IUiTestSprite Sprite { get;}
        Commands Commands { get; }
        WaitForEndOfFrame WaitEndFrame { get; }
        IGameManager GameManager { get; }
        ITestScheduler Scheduler { get; set; }
        Vector3 GetPlayerPosition();
        bool Vector3Equal(Vector3 first, Vector3 second, float p);
        IButtonsGroup GetButtonsGroup(string key);
        string GetCellInventory(GameObject cell);
        int GetCellIndex(GameObject cell);
        string GetCellIconName(GameObject cell);
        void CreatFilePath(string path);
        void SendDebugLog(string text);
        void SendCommandLog(string commandId, DateTime startTime, DateTime endTime,Dictionary<string,string> comp, bool screenshoots = false);
        void SendAllLogs();
        void ExceptionLogs();
        Vector3 GetObjectCordConfig(string location, string objectName);
        
        void FailScenario(string assert);
        void SendCommandReport(string id, DateTime startTime, DateTime endTime, string state);
        void SendStepArgs(Dictionary<string,string> args);
        void Rebuild(List<string> keys);
        float ProgressBarAmount();
    }
}
