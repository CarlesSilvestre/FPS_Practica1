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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_State = states.Find(state => state.State == "Alert");
        }
    }

    private void CheckState()
    {
        string st = m_State.State;
        if (m_State.Done)
        {
            switch (st)
            {
                case "Patroling":
                    m_State = states.Find(state => state.State == "Idle");
                    break;
                case "Alert":
                    if (m_State.Auxiliar)
                    {
                        m_State = states.Find(state => state.State == "Chase");
                    }
                    else
                    {
                        m_State = states.Find(state => state.State == "Patroling");
                    }
                    break;
                case "Chase":
                    if (m_State.Auxiliar)
                    {
                        Debug.Log("Attack");
                    }
                    else
                    {
                        m_State = states.Find(state => state.State == "Patroling");
                    }
                    break;
            }
            m_State.Done = false;
            m_State.Auxiliar = false;
        }
    }
}
