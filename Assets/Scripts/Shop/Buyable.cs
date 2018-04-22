using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buyable : MonoBehaviour {

    public Text text;

    public int cost;
    public void Increment()
    {
        text.text = (int.Parse(text.text) + 1).ToString();
    }

    //TODO: Add to player inv.
}