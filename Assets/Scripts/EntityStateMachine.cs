using UnityEngine;
using System.Collections.Generic;

public class EntityStateMachine : MonoBehaviour
{
    Dictionary<System.Type, BaseState> stateLookup = new();

    [SerializeField] BaseState currentState;
    [SerializeField] BaseEntity entityOwner;
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
            stateLookup[state.GetType()] = state;
        }
        if (currentState == null) currentState = states[0];

        currentState.Enter();
    }

    public void TransitionTo<T>() where T : BaseState
    {
        if (!stateLookup.ContainsKey(typeof(T)))
        {
            Debug.LogWarning("Missing state of type " + typeof(T));
        }
        if (currentState != null) currentState.Exit();
        currentState = stateLookup[typeof(T)];
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
