using UnityEngine;

public class PlayerEntity : BaseEntity
{
    [SerializeField] InputManager inputManager;
    [SerializeField] Rigidbody2D rigidBody;

    public Rigidbody2D RigidBody { get { return rigidBody; } }
    public InputManager InputManager { get { return inputManager; } }
}
