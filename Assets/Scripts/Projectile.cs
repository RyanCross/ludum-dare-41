using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    // A projectile needs a:
    public Enemy target;
    public float speed = 70f;
    public GameObject impactEffect;

    public void Seek(Enemy _target)
    {
        target = _target;
    }

	// Update is called once per frame
	void Update () {
		if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        
        Vector3 dir = target.transform.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        // if the length of our direction vector (dir.magnitude), is less than or equal to the distance we are going to move this frame.
        // we've hit something. 
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        // normalize so that are we moving at a constant speed (distanceThisFrame)
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
	}

    void HitTarget ()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        // destroy this projectile
        Destroy(gameObject);
        //Destroy(target.gameObject);
        target.Death(fromPlayer: false);
        // destroy effect after 2 seconds
        Destroy(effectIns, 2f);
    }
}
