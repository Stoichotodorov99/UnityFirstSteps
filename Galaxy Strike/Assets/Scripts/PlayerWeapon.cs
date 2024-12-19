using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    bool isFiring = false;

    private void Update() {
        ProcessFiring();
    }
    public void OnFire(InputValue value)
    {
      isFiring = value.isPressed;  
    }
    void ProcessFiring()
    {
        foreach (GameObject laser in lasers)
        {
            var emmitionModule = laser.GetComponent<ParticleSystem>().emission;
            emmitionModule.enabled = isFiring;
            
        }
    }
}