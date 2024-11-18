using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float levelLoadDellay = 2f;
   [SerializeField] AudioClip successSFX;
   [SerializeField] AudioClip crashSFX;
   [SerializeField] ParticleSystem SuccessParticle;
   [SerializeField] ParticleSystem crashParticle;
   AudioSource audioSource;

   bool isControllable = true;
   bool isCollidable = true;

private void Start()
 {
    audioSource = GetComponent<AudioSource>();


    
}
private void Update() {

    RespondToDebugKeys();
}

    private void RespondToDebugKeys()
    {
        if (Keyboard.current.lKey.wasPressedThisFrame)
   { 
        LoadNextLevel();
   }
        else if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            isCollidable = !isCollidable;
        }
    }

    private void OnCollisionEnter(Collision other) 
{
    if (!isControllable || !isCollidable) {return;}
    switch (other.gameObject.tag)
{
    case "Friendly":
    break;

    case "Finish":
    StartSuccessSequence();
    break;

    default:
    StartCrashSequence();
    
    break;
}

}

    private void StartSuccessSequence()
    {
        audioSource.Stop();
        isControllable = false;
        audioSource.PlayOneShot(successSFX);
        GetComponent<Movement>().enabled = false;
        SuccessParticle.Play();
        Invoke("LoadNextLevel", levelLoadDellay);
    }

    private void StartCrashSequence()
    {
        audioSource.Stop();
        isControllable = false;
        audioSource.PlayOneShot(crashSFX);
        crashParticle.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", levelLoadDellay);
    }


    void LoadNextLevel()
{
    int currentScene = SceneManager.GetActiveScene().buildIndex;
    int nextScene = currentScene + 1;
    if (nextScene == SceneManager.sceneCountInBuildSettings)
    {
        nextScene = 0;
    }
        SceneManager.LoadScene(nextScene);
}

    void ReloadLevel()
{
    int currentScene = SceneManager.GetActiveScene().buildIndex;

    SceneManager.LoadScene(currentScene);

}


}
