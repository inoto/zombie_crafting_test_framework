using System;
using System.Collections.Generic;
using System.Linq;
using Framework.Core.Value;

namespace Assets.UiTest.Context
{
    public class Scenes : IScenes
    {
        private Dictionary<string, List<string>> _data = new Dictionary<string, List<string>>();

        public Scenes(IValue scenes)
        {
            foreach (var scene in scenes.AsDictionary())
            {
                var asList = scene.Value.AsList();
                var list = new List<string>();
                foreach (var value in asList)
                {
                    list.Add(value.AsString());
                }

                _data[scene.Key] = list;
            }
        }

        public List<string> GetScreens(string scene)
        {
            return _data.TryGetValue(scene, out var value) ? value : new List<string>();
        }
    }
}