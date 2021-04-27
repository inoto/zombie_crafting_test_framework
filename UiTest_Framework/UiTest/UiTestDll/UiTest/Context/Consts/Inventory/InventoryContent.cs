namespace Assets.UiTest.Context.Consts
{
    public class InventoryContent
    {
        public static readonly string Id = "inventory";
        public readonly StringParam Dialog = new StringParam("dialog", Id);
        public readonly StringParam InventoryCount = new StringParam("inventory_count", Id);
        public readonly StringParam WorkbenchProgressBar = new StringParam("workbench_progress_bar", Id);
    }
}