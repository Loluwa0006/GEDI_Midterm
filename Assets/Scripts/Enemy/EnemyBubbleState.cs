using System.Collections.Generic;
using UnityEngine;

public class EnemyBubbleState : BaseState
{

    static int BASE_DURATION = 7;
    float duration = 0.0f;

    public override void Enter(Dictionary<string, object> msg = null)
    {
        duration = BASE_DURATION;
        
    }

    public override void Process()
    {
        duration -= Time.deltaTime;
        if (duration <= 0.0f)
        {
            StateMachine.TransitionTo("EnemyWalk");
        }
    }
}
