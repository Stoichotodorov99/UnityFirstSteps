using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 movement;
    Rigidbody rigidBody;
   [SerializeField] float moveSpeed = 5f;
   [SerializeField] float xClamp = 4f;
   [SerializeField] float zClamp = 2.5f;
    
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        HandleMovement();

    }

   public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
       
    }
   public void HandleMovement()
    {
        Vector3 currentposition = rigidBody.position;
        Vector3 moveDirection = new Vector3(movement.x, 0f, movement.y);
        Vector3 newPosition = currentposition + moveDirection * (moveSpeed * Time.fixedDeltaTime);

        newPosition.x = Mathf.Clamp(newPosition.x, -xClamp, xClamp);
        newPosition.z = Mathf.Clamp(newPosition.z, -zClamp, zClamp);
        rigidBody.MovePosition(newPosition);

    }
}
