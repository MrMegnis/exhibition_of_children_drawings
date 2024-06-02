using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public Transform orientation;

    void Update()
    {
        // Получаем ввод с клавиатуры
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Вычисляем направление движения
        Vector3 move = orientation.right * x + orientation.forward * z;

        // Двигаем игрока
        controller.Move(move * speed * Time.deltaTime);
    }
}
