using UnityEngine;

public class PlayerBaseState : BaseState
{
    public PlayerEntity Player { get; private set; }

    public override void Initialize(EntityStateMachine stateMachine, BaseEntity entity)
    {
        base.Initialize(stateMachine, entity);
        Player = entity.GetComponent<PlayerEntity>();
    }

    public bool IsGrounded()
    {
        return Physics2D.Raycast(Player.RigidBody.position, Vector2.down, 0.65f, LayerMask.GetMask("Ground"));
    }
}
