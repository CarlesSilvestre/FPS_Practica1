using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Octopus : FSM, IDamageable
{
    public float maxHP;
    public Image lifeBar;
    [SerializeField]
    [Header("FSM")] //Current state that the NPC is reaching
    public List<FSMState> states;
    public Collider head;
    private FSMState m_State;
    private float mHp;


    protected override void Initialize()
    {
        base.Initialize();
        m_State = states[0];
        mHp = maxHP;
    }
    protected override void FSMUpdate()
    {
        if (mHp <= 0)
            Die();
        CheckState();
        m_State.UpdateState();
        UpdateLifeBar();
    }

    private void CheckState()
    {
        if (m_State.Done)
        {
            State previous = m_State.State;
            State next = m_State.NextState;
            m_State.Done = false;
            m_State = states.Find(state => state.State == next);
            if (next == State.Hit)
            {
                if (previous == State.Patroling)
                    m_State.NextState = State.Alert;
                else m_State.NextState = previous;
            }
        }
    }
    public void TakeDamage(float amount, Vector3 hitPoint)
    {
        if (head.bounds.Contains(hitPoint))
        {
            mHp -= amount;
        }
        m_State.Done = true;
        m_State.NextState = State.Hit;
        if (mHp <= 0)
            Die();
    }

    public void Die()
    {
        m_State.NextState = State.Dead;
    }
    private void UpdateLifeBar()
    {
        lifeBar.fillAmount = mHp / maxHP;
        
    }
}
