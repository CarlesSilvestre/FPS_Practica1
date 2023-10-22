using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Diana : MonoBehaviour, IDamageable
{
    public int points = 0;
    public bool destroyForever;
    private ShootingGallery sg;
    public void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(float amount, Vector3 hitPoint)
    {
        sg.Points += points;
        if (destroyForever)
            Die();
        else
            StartCoroutine(DisableMe());
    }

    private IEnumerator DisableMe()
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(7f);
        GetComponent<Collider>().enabled = true;
        GetComponent<Renderer>().enabled = true;
    }


    // Start is called before the first frame update
    void Start()
    {
        sg = transform.parent.GetComponent<ShootingGallery>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
