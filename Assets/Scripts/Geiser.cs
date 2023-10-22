using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geiser: MonoBehaviour
{
    FPSController player;
    private void OnTriggerEnter(Collider other)
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();
        player.m_verticalVelocity = 4;
    }
}
