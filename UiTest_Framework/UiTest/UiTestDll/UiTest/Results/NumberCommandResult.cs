using Assets.UiTest.Results;

namespace UiTest.UiTest.Results
{
    public class NumberCommandResult : ICommandResult
    {
        public int Number { get; private set; }

        public NumberCommandResult(int number)
        {
            Number = number;
        }
    }
}