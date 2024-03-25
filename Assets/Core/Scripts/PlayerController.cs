using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float turnSpeed = 100;

    void Update()
    {
        if(InputManager.instance == null)
        {
            Debug.LogError("You can't play in Game Menu Scene, need to load Main Menu Scene instead.");
            EditorApplication.isPaused = true;
            return;
        }
        Vector3 movement = new Vector3(InputManager.instance.Movement().x, 0, InputManager.instance.Movement().y);
        Vector3 rotation = new Vector3(0, InputManager.instance.Rotation().x, 0);
        transform.Translate(movement * speed * Time.deltaTime);
        transform.Rotate(rotation * turnSpeed * Time.deltaTime);
    }
}