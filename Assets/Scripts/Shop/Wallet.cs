using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class Wallet : MonoBehaviour {

    public Text fundsText;
    PlayerInventory playerInventory;

    private void Awake()
    {
        playerInventory = PlayerInventory.Instance;
    }

    private void Update()
    {
        fundsText.text = "Funds - " + playerInventory.Cash + "g";
    }

    public void Buy(int cost)
    {
        fundsText.text = Spend(cost);
    }

    private string Spend(int cost)
    {
        playerInventory.Cash -= cost;
        int newMoney = System.Int32.Parse(Regex.Match(fundsText.text, @"\d+").Value)-cost;
        return "Funds - " + playerInventory.Cash + "g";
    }
}
