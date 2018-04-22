using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exchange : MonoBehaviour {
    public Merch thingToBuy;
    public MoneySpender wallet;

    public bool Buy()
    {
        if (wallet.cash > thingToBuy.Cost)
        {
            wallet.Buy(thingToBuy.Cost);
            thingToBuy.Increment();
            return true;
        } else
        {
            //Buy failed
            return false;
        }
    }
}
