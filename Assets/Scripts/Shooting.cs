using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shooting : MonoBehaviour
{
    public float fireRate = 0.0f;
    public float maxDistance = 0.0f;
    public int maxAmmo = 0;
    public TextMeshProUGUI ammoTxt;

    private int ammo = 0;
    private float myTime = 0.0f;
    private float nextFire = 0.5F;

    public int Ammo { get => ammo; set => ammo = value; }

    private void Start()
    {
        ammo = maxAmmo;
        ammoTxt.text = $"{ammo}/{maxAmmo}";
    }
    // Update is called once per frame
    void Update()
    {
        if (ammo > maxAmmo) ammo = maxAmmo;
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
        ammoTxt.text = $"{ammo}/{maxAmmo}";
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
