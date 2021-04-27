using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;
using UnityEngine.UI;

namespace Assets.UiTest.TestSteps
{
	public class FindItemStep : UiTestStepBase
	{
		public override string Id { get; }
		public override double TimeOut { get; }
		protected override Dictionary<string, string> GetArgs()
		{
			return new Dictionary<string, string>();
		}

		protected override IEnumerator OnRun()
		{
			
			
			var result = new ResultData<CellSearchByIconResult>();
			yield return Context.Commands.CellSearchByIconNewCommand("tool_axe", 1,
				new HashSet<string>() {"inventory_count", "backpack_count"}, result);
			Context.SendDebugLog($"result go name: {result.GetData().CellGo.name}");
			Context.SendDebugLog($"result inventoryId: {result.GetData().InventoryId}");
			
			// var cell = Context.Inventory.GetCells("pockets").GetCell(1);
			// var images = cell.GetComponentsInChildren<Image>();
			// foreach (var image in images)
			// {
			// 	Context.SendDebugLog($"image sprite name: {image.sprite.name}");
			// }
			//
			// cell = Context.Inventory.GetCells("pockets").GetCell(3);
			// images = cell.GetComponentsInChildren<Image>();
			// foreach (var image in images)
			// {
			// 	Context.SendDebugLog($"image sprite name: {image.sprite.name}");
			// }
			//
			// cell = Context.Inventory.GetCells("pockets").GetCell(4);
			// images = cell.GetComponentsInChildren<Image>();
			// foreach (var image in images)
			// {
			// 	Context.SendDebugLog($"image sprite name: {image.sprite.name}");
			// }
			//
			// Context.Cheats.GetWoodPlank(3);
			// cell = Context.Inventory.GetCells("pockets").GetCell(5);
			// images = cell.GetComponentsInChildren<Image>();
			// foreach (var image in images)
			// {
			// 	Context.SendDebugLog($"image sprite name: {image.sprite.name}");
			// }
			//
			//
			// var sprites = Context.Sprite.GetSprite("firearms");
			// foreach (var sprite in sprites)
			// {
			// 	Context.SendDebugLog($"sprite: {sprite}");
			// }
			// var result = new ResultData<CellSearchByIconResult>();
			// yield return Context.Commands.CellSearchByIconCommand("wpn_axe", "1", sprites, result);
   //          
			// Context.SendDebugLog($"axe go name: {result.GetData().CellGo}");
			// Context.SendDebugLog($"axe inventory id: {result.GetData().InventoryId}");
			// Context.SendDebugLog($"axe go cell: {result.GetData().Cell}");
		}
	}
}