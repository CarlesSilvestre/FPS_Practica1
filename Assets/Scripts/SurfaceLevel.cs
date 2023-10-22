using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceLevel : MonoBehaviour
{
    private FPSController player;
    private void OnTriggerEnter(Collider collision)
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();
        if (!gameObject.name.Equals("DarkLevel"))
        {
            player.m_underWater = !player.m_underWater;
        }

    }
}
