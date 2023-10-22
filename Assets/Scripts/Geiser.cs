using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geiser: MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
            other.GetComponent<FPSController>().m_verticalVelocity = 4;
    }
}
