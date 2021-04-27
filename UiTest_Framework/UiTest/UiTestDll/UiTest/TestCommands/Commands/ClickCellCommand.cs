using System.Collections;
using Assets.UiTest.Context;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;
using Assets.UiTest.TestCommands;

namespace UiTest.UiTest.TestCommands
{
    public class ClickCellCommand :IUiTestCommand<SimpleCommandResult>
    {
        private readonly IUiTestContext _context;
        private readonly StringParam _cellId;
        private readonly int _cell;

        public ClickCellCommand(IUiTestContext context, StringParam cellId, int cell)
        {
            _context = context;
            _cellId = cellId;
            _cell = cell;
        }
        public SimpleCommandResult GetResult()
        {
            return new SimpleCommandResult(true);
        }

        public IEnumerator Run()
        {
            _context.GetButtonsGroup(_cellId.Screen).GetCells(_cellId.Item).ClickCell(_cell);
            yield return _context.WaitEndFrame;
        }
    }
}