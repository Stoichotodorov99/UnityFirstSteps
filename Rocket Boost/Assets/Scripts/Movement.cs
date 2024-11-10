using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
[SerializeField] InputAction thrust;
[SerializeField] float thrustStrength = 100f;
Rigidbody rb;

private void Start() 
{
    rb = GetComponent<Rigidbody>();
}
private void OnEnable() {
    thrust.Enable();    
}

 private void FixedUpdate() 
 {
    if (thrust.IsPressed()) {
         rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);    }
}

}
