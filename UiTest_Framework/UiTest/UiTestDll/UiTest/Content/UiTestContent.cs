using System;
using System.Collections.Generic;
using Assets.UiTest.ContentGroup;
using Framework.Core.Value;
using UnityEngine;

namespace Assets.UiTest.Content
{
    public class UiTestContent : IUiTestContent
    {
        private readonly Dictionary<string, GameObject> _names;
        private string _path;

        public UiTestContent(IValue config, Dictionary<string, GameObject> names)
        {
            _names = names;
            _path = config["path"].AsString();
        }

        public GameObject GetGO()
        {
            GameObject go = null;
            try
            {
                go=_names[_path];

            }
            catch (Exception)
            {
                Debug.Log(_path);
                throw; 
            }
            return go;
        }
    }
}