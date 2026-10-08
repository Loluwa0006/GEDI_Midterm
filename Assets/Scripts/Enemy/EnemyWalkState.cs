using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkState : BaseState
{
    [SerializeField] int minWalkTime = 2;
    [SerializeField] int maxWalkTime = 7;

    float walkTime;

    int direction;
    public override void Enter(Dictionary<string, object> msg = null)
    {
        base.Enter(msg);
        ChangeDirection();
    }

    void ChangeDirection()
    {
        walkTime = Random.Range(minWalkTime, maxWalkTime);
        direction = Random.Range(-1, 2);
    }

    public override void PhysicsProcess()
    {
        walkTime -= Time.deltaTime;
        if (walkTime < minWalkTime)
        {
            ChangeDirection();
        }
    }
}
