using UnityEngine;

public class Shop : MonoBehaviour {

    public PlayerInventory playerInventory;
    public GameObject canvas;

    void Start()
    {
        playerInventory = PlayerInventory.Instance;
    }

    void Update()
    {
        if (Cursor.visible == false)
        {
            Cursor.visible = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = false;
            canvas.SetActive(false);
            //level start
            Enemy.SetNumZombies(120);
            WaveSpawner.waveNum = 2;
        }
    }

    public void PurchaseStandardTurret()
    {
        Debug.Log("Standard Turret Purchased.");
        playerInventory.AddTowerToInventory(TowerTypes.tower1);
    }

    public void PurchaseOtherTurret()
    {
        Debug.Log("Other Turret Purchased.");
        playerInventory.AddTowerToInventory(TowerTypes.tower2);
    }
}
