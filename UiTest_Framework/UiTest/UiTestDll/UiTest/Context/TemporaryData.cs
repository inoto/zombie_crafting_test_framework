using System;
using System.Collections.Generic;

namespace Assets.UiTest.Context
{
    public class TemporaryData : ITemporaryData
    {
        private Dictionary<string, object> _data = new Dictionary<string, object>();

        public void Set(string key, object value)
        {
            _data[key] = value;
        }

        public T Get<T>(string key)
        {
            return (T)_data[key];
        }
    }
}