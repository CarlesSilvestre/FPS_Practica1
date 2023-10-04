using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    private HealthController health;
    private Shooting shooting;
    private void Start()
    {
        health = gameObject.GetComponent<HealthController>();
        shooting = gameObject.GetComponent<Shooting>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Item i = other.gameObject.GetComponent<Item>();
        if(i != null)
        {
            switch (other.gameObject.layer)
            {
                case 8:
                    if(health.MHp < health.MaxHP)
                    {
                        health.MHp += i.Ammount;
                        Destroy(i.gameObject);
                    }
                    break;
                case 9:
                    if (health.MShield < health.MaxShield)
                    {
                        health.MShield += i.Ammount;
                        Destroy(i.gameObject);
                    }
                    break;
                case 10:
                    if (shooting.Ammo < shooting.maxAmmo)
                    {
                        shooting.Ammo += ((int)i.Ammount);
                        Destroy(i.gameObject);
                    }
                    break;
                default:
                    break;
            }
        }

    }
}
