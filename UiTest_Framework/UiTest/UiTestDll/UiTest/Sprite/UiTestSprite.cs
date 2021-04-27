using System.Collections.Generic;
using Framework.Core.Value;

namespace Assets.UiTest.Sprite
{
    public class UiTestSprite : IUiTestSprite
    {
        private readonly IValue _sprite;
        private Dictionary<string, UiTestSpriteData> _data;

        public UiTestSprite(IValue sprite)
        {
            _sprite = sprite;
            _data = new Dictionary<string, UiTestSpriteData>();

            foreach (var icon in _sprite.AsDictionary())
            {
                _data[icon.Key]=new UiTestSpriteData(icon.Value,icon.Key);
            }
        }

        public HashSet<string> GetSprite(string spritesID)
        {
            return _data[spritesID].Sprite;
        }
    }
}