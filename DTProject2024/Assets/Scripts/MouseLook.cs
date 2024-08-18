
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseLook : MonoBehaviour
{
    // making variables and assets
    public Slider slider;
    public float mouseSensitivity = 400f;
    public Transform playerBody;
    float xRotation = 0f;

    // When the game starts lock the cursor to the middle of the screen, set the slider value to = mouse sensitivity divided by 10, and set the mouse sensitivity to equla the players preferance
    void Start()
    {
        mouseSensitivity = PlayerPrefs.GetFloat("currentSensitivity", 400);
        slider.value = mouseSensitivity/10;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // every frame change the direction the player faces/looks corresponding to where the mouse is dragged
    void Update()
    {
        PlayerPrefs.SetFloat("currentSensitivity", mouseSensitivity);
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    // this functions sets the float "newSpeed" to equal the mouse sensitivity divided by 10
    public void AdjustSpeed(float newSpeed)
    {
        mouseSensitivity = newSpeed * 10;
    }
}