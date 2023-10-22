using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblesDeath : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Bubbles"))
        {
            Destroy(gameObject);
        }
    }
}
