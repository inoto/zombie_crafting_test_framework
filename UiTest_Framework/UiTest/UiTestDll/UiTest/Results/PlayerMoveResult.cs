namespace Assets.UiTest.Results
{
    public class PlayerMoveResult : ICommandResult 
    {
        public bool FailMove { get; private set; }

        public PlayerMoveResult(bool failMove)
        {
            FailMove = failMove;
        }
    }
}