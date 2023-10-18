using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
    public string State;
    public bool Done;
    public bool Auxiliar;
    protected NavMeshAgent agent;
    protected Transform playerTransform;
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
