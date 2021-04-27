using Assets.UiTest.Results;

namespace Assets.UiTest.TestCommands
{
    public class ShopCommandResult : ICommandResult
    {
        public bool ShopObjectavailable { get; set; }
        public ShopCommandResult(bool shopObjectavailable)
        {
            ShopObjectavailable = shopObjectavailable;
        }

    }
}