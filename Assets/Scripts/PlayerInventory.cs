using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory {
    public int tower1Count { get; set; }
    public int tower2Count { get; set; }
    public int tower3Count { get; set; }
    private int sexyPoints  { get; set; }

    public void initPlayerInventoryData()
    {
        tower1Count = 1;
        tower2Count = 0;
        tower3Count = 0;     
    }

    public void AddTowerToInventory(TowerTypes towerType)
    {
        if (towerType == TowerTypes.tower1)
        {
            tower1Count++;
        }
        else if (towerType == TowerTypes.tower2)
        {
            tower2Count++;
        }
        else if (towerType == TowerTypes.tower3)
        {
            tower3Count++;
        }
    }

    public void RemoveTowerFromInventory(TowerTypes towerType)
    {
        if (towerType == TowerTypes.tower1)
        {
            if (tower1Count > 0)
            {
                tower1Count--;
            }
            
        }
        else if (towerType == TowerTypes.tower2)
        {
            if (tower2Count > 0)
            {
                tower2Count--;
            }
            
        }
        else if (towerType == TowerTypes.tower3)
        {
            if (tower3Count > 0)
            {
                tower3Count--;
            }
        }
    }
}
