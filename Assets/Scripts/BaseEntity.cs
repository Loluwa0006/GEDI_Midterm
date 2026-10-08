using UnityEngine;

public class BaseEntity : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidBody;

    public Rigidbody2D RigidBody { get { return rigidBody; } }
    protected EntityStateMachine stateMachine;
}
