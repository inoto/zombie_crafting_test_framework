namespace Assets.UiTest.Context.Consts
{
    public class InventoryCell
    {
        public static readonly string Id = "inventory";
        public readonly StringParam Backpack = new StringParam("backpack", Id);
        public readonly StringParam Pockets = new StringParam("pockets", Id);
        public readonly StringParam WorkbenchRow = new StringParam("workbench_row", Id);
        public readonly StringParam WorkbenchResult = new StringParam("workbench_result", Id);
    }
}
