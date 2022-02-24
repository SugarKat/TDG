﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class TurretBlueprint
{

    public GameObject prefab;
    public int cost;

    public GameObject upgradePrefab;
    public int upgradeCost;

    public int sellWorth;

    public int GetSellAmount ()
    {
        return sellWorth;
    }

}
