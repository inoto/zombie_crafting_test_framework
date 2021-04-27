namespace Assets.UiTest.Results
{
    public class CheckResult : ICommandResult
    {
        public bool Check { get; private set; }

        public CheckResult(bool check)
        {
            Check = check;
        }
    }
}