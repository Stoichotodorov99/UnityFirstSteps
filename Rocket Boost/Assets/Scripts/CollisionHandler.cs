using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float levelLoadDellay = 2f;
   [SerializeField] AudioClip success;
   [SerializeField] AudioClip crash;
   AudioSource audioSource;
private void Start()
 {
    audioSource = GetComponent<AudioSource>();
    
}

private void OnCollisionEnter(Collision other) 
{
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
        audioSource.PlayOneShot(success);
        GetComponent<Movement>().enabled = false;

        Invoke("LoadNextLevel", levelLoadDellay);
    }

    private void StartCrashSequence()
    {
        audioSource.PlayOneShot(crash);
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
