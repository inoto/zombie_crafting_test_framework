using Assets.UiTest.Context;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;
using UnityEngine;

namespace UiTest.UiTest.Checker.Player.Inventory
{
	public class IsAxeInInventoryChecker : IUiTestChecker
	{
		private readonly IUiTestContext _context;
		private GameObject _inventory;
		bool _result;

		public IsAxeInInventoryChecker(IUiTestContext context)
		{
			_context = context;
			_inventory = _context.Inventory.GetContent(Screens.Inventory.Content.InventoryCount.Item).GetGO();
			// var inventoryId = _context.Sprite.GetSprite("firearms");
			// var result = new ResultData<CellSearchByIconResult>();
			// _context.Commands.CellSearchByIconCommand("wpn_axe", "1", inventoryId, result);
		}
		
		public void Init()
		{
			throw new System.NotImplementedException();
		}

		public bool Check()
		{
			return _result;
		}
	}
}