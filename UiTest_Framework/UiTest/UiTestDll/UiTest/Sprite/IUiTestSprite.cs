using System.Collections.Generic;

namespace Assets.UiTest.Sprite
{
    public interface IUiTestSprite
    {
        HashSet<string> GetSprite(string spritesID);
    }
}