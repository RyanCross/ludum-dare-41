using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exchange : MonoBehaviour {
    public Buyable thingToBuy;
    public Wallet wallet;

    public void Buy()
    {
        if (wallet.cash >= thingToBuy.cost)
        {
            wallet.Buy(thingToBuy.cost);
            thingToBuy.Increment();
        } else
        {

        }
    }
}
