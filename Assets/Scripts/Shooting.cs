using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float fireRate = 0.0f;
    public float maxDistance = 0.0f;
    private float myTime = 0.0f;

    // Update is called once per frame
    void Update()
    {
        myTime += Time.deltaTime;
        if(Input.GetButton("Fire1") && myTime > fireRate)
        {
            Shoot();
        }
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
    }
}
