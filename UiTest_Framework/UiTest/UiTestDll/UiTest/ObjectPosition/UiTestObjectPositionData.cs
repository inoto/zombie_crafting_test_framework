using System.Collections.Generic;
using Framework.Core.Value;
using UnityEngine;

namespace Assets.UiTest.ObjectPosition
{
    internal class UiTestObjectPositionData
    {
        private readonly IValue _objectsPosition;
        private readonly string _sceneName;
        public Dictionary<string, Vector3> Position;
        public UiTestObjectPositionData(IValue objectsPosition, string sceneName)
        {
            _objectsPosition = objectsPosition;
            _sceneName = sceneName;
            Position = new Dictionary<string, Vector3>();

            foreach (var objects in objectsPosition.AsDictionary())
            {
                var cord = objects.Value;
                var objectsName = objects.Key;
                Position.Add(objectsName,new Vector3(cord[0].AsFloat(), cord[1].AsFloat(), cord[2].AsFloat()));
            }
        }
    }
}