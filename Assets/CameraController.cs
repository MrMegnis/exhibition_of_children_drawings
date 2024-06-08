using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float distance = 5.0f;
    public float mouseSensitivity = 100.0f;
    public float yMinLimit = -40f;
    public float yMaxLimit = 80f;

    private float rotationY = 0.0f;
    private float rotationX = 0.0f;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        rotationY = angles.y;
        rotationX = angles.x;

        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        if (target)
        {
            rotationY += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            rotationX -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            rotationX = Mathf.Clamp(rotationX, yMinLimit, yMaxLimit);

            Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0);
            transform.rotation = rotation;
            transform.position = target.position - (rotation * Vector3.forward * distance);
        }
    }
}

