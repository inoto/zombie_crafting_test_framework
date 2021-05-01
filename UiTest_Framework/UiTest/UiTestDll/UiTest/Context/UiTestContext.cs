using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Assets.UiTest.Context.Consts;
using Assets.UiTest.ExitPosition;
using Assets.UiTest.ObjectPosition;
using Assets.UiTest.Sprite;
using Assets.UiTest.TouchInput;
using Assets.UiTest.UiTestButtonsGroup;
using Framework.Core.Encoder;
using Framework.Core.Value;
using UiTest.UiTest.Coroutine;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

namespace Assets.UiTest.Context
{
    public class UiTestContext : IUiTestContext
    {
        public event Action OnErrorDetect;
       

        public IUiTestTouchInput TestTouchInput { get; private set; }

        public IButtonsGroup Main
        {
            get { return _buttons["main"]; }
        }
        
        public IButtonsGroup Start
        {
            get { return _buttons["start"]; }
        }


        public ICheats Cheats
        {
            get { return _cheats; }
        }
        public Commands Commands {
            get {return new Commands(this);}
        }

        public IButtonsGroup Inventory
        {
            get { return _buttons["inventory"]; }
        }

        public ITemporaryData TemporaryData { get; private set; }
        
        public IGameManager GameManager{ get;  }
        public WaitForEndOfFrame WaitEndFrame { get;  }
        public ITestScheduler Scheduler{ get;  set; }
        public IScenes Scenes { get; private set; }
        public IUiTestSprite Sprite { get; private set; }
        public IUiTestObjectPosition ObjectPosition { get; private set; }

        private Dictionary<string, IButtonsGroup> _buttons = new Dictionary<string, IButtonsGroup>();
        private Dictionary<string, GameObject> _names = new Dictionary<string, GameObject>();
        private readonly IValue _config;
        private readonly int _testNumber;
        private readonly ICheats _cheats;
        private string _logPath;
        private List<string> _logData = new List<string>();
        private string _reportPath;
        private List<string> _reportData = new List<string>();
        private Dictionary<string,IValue> _reportDict = new Dictionary<string, IValue>(); 
        private string _dirPath;
        private Dictionary<string, IValue> _comp = new Dictionary<string, IValue>();
        private bool _screenshotReport=false;
        private Dictionary<string, string> _reportArgs;

        public UiTestContext(IValue config, IGameManager gameManager, int testNumber)
        {
            TemporaryData = new TemporaryData();
            GameManager = gameManager;
            _cheats = GameManager.GetCheats();
             _config = config;
            _testNumber = testNumber;
            TestTouchInput = new UiTestTouchInput(gameManager);
            WaitEndFrame = null;
        }

        public void Rebuild(List<string> keys)
        {
            _names.Clear();
            _buttons.Clear();
            CreateDictionaryNames();
            Sprite = new UiTestSprite(_config["sprite_config"]);
            ObjectPosition = new UiTestObjectPosition(_config["object_config"]);
            foreach (var key in keys)
            {
                var battle = new ButtonsGroup(_config["ui_config"][key], _names);
                _buttons[key] = battle;
            }

        }
        
        public IButtonsGroup GetButtonsGroup(string key)
        {
            return _buttons[key];
        }

        public float ProgressBarAmount()
        {
            var gameObject = Inventory.GetContent(Screens.Inventory.Content.WorkbenchProgressBar.Item).GetGO();
            var component = gameObject.GetComponent<Image>();
            return component.fillAmount;
        }

        private void CreateDictionaryNames()
        {
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                var scene = SceneManager.GetSceneAt(i);
                var rootObjects = scene.GetRootGameObjects();
                foreach (var gameObject in rootObjects)
                {
                    var name = scene.name + ":" + gameObject.name;
                    GetName(name, gameObject);
                }
            }

            var gm = _cheats.GetGmGo();
            GetName(gm.name, gm);
        }
        
       

        private void GetName(string name, GameObject gameObject)
        {
            var parentName = name;
            int i = 0;

            while (_names.ContainsKey(parentName))
            {
                i++;
                parentName = name + ":" + i;
            }

            _names.Add(parentName, gameObject);
            // Debug.Log(parantName);
            for (int j = 0; j < gameObject.transform.childCount; j++)
            {
                var go = gameObject.transform.GetChild(j).gameObject;

                var newName = go.name;

                GetName(parentName + "/" + newName, go);
            }
        }

