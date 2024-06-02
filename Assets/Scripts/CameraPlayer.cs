using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 800f;
    public Transform orientation;

    private float xRotation = 0f;
    private float yRotation = 0f;

    void Start()
    {
        // Скрывает курсор и фиксирует его в центре экрана
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Получаем движение мыши
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Уменьшаем значение по Y для поворота вверх/вниз
        xRotation -= mouseY;
        yRotation += mouseX;
        
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Ограничиваем угол поворота вверх/вниз

        // Поворачиваем камеру только по оси X
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.localRotation = Quaternion.Euler(0, yRotation, 0);

        // playerBody.Rotate(Vector3.up * mouseX);
        // transform.Rotate(Vector3.up * mouseX);
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }
}
