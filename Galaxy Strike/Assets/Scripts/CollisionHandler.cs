using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject playerDestroyVFX;
private void OnTriggerEnter(Collider other) {

    Instantiate(playerDestroyVFX, transform.position, Quaternion.identity);
    Destroy(this.gameObject);

    
    }
}

