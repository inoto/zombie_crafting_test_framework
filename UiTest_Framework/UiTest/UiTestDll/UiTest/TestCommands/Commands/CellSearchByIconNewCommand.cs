using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.UiTest.Context;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;
using Assets.UiTest.TestCommands;
using UnityEngine;

namespace UiTest
{
	public class CellSearchByIconNewCommand : IUiTestCommand<CellSearchByIconResult>
	{
		private readonly IUiTestContext _context;
		private readonly string _iconId;
		private readonly int _countItem;
		private readonly HashSet<string> _inventoryId;
		private CellSearchByIconResult _result;

		public CellSearchByIconNewCommand(IUiTestContext context, string iconId, int countItem, HashSet<string> inventoryId)
		{
			_context = context;
			_iconId = iconId;
			_countItem = countItem;
			_inventoryId = inventoryId;
		}
		
		public CellSearchByIconResult GetResult()
		{
			return _result;
		}

		public IEnumerator Run()
		{
			HashSet<GameObject> hashGo = new HashSet<GameObject>();
			foreach (var id in _inventoryId)
			{
				hashGo.Add(_context.Inventory.GetContent(id).GetGO());
			}

			var foundCell = FindCell(hashGo);
			// if (foundCell == null)
			// {
			// 	_context.SendDebugLog($"foundCell is null");
			// }
			// else
			// {
			// 	_context.SendDebugLog($"foundCell name: {foundCell.name}");
			// }
			int cellIndex = 0;
			string inventoryId = "";
			if (foundCell != null)
			{
				cellIndex = _context.GetCellIndex(foundCell);
				inventoryId = _context.GetCellInventory(foundCell);
			}

			_result = new CellSearchByIconResult(inventoryId, cellIndex, foundCell);
			yield break;
		}

		private GameObject FindCell(HashSet<GameObject> hashGo)
		{
			foreach (var invGo in hashGo)
			{
				_context.SendDebugLog($"invGO name: {invGo.name}");
				for (int i = 0; i < invGo.transform.childCount; i++)
				{
					foreach (var spriteName in _context.Sprite.GetSprite(_iconId))
					{
						var cell = invGo.transform.GetChild(i).gameObject;
						var iconName = _context.GetCellIconName(cell);
						if (iconName == spriteName)
						{
							return cell;
						}
					}
				}
			}

			return null;
		}
		
	}
}