using UnityEditor;
using UnityEngine;

public class GameSelect : MonoBehaviour
{
    public float turnSpeed = 100;
    public GameObject[] gameTypes;
    public bool currentSelect;
    public int gameSelect = 0;

    void Update()
    {
        if(InputManager.instance == null)
        {
            Debug.LogError("You can't play in Lobby Menu Scene, need to load Main Menu Scene instead.");
            EditorApplication.isPaused = true;
            return;
        }
        Vector3 rotation = new Vector3(0, InputManager.instance.Rotation().x, 0);
        transform.Rotate(rotation * turnSpeed * Time.deltaTime);

        //if (InputManager.instance.Movement().x > 0)
        //{
        //    gameSelect++;
        //    if (gameSelect > 7)
        //        gameSelect = 0;
        //    switch (gameSelect)
        //    {
        //        case 0:
        //            Camera.main.transform.LookAt(gameTypes[0].transform, new Vector3(0, 10, 0));
        //            break;
        //        case 1:
        //            Camera.main.transform.LookAt(gameTypes[1].transform, new Vector3(0, 10, 0));
        //            break;
        //        case 2:
        //            Camera.main.transform.LookAt(gameTypes[2].transform, new Vector3(0, 10, 0));
        //            break;
        //        case 3:
        //            Camera.main.transform.LookAt(gameTypes[3].transform, new Vector3(0, 10, 0));
        //            break;
        //        case 4:
        //            Camera.main.transform.LookAt(gameTypes[4].transform, new Vector3(0, 10, 0));
        //            break;
        //        case 5:
        //            Camera.main.transform.LookAt(gameTypes[5].transform, new Vector3(0, 10, 0));
        //            break;
        //        case 6:
        //            Camera.main.transform.LookAt(gameTypes[6].transform, new Vector3(0, 10, 0));
        //            break;
        //        case 7:
        //            Camera.main.transform.LookAt(gameTypes[7].transform, new Vector3(0, 10, 0));
        //            break;
        //        default:
        //            Camera.main.transform.LookAt(gameTypes[0].transform, new Vector3(0, 10, 0));
        //            break;
        //    }
        //    currentSelect = true;
        //}
        //else if (InputManager.instance.Movement().x < 0)
        //{
        //    currentSelect = true;
        //}
        //else
        //{
        //    currentSelect = false;
        //}
    }
}