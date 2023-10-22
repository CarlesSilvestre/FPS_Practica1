using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geiser: MonoBehaviour
{
    FPSController player;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
            player.m_verticalVelocity = 4;
    }
}
