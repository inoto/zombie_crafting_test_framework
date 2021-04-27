using System.Collections.Generic;
using Assets.UiTest.Context;
using Assets.UiTest.Runner;
using Framework.Core.Value;


public class UiTestShop: IUiTestShop
    {
        private Dictionary<string, UiTestShopObjects> _shopObject = new Dictionary<string, UiTestShopObjects>();

        public IUiTestShopObjects Packs
        {
            get { return _shopObject["packs"]; }
        }
        public IUiTestShopObjects Categories
        {
            get { return _shopObject["categories"]; }
        }
        public UiTestShop(IValue shopObject)
        {
            foreach (var objects in shopObject.AsDictionary())
            {
                _shopObject[objects.Key]= new UiTestShopObjects(objects.Value,objects.Key);
            }

        }
    }