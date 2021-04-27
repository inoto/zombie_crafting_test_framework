using System.Collections.Generic;

namespace Assets.UiTest.Context
{
    public interface IScenes
    {
        List<string> GetScreens(string scene);
    }
}