using System;
using System.Collections;
using System.Collections.Generic;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.TestCommands;
using Assets.UiTest.Results;
using UiTest;
using UiTest.UiTest.Checker;
using UiTest.UiTest.Results;
using UiTest.UiTest.TestCommands;
using UnityEngine;

namespace Assets.UiTest.Context
{
    public class Commands
    {
        private readonly IUiTestContext _context;

        public Commands(IUiTestContext context)
        {
            _context = context;
        }
        
        public IEnumerator AndCheckCommand(List<IUiTestChecker> checks, ResultData<AndCheckerResult> result)
        {
            var starTime = DateTime.UtcNow;
            var command = new AndCheckCommand(_context,checks);
            yield return command.Run();
            result.SetData(command.GetResult());
            var endTime= DateTime.UtcNow;
            var comp = new Dictionary<string, string>();
            string checkString = "";
            foreach (var check in checks)
            {
                checkString = checkString + ", " + check.ToString();
            }

            checkString = checkString.Substring(1);
            comp["arg"] = $"<{checkString}>";
            comp["result"] = $"<{result.GetData().Tick.ToString()}>";
            _context.SendCommandLog(CommandsId.AndCheck,starTime,endTime,comp);
        }
        
        [Obsolete("Метод всегда вызывает NullReferenceException.")]
        public IEnumerator CellSearchByIconCommand(string iconId, string countItem, HashSet<string> inventoryId, ResultData<CellSearchByIconResult> result)
        {
            var starTime = DateTime.UtcNow;
            var command = new CellSearchByIconCommand(_context,iconId, countItem, inventoryId);
            yield return command.Run();
            result.SetData(command.GetResult());
            var endTime = DateTime.UtcNow;
            var comp = new Dictionary<string, string>();
            string inventoryIds = "";
            foreach (var id in inventoryId)
            {
                inventoryIds = inventoryIds +", " + id;
            }
            inventoryIds = inventoryIds.Substring(1);
            comp["arg"] = $"<{iconId}>,<{countItem}>, <{inventoryIds}>";
            
            var gameObject = result.GetData().CellGo;
            if (gameObject != null)
            {
                comp["result"] = $"<{gameObject.name}>";
            }
            else
            {
                comp["result"] = null;
            }
            _context.SendCommandLog(CommandsId.CellSearchByIcon, starTime, endTime, comp);
        }

        public IEnumerator CellSearchByIconNewCommand(string iconId, int countItem, HashSet<string> inventoryId,
            ResultData<CellSearchByIconResult> result)
        {
            var starTime = DateTime.UtcNow;
            var command = new CellSearchByIconNewCommand(_context,iconId, countItem, inventoryId);
            yield return command.Run();
            result.SetData(command.GetResult());
            var endTime = DateTime.UtcNow;
            var comp = new Dictionary<string, string>();
            string inventoryIds = "";
            foreach (var id in inventoryId)
            {
                inventoryIds = inventoryIds +", " + id;
            }
            inventoryIds = inventoryIds.Substring(1);
            comp["arg"] = $"<{iconId}>,<{countItem}>, <{inventoryIds}>";
            
            var gameObject = result.GetData().CellGo;
            if (gameObject != null)
            {
                comp["result"] = $"<{gameObject.name}>";
            }
            else
            {
                comp["result"] = null;
            }
            _context.SendCommandLog(CommandsId.CellSearchByIcon, starTime, endTime, comp);
        }
        
        
        public IEnumerator CloseDialogCommand(string buttonCloseId, ResultData<SimpleCommandResult> result)
        {
            var starTime= DateTime.UtcNow;
            var command = new CloseDialogCommand(_context,buttonCloseId);
            yield return command.Run();
            result.SetData(command.GetResult());
            var endTime= DateTime.UtcNow;
            var comp = new Dictionary<string, string>();
            comp["arg"] = $"<{buttonCloseId}>";
            comp["result"] = $"<{result.GetData().IsDone.ToString()}>";
            _context.SendCommandLog(CommandsId.CloseDialog,starTime,endTime,comp);
        }
        
