using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : FSMState
{
    public float stunTime = 0.0f;
    private bool isStunned;
    protected override void Initialize()
    {
        base.Initialize();
        state = State.Hit;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (!isStunned)
        {
            StartCoroutine(Stun());
        }
    }

    private IEnumerator Stun()
    {
        agent.isStopped = true;
        isStunned = true;
        Debug.Log("Stunned");
        yield return new WaitForSeconds(stunTime);
        Debug.Log("Not Stunned");
        isStunned = false;
        Done = true;
    }
}
