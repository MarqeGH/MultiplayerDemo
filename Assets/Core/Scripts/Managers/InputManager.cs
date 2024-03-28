using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    public InputSystem inputSystem;

    private void Awake()
    {
        instance = this;
        inputSystem = new InputSystem();
        inputSystem.Controller.Enable();
    }

    public Vector2 Movement()
    {
        if (!inputSystem.Controller.Movement.enabled)
            inputSystem.Controller.Movement.Enable();
        return inputSystem.Controller.Movement.ReadValue<Vector2>();
    }

    public Vector2 Rotation()
    {
        if (!inputSystem.Controller.Rotation.enabled)
            inputSystem.Controller.Rotation.Enable();
        return inputSystem.Controller.Rotation.ReadValue<Vector2>();
    }
}