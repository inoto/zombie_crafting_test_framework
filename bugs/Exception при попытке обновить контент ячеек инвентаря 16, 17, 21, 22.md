Exception при попытке обновить контент ячеек инвентаря 16, 17, 21, 22
Приоритет: Blocker

test_15

Предусловия:
* иметь топор в инвентаре

STR
1. Открыть инвентарь
2. Переместить топор из первой ячейки инвентаря в каждую последующую - топор должен отобразиться в каждой ячейке. Однако ячейки 16, 17, 21, 22 ведут себя странно - когда переносишь туда предмет, то предмет остаётся на начальной позиции. При этом ячейка становится занята, но показывается как пустая.

{"tag":"info","depth":0,"time":"2021-5-2 02:55:05","data":{"name":"Final Error","traceback":"Exception: NullReferenceException: Object reference not set to an instance of an object\nCore.Controllers.CellController.RefreshContent () (at <31bdb29d12e9483b91fc3f056fe35760>:0)\nCore.Controllers.CellController.OnCellChanged () (at <31bdb29d12e9483b91fc3f056fe35760>:0)\nCore.Inventories.Cell.set_Stack (Core.Inventories.Stack value) (at <31bdb29d12e9483b91fc3f056fe35760>:0)\nCore.InventoryBehavior.MoveFromInventory (Core.Inventories.Cell cellFrom, Core.Inventories.Cell cellTo) (at <31bdb29d12e9483b91fc3f056fe35760>:0)\nCore.Controllers.Dialogs.InventoryDialogModel.DropToCell (Core.Inventories.Cell cell) (at <31bdb29d12e9483b91fc3f056fe35760>:0)\nCore.Controllers.CellController.OnDrop (UnityEngine.EventSystems.PointerEventData obj) (at <31bdb29d12e9483b91fc3f056fe35760>:0)\nCore.Controllers.CellContainer.OnDrop (UnityEngine.EventSystems.PointerEventData eventData) (at <31bdb29d12e9483b91fc3f056fe35760>:0)\nAssets.UiTest.TouchInput.UiTestTouchInput+<>c__DisplayClass32_0.<ExecuteDropEvent>b__0 (UnityEngine.EventSystems.IDropHandler o, UnityEngine.EventSystems.BaseEventData a) (at <5c901ac4ad81420db411013d86322d4e>:0)\nUnityEngine.EventSystems.ExecuteEvents.Execute[T] (UnityEngine.GameObject target, UnityEngine.EventSystems.BaseEventData eventData, UnityEngine.EventSystems.ExecuteEvents+EventFunction`1[T1] functor) (at <adbbd84a6a874fb3bb8dd55fe88db73d>:0)\nUnityEngine.EventSystems.ExecuteEvents:Execute(GameObject, BaseEventData, EventFunction`1)\nAssets.UiTest.TouchInput.UiTestTouchInput:ExecuteDropEvent(Vector2)\nAssets.UiTest.TouchInput.UiTestTouchInput:DragEnd(Vector2)\nAssets.UiTest.TestCommands.<Run>d__6:MoveNext()\nUiTest.UiTest.Coroutine.UiTestCoroutine:Run()\nUiTest.UiTest.Coroutine.Scheduler:Update()\nAssets.UiTest.Scripts.UiTestRun:Update()\n"}}

Если потом закрыть и открыть инвентарь, то он больше не закрывается - Blocker!