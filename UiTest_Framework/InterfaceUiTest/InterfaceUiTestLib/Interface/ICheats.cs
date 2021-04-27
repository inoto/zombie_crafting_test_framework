using System;
using System.Collections.Generic;
using UnityEngine;


public interface ICheats
{
    GameObject GetGmGo();
    Vector2 CordButton(GameObject button);
    Vector3 GetPlayerPosition();
    GameObject CellSearchByIcon(HashSet<string> iconId, string countItem, HashSet<GameObject> hashGo);
    List<GameObject> FindTree();
    bool TreeFelled(GameObject tree);
    int TreeCount(GameObject inventory);
    int CellCount(GameObject cell);
    bool IconIsEmpty(GameObject cell);
    bool CountIsEmpty(GameObject cell);
    void GetCoins(int amount);
    void GetWood(int amount);
    void GetAxe(int amount);
    void GetWoodPlank(int amount);
}