        public Vector3 GetPlayerPosition()
        {
            return _cheats.GetPlayerPosition();
        }
        
        

      

        public Vector3[] FindPath(Vector3 source, Vector3 target)
        {
            NavMeshHit hit;
            var norm = source - target;
            norm.Normalize();
            float distance = 0.5f;
            
            target = target - norm * distance;
            NavMesh.SamplePosition(target, out hit, 2, NavMesh.AllAreas);
            var navMeshPath = new NavMeshPath();
            if (NavMesh.CalculatePath(source, hit.position, NavMesh.AllAreas, navMeshPath))
            {
                var lastPoint = navMeshPath.corners[navMeshPath.corners.Length - 1];
                lastPoint.y = 0;
                if ((lastPoint - hit.position).magnitude <= 1f)
                {
                    return navMeshPath.corners;
                }
            }

            return null;
        }

        


        public bool Vector3Equal(Vector3 first, Vector3 second, float p)
        {
            return (first - second).sqrMagnitude <= p * p;
        }

        public Vector2 BuildingCoord(Vector3 position)
        {
            var gameObject = _buttons["battle"].GetContent("game_camera").GetGO();
            var floorCord = RectTransformUtility.WorldToScreenPoint(gameObject.GetComponent<Camera>(), position);
            return floorCord;
        }

        

        public Vector2 GlobalMapCoord(Vector3 position)
        {
            var gameObject = _buttons["global_map"].GetContent("game_camera").GetGO();
            var floorCord = RectTransformUtility.WorldToScreenPoint(gameObject.GetComponent<Camera>(), position);
            return floorCord;
        }

        public string GetCellInventory(GameObject cell)
        {
            string cellInventory = null;
            switch (cell.transform.parent.name)
            {
                case "ItemsPanel":
                    cellInventory = "loot";
                    break;
                case "Pockets":
                    cellInventory = "pockets";
                    break;
                case "Backpack":
                    cellInventory = "backpack";
                    break;
            }

            return cellInventory;
        }

        public int GetCellIndex(GameObject cell)
        {
            int CellCount = 0;
            string cellName = cell.name;

            if (cellName != "Cell")
            {
                cellName = cellName.Substring(6);
                cellName = cellName.Substring(0, cellName.Length - 1);
                CellCount = int.Parse(cellName);
            }

            return CellCount;
        }

        public string GetCellIconName(GameObject cell)
        {
            // if (cell == null)
            // {
            //     this.SendDebugLog($"cell is null");
            // }
            var images = cell.GetComponentsInChildren<Image>();
            // this.SendDebugLog($"images length: {images.Length}");
            foreach (var image in images)
            {
                if (image.sprite.name == "CellFrame" || image.sprite.name == "CellFrameDark")
                    continue;
                // this.SendDebugLog($"image sprite name: {image.sprite.name}");
                if (image.sprite != null)
                    return image.sprite.name;
            }

            return "";
        }
        
        private GameObject FindInventoryCellBySpriteName(string spriteName, HashSet<GameObject> hashGo)
        {
            foreach (var invGo in hashGo)
            {
                // this.SendDebugLog($"invGO name: {invGo.name}");
                for (int i = 0; i < invGo.transform.childCount; i++)
                {
                    var cell = invGo.transform.GetChild(i).gameObject;
                    var iconName = this.GetCellIconName(cell);
                    // this.SendDebugLog($"cell: {i}, iconName: {iconName}, isEmpty: {Cheats.IconIsEmpty(cell)}");
                    if (iconName == spriteName && !Cheats.IconIsEmpty(cell))
                    {
                        return cell;
                    }
                }
            }

            return null;
        }

        public GameObject FindCellInInventoriesBySpriteName(string spriteName, HashSet<string> inventoryCellIds)
        {
            HashSet<GameObject> hashGo = new HashSet<GameObject>();
            foreach (var id in inventoryCellIds)
            {
                hashGo.Add(this.Inventory.GetCells(id).GetCell(0).transform.parent.gameObject);
            }

            return FindInventoryCellBySpriteName(spriteName, hashGo);
        }

        public HashSet<string> GetSpriteCategory(string spriteCategoryId)
        {
            return Sprite.GetSprite(spriteCategoryId);
        }

