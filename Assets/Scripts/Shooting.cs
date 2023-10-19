using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shooting : MonoBehaviour
{
    public Camera camera;
    public float damage = 0.0f;
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
    void FixedUpdate()
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
        ammoTxt.text = $"{ammo}/{maxAmmo}";
    }
    private void Shoot()
    {
        Ray ray = camera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;

        // Perform the raycast
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            IDamageable damageable = hit.collider.gameObject.GetComponent<IDamageable>();
            // Hit object
            if(damageable != null)
            {
                damageable.TakeDamage(damage, hit.point);
            }

        }
        else
        {
        }

        ammo--;
    }
}
