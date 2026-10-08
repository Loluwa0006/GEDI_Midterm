using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    [SerializeField] float moveSpeed = 10.0f;
    [SerializeField] int accelerationFrames = 7;

    [SerializeField] float jumpPower = 15.0f;
    public override void PhysicsProcess()
    {
        base.PhysicsProcess();

        float moveDirection = Player.InputManager.GetMovementDirection();
        float acceleration = (moveSpeed / accelerationFrames) * Player.InputManager.GetMovementDirection();


        Player.RigidBody.AddForce(new Vector2(moveDirection * acceleration, 0), ForceMode2D.Impulse);
        Player.RigidBody.linearVelocityX = Mathf.Clamp(Player.RigidBody.linearVelocityX, -moveSpeed, moveSpeed);

        if (!IsGrounded())
        {
            StateMachine.TransitionTo("PlayerAir");
        }
    }

    public override void Process()
    {
        base.Process();
        if (Player.InputManager.IsJumpPressed())
        {

        }
    }
}
