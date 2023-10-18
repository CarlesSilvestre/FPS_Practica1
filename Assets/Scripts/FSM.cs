using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum State
{
    Idle, Patroling, Alert, Chase, Dead, Attack,
}
public class FSM : MonoBehaviour
{
    protected virtual void Initialize() { }
    protected virtual void FSMUpdate() { }
    protected virtual void FSMFixedUpdate() { }

    void Start()
    {
        Initialize();
    }
    void Update()
    {
        FSMUpdate();
    }
    void FixedUpdate()
    {
        FSMFixedUpdate();
    }
}
public abstract class FSMState : MonoBehaviour
{
    protected State state;
    public bool Done;
    protected State nextState;
    protected NavMeshAgent agent;
    protected Transform playerTransform;

    public State State { get => state; set => state = value; }
    public State NextState { get => nextState; set => nextState = value; }

    private void Start()
    {
        Initialize();
    }
    public virtual void UpdateState() { }
    protected virtual void Initialize()
    {
        Done = false;
        agent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
