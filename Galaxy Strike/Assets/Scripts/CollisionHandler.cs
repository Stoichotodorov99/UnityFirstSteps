using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject playerDestroyVFX;
      GameSceneManager gameSceneManager;
    
    private void Start() {
        gameSceneManager = FindFirstObjectByType<GameSceneManager>();
    }
private void OnTriggerEnter(Collider other) {

    gameSceneManager.ReloadLevel();
    Instantiate(playerDestroyVFX, transform.position, Quaternion.identity);
    Destroy(this.gameObject);

    
    }
}

