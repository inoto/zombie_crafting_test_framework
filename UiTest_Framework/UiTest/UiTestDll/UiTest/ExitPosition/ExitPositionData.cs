using System;
using System.Collections.Generic;
using Framework.Core.Value;
using UnityEngine;

namespace Assets.UiTest.ExitPosition
{
    public class ExitPositionData
    {
        private readonly IValue _position;
        private readonly string _key;
        public List<Vector3> Exit { get; }
        public List<Vector3> Entrance { get; }

        public ExitPositionData(IValue position, string key)
        {
            _position = position;
            _key = key;
            Exit = new List<Vector3>();
            Entrance = new List<Vector3>();
            
            var exit = _position["exit"].AsList();
            var entry = _position["entrance"].AsList();
            foreach (var value in exit)
            {
                Exit.Add(new Vector3(value[0].AsFloat(), value[1].AsFloat(), value[2].AsFloat()));
            }

            foreach (var value in entry)
            {
                Entrance.Add(new Vector3(value[0].AsFloat(), value[1].AsFloat(), value[2].AsFloat()));
            }
        }
    }
}