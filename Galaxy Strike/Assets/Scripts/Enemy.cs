using UnityEngine;

public class Enemy : MonoBehaviour
{

[SerializeField] GameObject enemyDestroyVFX;
private void OnParticleCollision(GameObject other) {
    
    Instantiate(enemyDestroyVFX, transform.position, Quaternion.identity);
    Destroy(this.gameObject);
}
}
