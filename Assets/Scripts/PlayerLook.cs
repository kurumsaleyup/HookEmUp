using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Joystick joystick;
    float mouseX, mouseY, mouseSensivity=100f, XRotation=0f;
    public Transform playerbody;

    // Update is called once per frame
    void Update()
    {
        mouseX = joystick.Direction.x * mouseSensivity * Time.deltaTime;
        mouseY = joystick.Direction.y * mouseSensivity * Time.deltaTime;
        playerbody.Rotate(Vector3.up*mouseX);

        XRotation -= mouseY;
        XRotation = Mathf.Clamp(XRotation,-90f,12f);

        transform.localRotation = Quaternion.Euler(XRotation,0f,0f);

    }
}
