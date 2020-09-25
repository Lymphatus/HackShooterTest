using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public float fireRate = 0.5f;
    public float damage = 1.0f;
    public Transform firePoint, player;
    public GameObject projectilePrefab;
    private float nextFire = -1f;
    private bool canFire = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space")) {
            Fire();
        }
        
        if(nextFire > 0) {
            nextFire -= Time.deltaTime;
            canFire = false;
        } else {
            canFire = true;
        }
    }
    
    private void Fire()
    {
        if (!canFire) {
            return;
        }
        
        GameObject projectile = Instantiate(this.projectilePrefab);
        projectile.transform.position = firePoint.transform.position;
        projectile.transform.rotation = player.transform.rotation;

        nextFire = fireRate;
    }
}
