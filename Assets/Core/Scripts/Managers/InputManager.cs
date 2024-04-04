using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    public InputSystem inputSystem;

    private void Awake()
    {
        instance = this;
        inputSystem = new InputSystem();
        inputSystem.MainMenu.Enable();
        inputSystem.Game1.Enable();
    }

    #region MainMenu Controls
    public Vector2 MainMenuMovement()
    {
        if (!inputSystem.MainMenu.Movement.enabled)
            inputSystem.MainMenu.Movement.Enable();
        return inputSystem.MainMenu.Movement.ReadValue<Vector2>();
    }

    public bool MainMenuSelect()
    {
        if (!inputSystem.MainMenu.Select.enabled)
            inputSystem.MainMenu.Select.Enable();
        return inputSystem.MainMenu.Select.WasPressedThisFrame();
    }

    public bool MainMenuChat()
    {
        if (!inputSystem.MainMenu.Chatbox.enabled)
            inputSystem.MainMenu.Chatbox.Enable();
        return inputSystem.MainMenu.Chatbox.WasPressedThisFrame();
    }
    #endregion

    #region Game1 Controls
    public Vector2 Game1Movement()
    {
        if (!inputSystem.Game1.Movement.enabled)
            inputSystem.Game1.Movement.Enable();
        return inputSystem.Game1.Movement.ReadValue<Vector2>();
    }

    public Vector2 Game1Rotation()
    {
        if (!inputSystem.Game1.Rotation.enabled)
            inputSystem.Game1.Rotation.Enable();
        return inputSystem.Game1.Rotation.ReadValue<Vector2>();
    }
    #endregion
}