using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouselook : MonoBehaviour
{
    public float mouseSensitivity = 0.2f;
    public Transform playerBody;

    private float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //lock cursor in the midded of screen, so you dont click out of game
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
       float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp (xRotation, -90f, 90f); // Limit how far player model can rotate, you can't look too high up above human limitation

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
       playerBody.Rotate(Vector3.up * mouseX);
    }
}
