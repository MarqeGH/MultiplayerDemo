using Cinemachine;
using UnityEngine;

public class GameSelect : MonoBehaviour
{
    public CinemachineVirtualCamera vCam;
    public Transform[] gameTypes;
    public bool currentSelect;
    public int selectedGame = 0;

    void Update()
    {
        if(InputManager.instance != null)
        {
            if (InputManager.instance.MainMenuSelect())
                GameManager.instance.LoadGame(selectedGame);
            else if (InputManager.instance.MainMenuMovement().x > 0 && !currentSelect)
            {
                selectedGame++;
                if (selectedGame >= gameTypes.Length)
                    selectedGame = 0;
                if (gameTypes[selectedGame] != null)
                    vCam.LookAt = gameTypes[selectedGame];
                currentSelect = true;
            }
            else if (InputManager.instance.MainMenuMovement().x < 0 && !currentSelect)
            {
                selectedGame--;
                if (selectedGame < 0)
                    selectedGame = gameTypes.Length - 1;
                if (gameTypes[selectedGame] != null)
                    vCam.LookAt = gameTypes[selectedGame];
                currentSelect = true;
            }
            else if (InputManager.instance.MainMenuMovement().x == 0)
                currentSelect = false;
        }
        else
            Debug.LogError("You can't play in Lobby Menu Scene, need to load Main Menu Scene instead.");
    }
}