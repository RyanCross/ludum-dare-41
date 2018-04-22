using UnityEngine;

public class Shop : MonoBehaviour {

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
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
