using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Player")
		{
			print ("Enter Trigger");
			col.gameObject.SendMessage("slowed");
			// Call the slow down function or set the new movement speed
		}
	}
	void OnTriggerExit(Collider col)
	{
		if(col.gameObject.tag == "Player")
		{
			print ("Exit Trigger");
			col.gameObject.SendMessage("normalSpeed");
			// Call the slow down function or set the new movement speed
		}
	}
}
