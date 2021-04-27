using UnityEngine;

namespace Assets.UiTest.Results
{
    public class PositionResult : ICommandResult
    {
        public Vector3 Position { get; private set; }

        public PositionResult(Vector3 pos)
        {
            Position = pos;
        }
    }
}