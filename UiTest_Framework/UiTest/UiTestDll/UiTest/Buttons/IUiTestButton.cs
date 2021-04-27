using UnityEngine;

namespace Assets.UiTest.Buttons
{
    public interface IUiTestButton
    {
        void Use();
        GameObject GetButtonGo();
    }
}