        public void CreatFilePath(string path)
        {
            if (string.IsNullOrEmpty(_dirPath))
            {
                string time = DateTime.Now.ToString("dd-MM-yyyy");
                _dirPath = string.Format("{0}../TestData/Logs/test_{1}.air_Win_{2}/log", path, _testNumber, time);
                DirectoryInfo dirInfo = new DirectoryInfo(_dirPath);

                Directory.CreateDirectory(_dirPath);
                _logPath = string.Format("{0}/log_dev.txt", _dirPath);
                _reportPath = string.Format("{0}/log.txt", _dirPath);
            }

            _logData.Clear();

        }

        public void SendDebugLog(string text)
        {
            SendCommandLog(text, DateTime.UtcNow, DateTime.UtcNow, new Dictionary<string, string>
            {
                {"arg", ""},
                {"result", ""}
            }, false);
        }

        public void SendCommandLog(string commandId, DateTime startTime, DateTime endTime, Dictionary<string,string> comp, bool screenshots)
        {
            var logData = new Dictionary<string, IValue>();
            var encoder = new JsonEncoder();
            
            logData["time"] = new StringValue(startTime.ToString("yyyy-M-d HH:mm:ss"));
            logData["name"] = new StringValue($"{commandId,-20}");
            var duration = endTime.Subtract(startTime);
            logData["duration"] = new StringValue(duration.ToString(@"mm\:ss"));
            logData["result"]= new StringValue(comp["result"]);
            logData["arg"] = new StringValue(comp["arg"]);
            if (screenshots)
            {
                _screenshotReport = screenshots;
            }

            var bytes = encoder.Encode(new DictionaryValue(logData));

            string result = Encoding.UTF8.GetString(bytes);
            string channelStr = "<color=#94D8FF>[COMMAND]</color> " + result;
            Debug.Log(channelStr);
            _logData.Add(result);
        }

        

        public void SendAllLogs()
        {
            File.WriteAllLines(_logPath, _logData.ToArray());
            File.WriteAllLines(_reportPath, _reportData.ToArray());
            _logData.Clear();
            _reportData.Clear();
        }


        public string CaptureScreenshot(string name, DateTime time)
        {
            var path = "Screenshoot_" + name + "_" + UnixTime(time) + ".jpg";
            ScreenCapture.CaptureScreenshot(_dirPath+"/"+path);
            return path;
        }

        public double UnixTime(DateTime time)
        {

            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            TimeSpan diff = time - origin;
            return Math.Floor(diff.TotalSeconds);
        }

        public void ExceptionLogs()
        {
            Application.logMessageReceived +=LogsCallback;
        }


        private void LogsCallback(string condition, string stacktrace, LogType type)
        {
            if (type == LogType.Exception && !stacktrace.Contains("ClearPreviewCache"))
            {
                
                var startTime = DateTime.UtcNow;
                var exception = string.Format("{0}: {1}\n{2}", type, condition, stacktrace);
                var logData = new Dictionary<string, IValue>();
                logData["tag"] = new StringValue("info");
                logData["depth"] = new IntValue(0);
                logData["time"] = new StringValue(startTime.ToString("yyyy-M-d hh:mm:ss"));
                var data = new Dictionary<string, IValue>();
                logData["data"] = new DictionaryValue(data);
                data["name"] = new StringValue("Final Error");
                data["traceback"] = new StringValue(exception);
                var encoder = new JsonEncoder();
                var bytes = encoder.Encode(new DictionaryValue(logData));

                string result = Encoding.UTF8.GetString(bytes);
                _reportData.Add(result);
                OnErrorDetect?.Invoke();
            }
        }

        public Vector3 GetObjectCordConfig(string location, string objectName)
        {
            return ObjectPosition.GetObjectPosition(location, objectName);
        }

        public void FailScenario(string assert)
        {
            var startTime = DateTime.UtcNow;
            var logData = new Dictionary<string, IValue>();
            logData["tag"] = new StringValue("info");
            logData["depth"] = new IntValue(0);
            logData["time"] = new StringValue(startTime.ToString("yyyy-M-d hh:mm:ss"));
            var data = new Dictionary<string, IValue>();
            logData["data"] = new DictionaryValue(data);
            data["name"] = new StringValue("Final Error");
            data["traceback"] = new StringValue(assert);
            var encoder = new JsonEncoder();
            var bytes = encoder.Encode(new DictionaryValue(logData));

            string result = Encoding.UTF8.GetString(bytes);
            _reportData.Add(result);
        }

