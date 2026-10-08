using UnityEngine;
using System.Collections.Generic;

public class EntityStateMachine : MonoBehaviour
{
    Dictionary<string, BaseState> stateLookup = new();

    [SerializeField] BaseState currentState;
    [SerializeField] BaseEntity entityOwner;

    public BaseState CurrentState { get { return currentState; }  }
    private void Start()
    {

        var states = GetComponentsInChildren<BaseState>();
        if (states.Length < 1)
        {
            Debug.LogWarning("No states found.");
            return;
        }

        foreach (BaseState state in states)
        {
            state.Initialize(this, entityOwner);
            stateLookup[state.name] = state;
        }
        if (currentState == null) currentState = states[0];

        currentState.Enter();
    }

    public void TransitionTo(string  name)
    {
      
        if (currentState != null) currentState.Exit();
        currentState = stateLookup[name];
        currentState.Enter();
    }

    public void FixedUpdate()
    {
     if (currentState != null)   currentState.PhysicsProcess();
    }

    public void Update()
    {
       if (currentState != null)  currentState.Process();
    }



}
