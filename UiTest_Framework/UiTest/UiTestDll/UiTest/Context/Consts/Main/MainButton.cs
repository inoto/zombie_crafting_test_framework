namespace Assets.UiTest.Context.Consts
{
    public class MainButton
    {
        public static readonly string Id = "main";
        public readonly StringParam Use = new StringParam("use", Id);
        public readonly StringParam Inventory = new StringParam("inventory", Id);
    }
}