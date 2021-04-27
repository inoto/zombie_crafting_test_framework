using System;
using System.Collections.Generic;
using UnityEngine;


    public interface IGameManager
    {
        IUiTestTouchController GetTouchController();
        ICheats GetCheats();
    }
