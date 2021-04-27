using System;
using System.Collections.Generic;
using Assets.UiTest.Buttons;
using Framework.Core.Value;
using UnityEngine;

namespace Assets.UiTest.Cells
{
    public class UiTestCells : IUiTestCells
    {
        private readonly Dictionary<string, GameObject> _names;
        private int _startIndex;
        private string _path;
        private string _format;
        private string _type;
        private string _property;

        public UiTestCells(IValue config, Dictionary<string, GameObject> names)
        {
            _names = names;
            _startIndex = config["start_index"].AsInt();
            _format = config["format"].AsString();
            _path = config["path"].AsString();
            _type = config["type"].AsString();
            _property = config["property"].AsString();
        }

        public void ClickCell(int index)
        {
            var path = "";
            switch (_property)
            {
                case "parenthesis":
                    path = GetCellIndexPath(index);
                    break;
                case "low_line":
                    path = GetItemIndexPath(index);
                    break;
            }
            var go = _names[path];
            IUiTestButton button = null;
            switch (_type)
            {
                case "up_down":
                    button = new UiTestUpDownButton(go);
                    break;
                case "button":
                    button = new UiTestButton(go);
                    break;
                case "pointer_button":
                    button = new UiTestPointerButton(go);
                    break;
                case "double_click":
                    button = new UiTestDoubleClick(go);
                    break;
            }
            button?.Use();
        }

        public void ClickCellDown(int index)
        {
            var path = GetItemIndexPath(index);
            var go = _names[path];
            var button = new UiTestUpDownButton(go);
            button.Down();
        }
        public void ClickCellUp(int index)
        {
            var path = GetCellIndexPath(index);
            var go = _names[path];
            var button = new UiTestUpDownButton(go);
            button.Up();
        }

        public void DoubleClickCell(int index)
        {
            var path = GetCellIndexPath(index);
            var go = _names[path];
            var button = new UiTestDoubleClick(go);
            button.Use();
        }

        public GameObject GetCell(int index)
        {
            var path = "";
            GameObject go = null;
            if (_startIndex==0)
            {
                path = GetCellIndexPath(index);
            }
            else
            {
                path = GetItemIndexPath(index);
            }
//костыль для конфига
              _names.TryGetValue(path, out go);
           
            return go;
        }

        public string GetCellIndexPath(int index)
        {
            if (index==0)
            {
                return string.Format(_format, _path,"");
            }
            else
            {

                var indexStr = " (" + index.ToString()+")";
                return string.Format(_format, _path, indexStr);
            }
        }
        
        public string GetItemIndexPath(int index)
        {
          return string.Format(_format, _path, index.ToString());
        }
    }
    
}