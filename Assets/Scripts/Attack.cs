using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : FSMState
{
    public Transform firePoint;
    public float damage = 0.0f;
    public float shootMax;
    public float fireRate;
    private float myTime = 0.0f;
    protected override void Initialize()
    {
        base.Initialize();
        state = State.Attack;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        myTime += Time.deltaTime;
        if(myTime > fireRate)
        {
            Shoot();
            myTime = 0f;
        }
        CheckDistance();
    }

    private void CheckDistance()
    {
        float playerDistance = Vector3.Distance(playerTransform.position, transform.position);
        agent.destination = playerTransform.position;
        if (playerDistance >= shootMax)
        {
            Done = true;
            nextState = State.Chase;
            StopAllCoroutines();
        }
    }

    private void Shoot()
    {
        Vector3 rayOrigin = firePoint.position;
        Vector3 rayDirection = playerTransform.position - rayOrigin;

        RaycastHit hit;

        // Perform the raycast
        if (Physics.Raycast(rayOrigin, rayDirection, out hit, shootMax))
        {
            IDamageable damageable = hit.collider.gameObject.GetComponent<IDamageable>();
            // Hit object
            if (damageable != null)
            {
                damageable.TakeDamage(damage, hit.point);
            }
        }
        else
        {
        }
    }

}
