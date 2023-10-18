using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : FSMState
{
    public float chaseSpeed;
    public float minDistance;
    public float maxDistance;
    private void OnDrawGizmos()
    {
        Vector3 position = transform.position;

        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(position, minDistance);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(position, maxDistance);
    }
    protected override void Initialize()
    {
        base.Initialize();

    }

    public override void UpdateState()
    {
        base.UpdateState();
        ChasePlayer();
    }

    private void ChasePlayer()
    {
        agent.speed = chaseSpeed;
        float playerDistance = Vector3.Distance(playerTransform.position, transform.position);
        agent.destination = playerTransform.position;
        if (playerDistance <= minDistance)
        {
            agent.isStopped = true;
            Done = true;
            Auxiliar = true;
        }
        else if(playerDistance >= maxDistance)
        {
            Done = true;
            Auxiliar = false;
        }
    }
}
