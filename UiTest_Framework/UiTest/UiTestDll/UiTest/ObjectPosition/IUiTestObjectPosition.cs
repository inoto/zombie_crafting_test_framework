using UnityEngine;

namespace Assets.UiTest.ObjectPosition
{
    public interface IUiTestObjectPosition
    {
        Vector3 GetObjectPosition(string location, string objectName);
    }
}