using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
            rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);
            if ( !audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngineSFX);
            } 
            if (!mainEngineParticles.isPlaying)
            {
            mainEngineParticles.Play();    
            }       
        }
         else 
          
            {
            audioSource.Stop();
            mainEngineParticles.Stop();
            }
      
    }
    private void ProcessRotation()
    {
       float rotationInput =  rotation.ReadValue<float>();
       if (rotationInput < 0)
        {
            ApplyRotation(rotationStrength);

            if (!rightThrustEngineParticles.isPlaying)
            {
                leftThrustEngineParticles.Stop();
                rightThrustEngineParticles.Play();    
            }       
        }
        else if (rotationInput > 0)
       {
            ApplyRotation(-rotationStrength);

            if (!leftThrustEngineParticles.isPlaying)
            {
                rightThrustEngineParticles.Stop();
                leftThrustEngineParticles.Play();    
            }    
        }
        else
        {
            leftThrustEngineParticles.Stop();
            rightThrustEngineParticles.Stop();
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.fixedDeltaTime);
        rb.freezeRotation = false; 

    }
}

// audicity