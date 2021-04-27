namespace Assets.UiTest.Results
{
    public class SimpleCommandResult : ICommandResult
    {
        public bool IsDone { get; private set; }

        public SimpleCommandResult(bool result)
        {
            IsDone = result;
        }
    }
}