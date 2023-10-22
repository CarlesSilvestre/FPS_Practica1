using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceLevel : MonoBehaviour
{
    private FPSController player;
    private void OnTriggerEnter(Collider2D collision)
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();
        player.m_underWater = !player.m_underWater;
        
    }
}
