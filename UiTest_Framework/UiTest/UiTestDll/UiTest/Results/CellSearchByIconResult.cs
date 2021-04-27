using System;
using Assets.UiTest.Results;
using UnityEngine;

namespace Assets.UiTest.Results
{
    public class CellSearchByIconResult : ICommandResult
    {
        public string InventoryId { get; private set; }
        public int Cell { get; private set; }
        public GameObject CellGo { get; private set; }

        public CellSearchByIconResult(string inventoryId, int cell, GameObject cellGO)
        {
            InventoryId = inventoryId;
            Cell = cell;
            CellGo = cellGO;
        }
    }
}