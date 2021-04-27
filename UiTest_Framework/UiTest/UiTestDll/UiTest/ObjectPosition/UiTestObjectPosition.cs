using System.Collections.Generic;
using Assets.UiTest.ExitPosition;
using Framework.Core.Value;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.UiTest.ObjectPosition
{
    public class UiTestObjectPosition : IUiTestObjectPosition
    {
        private readonly IValue _objectPosition;
        private Dictionary<string, UiTestObjectPositionData> _data;

        public UiTestObjectPosition(IValue objectPosition)
        {
            _objectPosition = objectPosition;
            _data= new Dictionary<string, UiTestObjectPositionData>();

            foreach (var objects in _objectPosition.AsDictionary())
            {
                _data[objects.Key]= new UiTestObjectPositionData(objects.Value, objects.Key);   
            }
        }

        public Vector3 GetObjectPosition(string location, string objectName)
        {
            return _data[location].Position[objectName];
        }
    }
}