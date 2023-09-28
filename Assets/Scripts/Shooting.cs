using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float fireRate = 0.0f;
    public float maxDistance = 0.0f;
    public int maxAmmo = 0;

    private int ammo = 0;
    private float myTime = 0.0f;
    private float nextFire = 0.5F;

    private void Start()
    {
        ammo = maxAmmo;
    }
    // Update is called once per frame
    void Update()
    {
        myTime += Time.deltaTime;

        if(ammo > 0 && myTime > nextFire && Input.GetButton("Fire1"))
        {
            nextFire = myTime + fireRate;
            Shoot();
            nextFire = nextFire - myTime;
            myTime = 0f;
        }
        if (Input.GetButton("Fire2"))
            ammo = maxAmmo;
    }

    private void Shoot()
    {
        // Camera position and direction
        Vector3 rayOrigin = transform.position;
        Vector3 rayDirection = transform.forward;

        RaycastHit hit;

        // Perform the raycast
        if (Physics.Raycast(rayOrigin, rayDirection, out hit, maxDistance))
        {
            // Hit object
            Debug.Log("Hit " + hit.collider.gameObject.name);
            Debug.Log("Hit Point: " + hit.point);
            Debug.Log("Hit Normal: " + hit.normal);

        }
        else
        {
            Debug.Log("No Hit");
        }

        ammo--;
        Debug.Log("Ammo: " + ammo);
    }
}
