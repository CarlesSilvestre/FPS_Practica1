using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPlatform : MonoBehaviour
{
    public List<Transform> wayPoints;
    public float speed;
    public bool flag;
    private int nextPoint = 0;
    private int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = wayPoints[0].position;
        nextPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != wayPoints[nextPoint].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, wayPoints[nextPoint].position, speed * Time.deltaTime);
        }
        else
        {
            nextPoint += direction;
            if(nextPoint == wayPoints.Count || nextPoint < 0)
            {
                if (flag)
                {
                    direction *= -1;
                    nextPoint += direction;
                }
                else
                {
                    nextPoint = 0;
                }
            }
        }
    }
}
