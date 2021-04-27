using Assets.UiTest.Results;

namespace UiTest.UiTest.Results
{
    public class OrCheckResult : ICommandResult
    {
        public int Index { get; private set; }
        public int Tick { get; private set; }

        public OrCheckResult(int index, int tick)
        {
            Index = index;
            Tick = tick;
        }
    }
}