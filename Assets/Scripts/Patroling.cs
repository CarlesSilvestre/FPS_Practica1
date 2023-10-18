using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patroling : FSMState
{
    [SerializeField]
    private List<Transform> WayPoints;
    [SerializeField]
    private float thresholdDistance;

    private Vector3 currentDestination;
    protected override void Initialize()
    {
        base.Initialize();
        currentDestination = Vector3.zero;
        state = State.Patroling;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        Patrol();
    }

    private void Patrol()
    {
        if (currentDestination == Vector3.zero || agent.remainingDistance <= agent.stoppingDistance)
        {
            currentDestination = NewPoint();
            agent.destination = currentDestination;
            agent.SetDestination(currentDestination);
            
        }
    }

    private Vector3 NewPoint()
    {
        int randomIndex = UnityEngine.Random.Range(0, WayPoints.Count);
        Vector3 waypoint = WayPoints[randomIndex].position;
        Vector3 randomOffset = new Vector3(UnityEngine.Random.Range(-thresholdDistance, thresholdDistance), 0f, UnityEngine.Random.Range(-thresholdDistance, thresholdDistance));
        return new Vector3(waypoint.x + randomOffset.x, waypoint.y, waypoint.z + randomOffset.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Done = true;
            nextState = State.Alert;
        }
    }
}
