using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Alert : FSMState
{
    public float rotationSpeed = 60.0f;
    public float maxFieldOfView = 45.0f;
    private float totalRotation = 0.0f;

    private void OnDrawGizmos()
    {
        Vector3 position = transform.position;

        Gizmos.color = Color.yellow;

        Vector3 startDirection = Quaternion.Euler(0, -maxFieldOfView / 2, 0) * transform.forward;
        Vector3 endDirection = Quaternion.Euler(0, maxFieldOfView / 2, 0) * transform.forward;

        Gizmos.DrawRay(position, startDirection * 10);
        Gizmos.DrawRay(position, endDirection * 10);
    }
    protected override void Initialize()
    {
        base.Initialize();
        state = State.Alert;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if(totalRotation < 360f)
        {
            agent.isStopped = true;
            RotateTowardsPlayer();
        }
        else
        {
            agent.isStopped = false;
            nextState = State.Patroling;
            Done = true;
            totalRotation = 0f;
        }
    }

    private void RotateTowardsPlayer()
    {
        float rotationAmount = rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up * rotationAmount);
        totalRotation += rotationAmount;
        Vector3 playerDirection = playerTransform.position - transform.position;

        float angleToPlayer = Vector3.Angle(transform.forward, playerDirection);

        if (angleToPlayer <= Mathf.Abs(maxFieldOfView))
        {
            nextState = State.Chase;
            Done = true;
            totalRotation = 0f;
            agent.isStopped = false;
        }
    }
}
