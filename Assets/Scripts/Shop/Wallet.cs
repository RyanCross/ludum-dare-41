using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class Wallet : MonoBehaviour {

    public Text fundsText;
    public int simpleCost = 200;
    public int otherCost = 500;

    public int cash;

    public void Buy(int cost)
    {
        fundsText.text = Spend(cost);
    }

    private string Spend(int cost)
    {
        cash -= cost;
        int newMoney = System.Int32.Parse(Regex.Match(fundsText.text, @"\d+").Value)-cost;
        return "Funds - " + cash + "g";
    }
}
