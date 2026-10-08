using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputManager : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;

    private void Start()
    {
        if (playerInput == null) playerInput = GetComponent<PlayerInput>();
    }
    public float GetMovementDirection()
    {
        return playerInput.actions["Left"].ReadValue<float>() - playerInput.actions["Right"].ReadValue<float>();
    }

    public bool IsJumpPressed()
    {
        return playerInput.actions["Jump"].IsPressed();
    }

    public bool WasBubblePressed()
    {
        return playerInput.actions["Bubble"].WasPerformedThisFrame();
    }
}
