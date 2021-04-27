using System.Collections;
using Assets.UiTest.Context;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.Results;
using Assets.UiTest.TestCommands;

namespace UiTest.UiTest.TestCommands
{
    public class FindAndGoToSingleObjectCommand : IUiTestCommand<PlayerMoveResult>
    {
        private readonly IUiTestContext _context;
        private readonly StringParam _objectId;
        private ResultData<PlayerMoveResult> _result = new ResultData<PlayerMoveResult>();

        public FindAndGoToSingleObjectCommand(IUiTestContext context, StringParam objectId)
        {
            _context = context;
            _objectId = objectId;
        }

        public PlayerMoveResult GetResult()
        {
            return _result.GetData();
        }

        public IEnumerator Run()
        {
            var objectPos = _context.GetObjectCordConfig(_objectId.Screen, _objectId.Item);
            yield return _context.Commands.PlayerMoveCommand(objectPos, _result);

        }
    }
}