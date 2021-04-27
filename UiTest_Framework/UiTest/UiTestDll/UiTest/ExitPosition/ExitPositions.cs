using System.Collections.Generic;
using Assets.UiTest.Context;
using Framework.Core.Value;
using UnityEngine;

namespace Assets.UiTest.ExitPosition
{
    public class ExitPositions : IExitPositions
    {
        private readonly IValue _exitPosition;
        private Dictionary<string, ExitPositionData> _data; 

        public ExitPositions(IValue exitPosition)
        {
            _exitPosition = exitPosition;
            _data= new Dictionary<string, ExitPositionData>();
            

            foreach (var pos in _exitPosition.AsDictionary())
            {
              _data[pos.Key]= new ExitPositionData(pos.Value, pos.Key);   
            }
        }

        private Vector3 GetNearestPoint(List<Vector3> points, Vector3 playerPosition)
        {
            var distance = float.PositiveInfinity;
            var nearPoint = new Vector3();
            foreach (var point in points)
            {

                var pointDistance = (playerPosition - point).magnitude;
                if (pointDistance<distance)
                {
                    distance = pointDistance;
                    nearPoint = point;
                }
            }
            return nearPoint;
        }

        public Vector3 NearestExitPoint(string locationId, Vector3 playerPosition)
        {
            return GetNearestPoint(_data[locationId].Exit, playerPosition);
        }

        public List<Vector3> ExitPoints(string locationId)
        {
            return _data[locationId].Exit;
        }
        
        public List<Vector3> EntrancePoints(string locationId)
        {
            return _data[locationId].Entrance;
        }

        public Vector3 NearestEntrancePoint(string locationId, Vector3 playerPosition)
        {
            return GetNearestPoint(_data[locationId].Entrance, playerPosition);
        }
    }
}