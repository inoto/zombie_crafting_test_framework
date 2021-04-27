using System.Collections.Generic;
using Assets.UiTest.Context;
using Framework.Core.Value;


    public class UiTestShopObjects :IUiTestShopObjects
    {
        private Dictionary<string, string> _packs=new Dictionary<string, string>();
        private string _goName = "";
        
        public UiTestShopObjects(IValue objectsValue, string objectsKey)
        {
            var objects = objectsValue["object_name"];
            foreach (var packName in objects.AsDictionary())
            {
                _packs[packName.Key] = packName.Value["name"].AsString();
            }
            var go = objectsValue["game_object_name"];
            foreach (var goName in go.AsDictionary())
            {
                _goName = goName.Value.AsString();
            }
        }

        public string GetShopObjectName(string packId)
        {
            return _packs[packId];
        }

        public string GetShopGoName()
        {
            return _goName;
        }
    }
