using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exchange : MonoBehaviour {
    public Buyable thingToBuy;
    public PlayerInventory playerInventory;
    public Wallet wallet;
    public TowerTypes towerType;

    public void Awake()
    {
        playerInventory = PlayerInventory.Instance;
    }

    public void Buy()
    {
        if (playerInventory.Cash >= thingToBuy.cost)
        {
            wallet.Buy(thingToBuy.cost);
            thingToBuy.Increment();
            playerInventory.AddTowerToInventory(towerType);
        }
        else
        {
            //Insufficient Funds.
        }
    }
}