        public void SendCommandReport(string id, DateTime startTime, DateTime endTime, string state)
        {
            var logData = new Dictionary<string, IValue>();
            var encoder = new JsonEncoder();

            logData["tag"] = new StringValue("function");
            logData["depth"] = new IntValue(1);
            logData["time"] = new StringValue(startTime.ToString("yyyy-M-d HH:mm:ss"));
            logData["data"] = new DictionaryValue(_reportDict);
            var callArgs = new Dictionary<string, IValue>();
            IValue value= new DictionaryValue(callArgs);
            if (!_reportDict.TryGetValue("call_args", out value))
            {
                _reportDict["call_args"] = new DictionaryValue(callArgs);
            }
            _reportDict["end_time"] = new DoubleValue(UnixTime(endTime));
            _reportDict["start_time"] = new DoubleValue(UnixTime(startTime));
            if (_screenshotReport)
            {
                var screenLogData = new Dictionary<string, IValue>();
                screenLogData["tag"] = new StringValue("function");
                screenLogData["depth"] = new IntValue(1);
                screenLogData["time"] = new StringValue(startTime.ToString("yyyy-M-d HH:mm:ss"));
                var dataScreen = new Dictionary<string, IValue>();
                screenLogData["data"] = new DictionaryValue(dataScreen);
                var callArgsScreen = new Dictionary<string, IValue>();
                dataScreen["call_args"] = new DictionaryValue(callArgsScreen);
                dataScreen["ret"] = new StringValue(CaptureScreenshot(id, endTime));
                dataScreen["start_time"] = new DoubleValue(UnixTime(startTime));
                dataScreen["end_time"] = new DoubleValue(UnixTime(endTime));
                dataScreen["name"] = new StringValue("try_log_screen");
                var screenBytes = encoder.Encode(new DictionaryValue(screenLogData));
                string screenResult = Encoding.UTF8.GetString(screenBytes);
                _reportData.Add(screenResult);
                _screenshotReport = false;
            }
            else
            {
                _reportDict["ret"] = new NullValue();
            }

            _reportDict["name"] = new StringValue(id);
            var bytes = encoder.Encode(new DictionaryValue(logData));
            string result = Encoding.UTF8.GetString(bytes);
            _reportData.Add(result);
            
            var reportData = new Dictionary<string, IValue>();
            reportData["time"] = new StringValue(startTime.ToString("yyyy-M-d HH:mm:ss"));
            reportData["name"] = new StringValue($"step_{id,-20}");
            var duration = endTime.Subtract(startTime);
            reportData["duration"] = new StringValue(duration.ToString(@"mm\:ss"));
             var list = new List<IValue>();
            foreach (var arg in _reportArgs)
            {
                list.Add(new StringValue(arg.Value));
            }
            reportData["arg"] = new ListValue(list);
            
            bytes = encoder.Encode(new DictionaryValue(reportData));

            result = Encoding.UTF8.GetString(bytes);
            string channelStr = "<color=#4EB32D>[STEPS]</color> " + result;
                

            Debug.Log(channelStr);
            _logData.Add(result);
        }

        public void SendStepArgs(Dictionary<string, string> args)
        {
            _reportArgs = args;
            var callArgs = new Dictionary<string, IValue>();
            _reportDict["call_args"] = new DictionaryValue(callArgs);
            callArgs["package"] = new StringValue("zombie.survival.craft.z");
            callArgs["activity"] = new NullValue();
            foreach (var keyValue in args)
            {
                callArgs[keyValue.Key] = new StringValue(keyValue.Value);
            }
        }

       

        public Vector3  DirectionPosition( Vector3 objPos, float direction)
        {
            var playerPos = GetPlayerPosition();
            var dir = (objPos - playerPos).normalized;
            return dir * direction;
        }

      
        
        public  bool CheckWalls(Vector3 targetPosition, Vector3 sourcePosition)
        {
            var direction = (targetPosition - sourcePosition).normalized;
            var distance = Vector3.Distance(sourcePosition, targetPosition);

            var ray = new Ray(sourcePosition + Vector3.up * 0.6f, direction);
            RaycastHit raycastInfo;
            if (Physics.Raycast(ray, out raycastInfo, distance, LayerMask.GetMask(new[] {"AttackCollider"})))
            {
                if (raycastInfo.distance <= distance)
                    return true;
            }

            return false;
        }

       

        private void RebuildScene()
        {
            List<string> screenList = new List<string>();
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                var scene = SceneManager.GetSceneAt(i);
                var collection = Scenes.GetScreens(scene.name);
                screenList.AddRange(collection);
            }
            screenList.Add("game_controller");
            Rebuild(screenList);
        }
    }
}
