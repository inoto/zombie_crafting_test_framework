using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.UiTest.Context;
using Assets.UiTest.Results;
using UnityEngine;

namespace Assets.UiTest.TestCommands
{
    public class CellSearchByIconCommand : IUiTestCommand<CellSearchByIconResult>
    {
        private readonly IUiTestContext _context;
        private readonly string _iconId;
        private readonly string _countItem;
        private readonly HashSet<string> _inventoryId;
        private CellSearchByIconResult _result;

        public CellSearchByIconCommand(IUiTestContext context, string iconId, string countItem, HashSet<string> inventoryId)
        {
            _context = context;
            _iconId = iconId;
            _countItem = countItem;
            _inventoryId = inventoryId;
        }

        public IEnumerator Run()
        {
            var cellGo = CellSearchByIcon(_iconId, _countItem, _inventoryId);
            int cell = 0;
            string inventoryId = "";
            if (cellGo != null)
            {
                cell = _context.GetCellIndex(cellGo);
                inventoryId = _context.GetCellInventory(cellGo);
            }

            _result = new CellSearchByIconResult(inventoryId, cell, cellGo);
            yield break;
        }

        public GameObject CellSearchByIcon(string iconId, string countItem, HashSet<string> inventoryId)
        {
            HashSet<GameObject> hashGo = new HashSet<GameObject>();
            foreach (var id in inventoryId)
            {
                hashGo.Add(_context.Inventory.GetContent(id).GetGO());
            }
            return _context.Cheats.CellSearchByIcon(_context.Sprite.GetSprite(iconId), countItem, hashGo);
        }



        public CellSearchByIconResult GetResult()
        {
            return _result;
        }
    }
}