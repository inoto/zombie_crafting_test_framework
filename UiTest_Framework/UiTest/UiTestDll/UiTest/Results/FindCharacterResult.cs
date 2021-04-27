using Assets.UiTest.TestCommands;
using UnityEngine;

namespace Assets.UiTest.Results
{
    public class FindCharacterResult : ICommandResult
    {
        public GameObject CharGo { get; private set; }

        public FindCharacterResult(GameObject charGo)
        {
            CharGo = charGo;
        }
    }
}