using UnityEngine;

public class Shop : MonoBehaviour {

    BuildManager buildManager;
    public GameObject canvas;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canvas.SetActive(false);
            //level start
            Enemy.SetNumZombies(4*(6+7+8));
            WaveSpawner.waveNum = 2;
        }
    }

    public void PurchaseStandardTurret()
    {
        Debug.Log("Standard Turret Purchased.");
        buildManager.SetTowerToBuild(buildManager.standardTowerPrefab);
    }

    public void PurchaseOtherTurret()
    {
        Debug.Log("Other Turret Purchased.");
        buildManager.SetTowerToBuild(buildManager.otherTowerPrefab);
    }
}
