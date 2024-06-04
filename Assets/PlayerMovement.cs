using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public Transform orientation;
    private float _horizontalInput;
    private float _verticalInput;
    private Vector3 _movementDirection;
    private Rigidbody _rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _rigidBody.freezeRotation = true;
    }

    private void InputFromDevice(){
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate(){
        PlayerMove();
    }

    // Update is called once per frame
    void Update()
    {
        InputFromDevice();
    }

    private void PlayerMove(){
        _movementDirection = orientation.forward * _verticalInput + orientation.right * _horizontalInput;

        _rigidBody.AddForce(_movementDirection * moveSpeed * 10f, ForceMode.Force);
    }
}
