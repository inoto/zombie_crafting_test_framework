using System.Collections.Generic;
using Framework.Core.Value;

namespace Assets.UiTest.Sprite
{
    public class UiTestSpriteData 
    {
        public HashSet<string> Sprite { get; }

        private readonly IValue _sprite;
        private readonly string _key;


        public UiTestSpriteData(IValue sprite, string key)
        {
            _sprite = sprite;
            _key = key;
            Sprite = new HashSet<string>();
            foreach (var item in _sprite["sprite"].AsList())
            {
                Sprite.Add(item.AsString());
            }

        }
    }
}