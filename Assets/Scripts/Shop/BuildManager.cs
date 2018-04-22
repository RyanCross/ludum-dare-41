using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

	void Awake () {
        if (instance != null)
        {
            Debug.LogError("Multiple BuildManagers in scene!");
            return;
        }
        instance = this;
	}

    public GameObject standardTowerPrefab;

    private GameObject towerToBuild;
    public GameObject otherTowerPrefab;

    public GameObject GetTowerToBuild()
    {
        return towerToBuild;
    }

    public void SetTowerToBuild(GameObject tower)
    {
        towerToBuild = tower;
    }
}
