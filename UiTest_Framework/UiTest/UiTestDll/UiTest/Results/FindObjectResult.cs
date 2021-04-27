using System;
using Assets.UiTest.TestCommands;
using UnityEngine;

namespace Assets.UiTest.Results
{
    public class FindObjectResult : ICommandResult
    {
        public GameObject FindGo { get; private set; }
        public Vector3 Position { get; private set;}
        public bool CheckNull { get; private set;}

        public FindObjectResult(GameObject findGo, Vector3 position, bool checkNull)
        {
            FindGo = findGo;
            Position = position;
            CheckNull = checkNull;
        }
    }
}