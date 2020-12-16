using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    public float mousesensativity = 100f;

    Transform playerBody;
    float xRotation = 0f;
   void Start()
    {
        playerBody = GameObject.Find("Player").transform;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mousex = Input.GetAxis("Mouse X") * mousesensativity * Time.deltaTime;
        float mousey = Input.GetAxis("Mouse Y") * mousesensativity * Time.deltaTime;

        xRotation += mousey;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerBody.Rotate(Vector3.up * mousex);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
