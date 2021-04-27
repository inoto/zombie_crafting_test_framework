using System.Collections.Generic;

namespace Assets.UiTest.Runner
{
    public static class NodeHelper
    {
        public static IDictionary<string, object> GetNode(this IDictionary<string, object> node, string key)
        {
            return (IDictionary<string, object>) node[key];
        }
        public static List<object> GetArray(this IDictionary<string, object> node, string key)
        {
            return (List<object>) node[key];
        }
        
        public static List<object> GetArray(this object node)
        {
            return (List<object>) node;
        }
        
        public static IDictionary<string, object> GetNode(this object node)
        {
            return (IDictionary<string, object>) node;
        }
    }
}