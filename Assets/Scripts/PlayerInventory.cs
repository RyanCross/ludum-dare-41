using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory {
    public int Tower1Count { get; set; }
    public int Tower2Count { get; set; }
    public int Tower3Count { get; set; }
    private int SexyPoints  { get; set; }
    public int Cash { get; set; }
    private static PlayerInventory _instance;
    public static PlayerInventory Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PlayerInventory
                {
                    Tower1Count = 1,
                    Tower2Count = 0,
                    Tower3Count = 0,
                    Cash = 1000
                };
            }
            return _instance;
        }
    }

    public void AddTowerToInventory(TowerTypes towerType)
    {
        if (towerType == TowerTypes.tower1)
        {
            Tower1Count++;
        }
        else if (towerType == TowerTypes.tower2)
        {
            Tower2Count++;
        }
        else if (towerType == TowerTypes.tower3)
        {
            Tower3Count++;
        }
    }

    public void RemoveTowerFromInventory(TowerTypes towerType)
    {
        if (towerType == TowerTypes.tower1)
        {
            if (Tower1Count > 0)
            {
                Tower1Count--;
            }
            
        }
        else if (towerType == TowerTypes.tower2)
        {
            if (Tower2Count > 0)
            {
                Tower2Count--;
            }
            
        }
        else if (towerType == TowerTypes.tower3)
        {
            if (Tower3Count > 0)
            {
                Tower3Count--;
            }
        }
    }
}
