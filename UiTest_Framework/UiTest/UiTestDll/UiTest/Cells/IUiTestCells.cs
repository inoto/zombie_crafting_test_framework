using UnityEngine;

namespace Assets.UiTest.Cells
{
    public interface IUiTestCells
    {
        void ClickCell(int index);
        void DoubleClickCell(int index);
        GameObject GetCell(int index);
        void ClickCellDown(int index);
        void ClickCellUp(int index);
    }
}