using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
private void OnCollisionEnter(Collision other) 
{
    switch (other.gameObject.tag)
    {
        case "Friendly":
        break;

        case "Fuel" :
        break;

        case "Finish":
        break;

        default:
        ReloadLevel();
        break;
    }

    void ReloadLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);

    }
}
}
