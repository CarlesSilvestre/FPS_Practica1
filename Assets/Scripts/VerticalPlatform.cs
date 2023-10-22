using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    public Transform targetPoint;
    public float speed = 5.0f;

    private Vector3 initialPos;
    private Vector3 targetPos;
    private Vector3 maxPos;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
        targetPos = initialPos;
        maxPos = targetPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position != targetPos)
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            targetPos = maxPos;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            targetPos = initialPos;
        }
    }
}
