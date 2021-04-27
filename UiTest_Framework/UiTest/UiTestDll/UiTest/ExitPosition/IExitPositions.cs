using System.Collections.Generic;
using UnityEngine;

namespace Assets.UiTest.ExitPosition
{
    public interface IExitPositions
    {
        Vector3 NearestExitPoint(string locationId, Vector3 playerPosition);
        Vector3 NearestEntrancePoint(string locationId, Vector3 playerPosition);
        List<Vector3> ExitPoints(string locationId);
        List<Vector3> EntrancePoints(string locationId);
    }
}