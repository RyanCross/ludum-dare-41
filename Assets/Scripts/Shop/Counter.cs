using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour {

    public Text text;

    public void Increment()
    {
        text.text = (int.Parse(text.text) + 1).ToString();
    }
}