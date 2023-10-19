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
    private void OnDrawGizmos()
    {
        Vector3 position = transform.position;

        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(position, thresholdDistance);
    }
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
        CheckDisturbed();
    }

    private void CheckDisturbed()
    {
        float distance = Vector3.Distance(transform.position, playerTransform.position);
        if (distance <= thresholdDistance)
        {
            Done = true;
            nextState = State.Alert;
        }
    }

    private void Patrol()
    {
        agent.isStopped = false;
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
}