        public IEnumerator DragAndDropCommand(StringParam inventoryIdStart, int cellNumberStart, StringParam  inventoryIdEnd, int cellNumberEnd, ResultData<SimpleCommandResult> result)
        {
            var starTime= DateTime.UtcNow;
            var command = new DragAndDropCommand(_context,inventoryIdStart, cellNumberStart,inventoryIdEnd,cellNumberEnd);
            yield return command.Run();
            result.SetData(command.GetResult());
            var endTime= DateTime.UtcNow;
            var comp = new Dictionary<string, string>();
            comp["arg"] = $"<{inventoryIdStart.Screen}, {inventoryIdStart.Item}>, <{cellNumberStart}>, <{inventoryIdEnd.Screen}, {inventoryIdEnd.Item}>, <{cellNumberEnd}> ";
            comp["result"] = $"<{result.GetData().IsDone.ToString()}>";
            _context.SendCommandLog(CommandsId.DragAndDrop,starTime,endTime, comp);
        }
        
        public IEnumerator CheckAndUseCommand(Tuple<string,IUiTestChecker>  checker, bool waitCheck, StringParam button, ResultData<SimpleCommandResult> result)
        {
            var starTime= DateTime.UtcNow;
            var command = new CheckAndUseCommand(_context, checker,waitCheck,button);
            yield return command.Run();
            result.SetData(command.GetResult());
            var endTime= DateTime.UtcNow;
            var comp = new Dictionary<string, string>();
            comp["arg"] = $"<{checker.Item1}>,<{waitCheck}>, <{button.Item}, {button.Screen}>";
            comp["result"] = $"<{result.GetData().IsDone}>";
            _context.SendCommandLog(CommandsId.CheckAndUseCommand,starTime,endTime, comp);
        }
          
        public IEnumerator ClickCellCommand(StringParam cellId, int cell, ResultData<SimpleCommandResult> result)
        {
            var starTime= DateTime.UtcNow;
            var command = new ClickCellCommand(_context,cellId,cell);
            yield return command.Run();
            result.SetData(command.GetResult());
            var endTime= DateTime.UtcNow;
            var comp = new Dictionary<string, string>();
            comp["arg"] = $"<{cell}, {cellId.Screen}, {cellId.Item}>";
            comp["result"] = $"<{result.GetData().IsDone.ToString()}>"; 
            _context.SendCommandLog(CommandsId.ClickCell,starTime,endTime, comp);
        }
        

        public IEnumerator OrCheckerCommand(List<IUiTestChecker> checks, ResultData<OrCheckResult> result)
        {
            var starTime = DateTime.UtcNow;
            var command = new OrCheckerCommand(_context,checks);
            yield return command.Run();
            result.SetData(command.GetResult());
            var endTime = DateTime.UtcNow;
            var comp = new Dictionary<string, string>();
            string checkString = "";
            foreach (var check in checks)
            {
                checkString = checkString + ", " + check.ToString();
            }

            checkString = checkString.Substring(1);
            comp["arg"] = $"<{checkString}>";
            comp["result"] = $"<{result.GetData().Tick.ToString()}, {result.GetData().Index.ToString()}>";
            _context.SendCommandLog(CommandsId.OrChecker, starTime, endTime, comp);
        }
        
        public IEnumerator PlayerMoveCommand(Vector3 endPosition, ResultData<PlayerMoveResult> result)
        {
            var starTime= DateTime.UtcNow;

            var command = new PlayerMoveCommand(_context, endPosition);
            yield return command.Run();
            result.SetData(command.GetResult());
            var endTime= DateTime.UtcNow;
            var comp = new Dictionary<string, string>();
            comp["arg"] = $"<{endPosition}>";
            comp["result"] = $"<{result.GetData().FailMove.ToString()}>";
            _context.SendCommandLog(CommandsId.PlayerMove,starTime,endTime, comp);
        }
        
        

        public IEnumerator ScreenshotCommand(ResultData<SimpleCommandResult> result)
        {
            var starTime = DateTime.UtcNow;
            var command = new ScreenshotCommand(_context);
            yield return command.Run();
            result.SetData(command.GetResult());
            var endTime= DateTime.UtcNow;
            var comp = new Dictionary<string, string>();
            comp["arg"] = "";
            comp["result"] = $"<{result.GetData().IsDone.ToString()}>";
            _context.SendCommandLog(CommandsId.Screenshot,starTime,endTime, comp,true);
        }
        
        
        
        
        
