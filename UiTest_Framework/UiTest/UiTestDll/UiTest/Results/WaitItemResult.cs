using System;

namespace Assets.UiTest.Results
{
    public class WaitItemResult : ICommandResult
    {
        public TimeSpan CountWait { get; private set; }

        public WaitItemResult(TimeSpan count)
        {
            CountWait = count;
        }
    }
}