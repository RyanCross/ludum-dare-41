using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    private Transform target;
    public float range = 15f;
    public float fireRate = 1f; // fire one bullet per second
    private float cooldown = 0f;

    public string enemyTag = "Enemy";
    public GameObject projectilePrefab;
    public Transform firePoint;
    public AudioSource fireSound;

    private void Awake()
    {
        fireSound = GetComponent<AudioSource>();
    }


    // Use this for initialization
    void Start () {
        // we don't want to check through every gameObject for enemies every frame, so invoke this function at the start and then every x seconds. 
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}


    // find all GameObjects
    void UpdateTarget ()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        // shortest distance to enemy we've found so far. 
        float shortestDistance= Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            // returns the distance between our tower and the enemy in unity "units"
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        // found enemy within tower range
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        // do nothing on this frame if there is no target.
        if (target == null)
        {
            return;
        }

        if (cooldown <= 0f)
        {
            Shoot();
            cooldown = 1f / fireRate;
        }

        cooldown -= Time.deltaTime;
	}

    void Shoot()
    {
        // cast is required to store the object reference
        GameObject projectileGO = (GameObject)Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Projectile projectile = projectileGO.GetComponent<Projectile>();

        if (projectile != null)
            // call seek with the towers current target.
            fireSound.Play();
            projectile.Seek(target);
    }

    // callback function provided by unity
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, range);
    }


}
