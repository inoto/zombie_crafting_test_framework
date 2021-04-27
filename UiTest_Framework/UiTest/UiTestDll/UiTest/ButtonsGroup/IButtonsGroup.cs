using System.Collections.Generic;
using Assets.UiTest.Buttons;
using Assets.UiTest.Cells;
using Assets.UiTest.ContentGroup;
using Framework.Core.Value;
using UnityEngine;

namespace Assets.UiTest.UiTestButtonsGroup
{
    public interface IButtonsGroup
    {
        IUiTestButton  GetButton(string key);
        T GetButton<T>(string key);
        IUiTestCells GetCells(string key);
        IUiTestContent GetContent(string key);
        Dictionary<string, GameObject> GetDictionaryButtonGo(string scene);
        Dictionary<string, IValue> GetDictionaryCells();
        Dictionary<string, GameObject> GetDictionaryCellGo(string scene);
    }
}