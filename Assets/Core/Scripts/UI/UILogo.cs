using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILogo : MonoBehaviour
{
    public float rotationSpeed = 3;
    public Image logo;

    void Update()
    {
        logo.transform.Rotate(new Vector3(0, 0, Mathf.Lerp(10, -10, Mathf.PingPong(Time.time, 1))) * rotationSpeed * Time.deltaTime);
        logo.transform.localScale = new Vector3(Mathf.Lerp(0.7f, 1f, Mathf.PingPong(Time.time, 0.5f)), Mathf.Lerp(0.7f, 1f, Mathf.PingPong(Time.time, 0.5f)), Mathf.Lerp(0.7f, 1f, Mathf.PingPong(Time.time, 0.5f)));
    }
}