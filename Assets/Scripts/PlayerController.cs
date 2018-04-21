using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public GunController gun;

    private Rigidbody body;
    private Vector3 moveInput;
    private Vector3 moveVelocity;
    private Camera mainCamera;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        //Movement
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;

        //Looking around
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if(groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

        //Shooting the gun
        if(Input.GetMouseButtonDown(0))
        {
            gun.isFiring = true;
        } 
        if(Input.GetMouseButtonUp(0))
        {
            gun.isFiring = false;
        }
	}

	private void FixedUpdate() {
        body.velocity = moveVelocity;
	}
}
