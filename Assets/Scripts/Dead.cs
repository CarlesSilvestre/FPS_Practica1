using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : FSMState
{
    private bool deadAlready;
    protected override void Initialize()
    {
        base.Initialize();
        state = State.Dead;
        deadAlready = false;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        //Animation
        if (!deadAlready)
        {
            Destroy(agent);
            gameObject.AddComponent<Rigidbody>().useGravity = true;
            deadAlready = true;
        }
    }

}
