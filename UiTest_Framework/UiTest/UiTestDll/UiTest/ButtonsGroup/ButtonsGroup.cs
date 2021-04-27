using System;
using System.Collections.Generic;
using Assets.UiTest.Buttons;
using Assets.UiTest.Cells;
using Assets.UiTest.Content;
using Assets.UiTest.ContentGroup;
using Framework.Core.Value;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.UiTest.UiTestButtonsGroup
{
    public class ButtonsGroup : IButtonsGroup
    {
        private Dictionary<string,IUiTestButton>_buttons=new Dictionary<string, IUiTestButton>();
        
        private Dictionary<string,IUiTestCells>_cells=new Dictionary<string, IUiTestCells>();
        private Dictionary<string, IUiTestContent> _content=new Dictionary<string, IUiTestContent>();

        public ButtonsGroup( IValue config , Dictionary<string, GameObject> names)
        {
            var buttons = config["buttons"];
            foreach (var item in buttons.AsDictionary())
            {
                GameObject go = null;
                var typeSearch = item.Value["type_search"].AsString();
                var path = item.Value["path"].AsString();
                switch (typeSearch)
                {
                    case "find_search":
                        go = GameObject.Find(path);
                        break;
                    case "cache_search":
                        try
                        {
                            go = names[path];
                        }
                        catch (Exception)
                        {
                            UnityEngine.Debug.Log("path=" +path);
                            throw;
                        }
                        break;
                }

                if (go == null)
                {
                    UnityEngine.Debug.Log("path=" +path);
                }

                var type = item.Value["type"].AsString();
                switch (type)
                {
                    case "up_down":
                        _buttons[item.Key] = new UiTestUpDownButton(go);
                        break;
                    case "button":
                        _buttons[item.Key] = new UiTestButton(go);
                        break;
                    case "pointer_button":
                        _buttons[item.Key] = new UiTestPointerButton(go);
                        break;
                    case "double_click":
                        _buttons[item.Key] = new UiTestDoubleClick(go);
                        break;
                 }
            }

            var cells = config["cells"];
            foreach (var cell in cells.AsDictionary())
            {
                _cells[cell.Key] = new UiTestCells(cell.Value,names);
            }

            var content = config["content"];
            foreach (var cont  in content.AsDictionary())
            {
                _content[cont.Key] = new UiTestContent(cont.Value,names);
            }
        }

        public IUiTestButton GetButton(string key)
        {
                return _buttons[key];
        }

        public T GetButton<T>(string key)
        {
            return (T)_buttons[key];
        }

        public IUiTestCells GetCells(string key)
        {
            return _cells[key];
        }
        
        public IUiTestContent GetContent(string key)
        {
            return _content[key];
        }

        public Dictionary<string, GameObject> GetDictionaryButtonGo(string scene)
        {
            var dictGo = new Dictionary<string,GameObject>();
            foreach (var button in _buttons)
            {
                dictGo.Add(button.Key,button.Value.GetButtonGo());
            }
            return dictGo;
        }

        public Dictionary<string, GameObject> GetDictionaryCellGo(string scene)
        {
            var dictGo = new Dictionary<string, GameObject>();
            switch (scene)
            {
                case "bunker":
                    foreach (var cell in _cells)
                    {
                        if (cell.Key == "lift_button")
                        {
                            var cellCount = cell.Value.GetCell(0).transform.parent.parent.childCount;
                            for (int i = 0; i < cellCount; i++)
                            {
                                if (cell.Value.GetCell(i))
                                {
                                    dictGo.Add(cell.Key + "_" + i, cell.Value.GetCell(i));
                                }
                            }
                        }
                    }

                    break;
                case "battle":
                    foreach (var cell in _cells)
                    {

                        if (cell.Value.GetCell(0))
                        {
                            var cellCount = cell.Value.GetCell(0).transform.parent.childCount;
                            for (int i = 0; i < cellCount; i++)
                            {
                                if (cell.Value.GetCell(i))
                                {
                                    dictGo.Add(cell.Key + "_" + i, cell.Value.GetCell(i));
                                }
                            }
                        }

                    }
                    break;
            }

            return dictGo;
        }

        public Dictionary<string, IValue> GetDictionaryCells()
        {
            var dictCells = new Dictionary<string, IValue>();

            foreach (var cell in _cells)
            {
                var dictCell = new Dictionary<string, IValue>();
                dictCells[cell.Key] = new DictionaryValue(dictCell);
            }

            return dictCells;

        }

    }
}