        public IEnumerator FindAndGoToSingleObjectCommand(StringParam objectId, ResultData<PlayerMoveResult> result)
        {
            var starTime = DateTime.UtcNow;
            var command = new FindAndGoToSingleObjectCommand(_context,objectId);
            yield return command.Run();
            result.SetData(command.GetResult());
            var endTime = DateTime.UtcNow;
            var comp = new Dictionary<string, string>();
            comp["arg"] = $"<{objectId.Screen}>, <{objectId.Item}>";
            comp["result"] = $"<{result.GetData().FailMove.ToString()}>";
            _context.SendCommandLog(CommandsId.FindAndGoToSingleObject, starTime, endTime, comp);
        }
        
        public IEnumerator UseButtonClickCommand(StringParam buttonUse, ResultData<SimpleCommandResult> result)
        {
            var starTime = DateTime.UtcNow;
            var command = new UseButtonClickCommand(_context,buttonUse.Screen, buttonUse.Item);
            yield return command.Run();
            result.SetData(command.GetResult());
            var endTime= DateTime.UtcNow;
            var comp = new Dictionary<string,string>();
            comp["arg"] = $"<{buttonUse.Screen}>,<{buttonUse.Item}>";
            comp["result"] = $"<{result.GetData().IsDone.ToString()}>";
            _context.SendCommandLog(CommandsId.UseButtonClick,starTime,endTime, comp);
        }
        
        
        
        public IEnumerator WaitDialogCommand(StringParam dialog, bool active, ResultData<WaitItemResult> result)
        {
            var starTime= DateTime.UtcNow;
            var command = new WaitDialogCommand(_context,dialog,  active);
            yield return command.Run();
            result.SetData(command.GetResult());
            var endTime= DateTime.UtcNow;
            var comp = new Dictionary<string, string>();
            comp["arg"] = $"<{dialog.Screen}>, <{dialog.Item}>, <{active}>";
            comp["result"] = $"<{result.GetData().CountWait.ToString()}>";
            _context.SendCommandLog(CommandsId.WaitDialog,starTime,endTime, comp, false);
        }
        
        
        
        
        public IEnumerator WaitForSecondsCommand(float seconds, ResultData<SimpleCommandResult> result)
        {
            var starTime=DateTime.UtcNow;
            var command = new WaitForSecondsCommand(_context,seconds);
            yield return command.Run();
            result.SetData(command.GetResult());
            var endTime= DateTime.UtcNow;
            var comp = new Dictionary<string, string>();
            comp["arg"] = $"<{seconds}>";
            comp["result"] = $"<{result.GetData().IsDone.ToString()}>";
            _context.SendCommandLog(CommandsId.WaitForSeconds,starTime,endTime,comp);
        }
        
        public IEnumerator WaitItemActiveButtonCommand(string button, string buttonId, ResultData<WaitItemResult> result)
        {
            var starTime=DateTime.UtcNow;
            var command = new WaitItemActiveButtonCommand(_context,button, buttonId);
            yield return command.Run();
            result.SetData(command.GetResult());
            var endTime= DateTime.UtcNow;
            var comp = new Dictionary<string, string>();
            comp["arg"] = $"<{button}>, <{buttonId}>";
            comp["result"] = $"<{result.GetData().CountWait.ToString()}>";
            _context.SendCommandLog(CommandsId.WaitItemActiveButton,starTime,endTime,comp);
        }

        public IEnumerator WaitWorkbenchSawmillProgressCompleteCommand(ResultData<WaitItemResult> result)
        {
            var starTime=DateTime.UtcNow;
            var command = new WaitWorkbenchSawmillProgressCompleteCommand(_context);
            yield return command.Run();
            result.SetData(command.GetResult());
            var endTime= DateTime.UtcNow;
            var comp = new Dictionary<string, string>();
            comp["arg"] = $"";
            comp["result"] = $"<{result.GetData().CountWait.ToString()}>";
            _context.SendCommandLog(CommandsId.WaitItemActiveButton,starTime,endTime,comp);
        }
    }
}