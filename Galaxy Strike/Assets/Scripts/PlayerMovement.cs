using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xClampRange = 35f;
    [SerializeField] float yClampRange = 35f;

    [SerializeField] float controlRollFactor = 20f;
    Vector2 movement;
       void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }


    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
     void ProcessTranslation()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);

        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yClampRange, yClampRange);


        transform.localPosition = new Vector3(clampedXPos, clampedYPos + yOffset, 0f);
    }
    void ProcessRotation() {
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, -controlRollFactor * movement.x);
        transform.localRotation = targetRotation;
    }
}
