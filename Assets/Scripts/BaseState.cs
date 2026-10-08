using System.Collections.Generic;
using UnityEngine;

public class BaseState : MonoBehaviour
{
    public EntityStateMachine StateMachine { get; set; }
    public BaseEntity Entity { get; set; }

    public virtual void Initialize(EntityStateMachine stateMachine, BaseEntity entity)
    {
        StateMachine = stateMachine;
        Entity = entity;
    }
    public virtual void Enter(Dictionary<string, object> msg = null)
    {

    }
    public virtual void Process()
    {

    }

    public virtual void PhysicsProcess()
    {

    }

    public virtual void Exit()
    {

    }
    //For things like cooldowns that need to be managed indepedent of whether this state is active or not
    public virtual void InactiveProcess()
    {

    } 

    public virtual void InactivePhysicsProcess()
    {

    }
}
