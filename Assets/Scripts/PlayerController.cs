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
    private bool isInBuildMode;
    public GameObject currentSilhoutte;
    public PlayerInventory playerInventory;
    public TowerTypes towerToBePlaced;
    public bool canTowerBePlaced;

    // prefabs assigned in the inspector:

    // hold the actual model (0), as well as the placeable (1) and restricted silhoutte prefabs (2).
    public GameObject[] towerOnePrefabs = new GameObject[3];
    public GameObject[] towerTwoPrefabs = new GameObject[3];
    public GameObject[] towerThreePrefabs = new GameObject[3];

    private void Awake()
    {
        isInBuildMode = false;
        canTowerBePlaced = false;
        Cursor.visible = false;
        playerInventory = new PlayerInventory();
        playerInventory.initPlayerInventoryData();
        towerToBePlaced = TowerTypes.noTower;
    }

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

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if (isInBuildMode == true)
            {
                isInBuildMode = false;
                Cursor.visible = false;
                Debug.Log("Build Mode Exited.");
            }
            else
            {
                isInBuildMode = true;
                Cursor.visible = true;
                Debug.Log("Entering Build Mode.");
                // just in case, stop firing the gun
                gun.isFiring = false;
            }
        }

        if (isInBuildMode == false)
        {
            cleanUpBuildMode();
            //Shooting the gun
            if (Input.GetMouseButtonDown(0))
            {
                gun.isFiring = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                gun.isFiring = false;
            }
        }

        if (isInBuildMode == true)
        {
            InstantiateSilhoutteAtMousePos();
            CheckForPlacement();
        }
	}


    private void InstantiateSilhoutteAtMousePos ()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        Vector3 mousePos;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (playerInventory.tower1Count > 0)
            {
                if(currentSilhoutte != null)
                {
                    Destroy(currentSilhoutte);
                    currentSilhoutte = null;
                }
                currentSilhoutte = (GameObject)Instantiate(towerOnePrefabs[1]);
                towerToBePlaced = TowerTypes.tower1;
                canTowerBePlaced = true;
            }
            else
            {
                if (currentSilhoutte != null)
                {
                    Destroy(currentSilhoutte);
                    currentSilhoutte = null;
                }
                currentSilhoutte = (GameObject)Instantiate(towerOnePrefabs[2]);
                canTowerBePlaced = false;
            }
        }
        MoveObjectToMouse(currentSilhoutte);
    }

    private void CheckForPlacement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currentSilhoutte != null && canTowerBePlaced)
            {
                if (towerToBePlaced == TowerTypes.tower1)
                {
                    Instantiate(towerOnePrefabs[0], currentSilhoutte.transform.position, currentSilhoutte.transform.rotation);
                    playerInventory.RemoveTowerFromInventory(towerToBePlaced);
                    Destroy(currentSilhoutte);
                }
            }
        }
       
        else
        {
            return;
        }
    }


    // Clean up any left over objects or UI elements from toggling build mode.
    private void cleanUpBuildMode()
    {
        Cursor.visible = false;
        canTowerBePlaced = false;
        Destroy(currentSilhoutte);
    }

    private void MoveObjectToMouse(GameObject GO)
    {
        if (GO == null)
        {
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            GO.transform.position = hitInfo.point;
        }
    }

	private void FixedUpdate() {
        body.velocity = moveVelocity;
	}
}
