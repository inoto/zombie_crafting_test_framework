using Assets.UiTest.Results;

namespace UiTest.UiTest.Results
{
    public class AndCheckerResult : ICommandResult
    {
        public int Tick { get; private set; }

        public AndCheckerResult(int tick)
        {
            Tick = tick;
        }
    }
}