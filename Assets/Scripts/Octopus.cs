using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octopus : FSM
{
    [Header("FSM")] //Current state that the NPC is reaching
    public List<FSMState> states;

    private FSMState m_State;


    protected override void Initialize()
    {
        base.Initialize();
        m_State = states[0];
    }
    protected override void FSMUpdate()
    {
        CheckState();
        m_State.UpdateState();
    }

    private void CheckState()
    {
        if (m_State.Done)
        {
            State st = m_State.NextState;
            m_State.Done = false;
            m_State = states.Find(state => state.State == st);
        }
    }
}
