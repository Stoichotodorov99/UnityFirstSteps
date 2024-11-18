using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
[SerializeField] InputAction thrust;
[SerializeField] InputAction rotation;
[SerializeField] float thrustStrength = 100f;
[SerializeField] float rotationStrength = 100f;
[SerializeField] AudioClip mainEngineSFX;
[SerializeField] ParticleSystem mainEngineParticles;
[SerializeField] ParticleSystem rightThrustEngineParticles;
[SerializeField] ParticleSystem leftThrustEngineParticles;

Rigidbody rb;
AudioSource audioSource;

private void Start() 
{
    rb = GetComponent<Rigidbody>();
    audioSource = GetComponent<AudioSource>();
}
private void OnEnable() {
    thrust.Enable();   
    rotation.Enable(); 
}

 private void FixedUpdate()
    {
        
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        if (thrust.IsPressed() )
        {
            StartThrusting();
        }
        else

        {
            StopThrusting();
        }

    }

     private void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngineSFX);
        }
        if (!mainEngineParticles.isPlaying)
        {
            mainEngineParticles.Play();
        }
    }

    private void StopThrusting()
    {
        audioSource.Stop();
        mainEngineParticles.Stop();
    }

   

    private void ProcessRotation()
    {
       float rotationInput =  rotation.ReadValue<float>();
       if (rotationInput < 0)
        {
            RotateRight();
        }
        else if (rotationInput > 0)
        {
            RotateLeft();
        }
        else
        {
            StopRotating();
        }
    }

    private void RotateRight()
    {
        ApplyRotation(rotationStrength);

        if (!rightThrustEngineParticles.isPlaying)
        {
            leftThrustEngineParticles.Stop();
            rightThrustEngineParticles.Play();
        }
    }


    private void RotateLeft()
    {
        ApplyRotation(-rotationStrength);

        if (!leftThrustEngineParticles.isPlaying)
        {
            rightThrustEngineParticles.Stop();
            leftThrustEngineParticles.Play();
        }
    }

    private void StopRotating()
    {
        leftThrustEngineParticles.Stop();
        rightThrustEngineParticles.Stop();
    }

    


    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.fixedDeltaTime);
        rb.freezeRotation = false; 

    }
}

// audicity