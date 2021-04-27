namespace Assets.UiTest.Context.Consts
{
    public class InventoryButton
    {
        public static readonly string Id = "inventory";

        public readonly StringParam Delete = new StringParam("delete", Id);
        public readonly StringParam Skip = new StringParam("skip", Id);
        public readonly StringParam Close = new StringParam("close", Id);
    }
}