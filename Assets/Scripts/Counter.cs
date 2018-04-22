using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Merch : MonoBehaviour {

    public Text text;
    private int cost;

    public int Cost { get => cost; set => cost = value; }

    public void Increment()
    {
        text.text = (int.Parse(text.text) + 1).ToString();
    }
}