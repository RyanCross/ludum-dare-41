using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squarePlayer : MonoBehaviour {
	public float moveSpeed;

	// Use this for initialization
	void Start () {
		moveSpeed = 10;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate (moveSpeed*Input.GetAxis("Horizontal")*Time.deltaTime, 0f,moveSpeed*Input.GetAxis("Vertical")*Time.deltaTime);
	}
}
