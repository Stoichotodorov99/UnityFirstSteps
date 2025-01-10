using UnityEngine;

public class Enemy : MonoBehaviour
{

[SerializeField] GameObject enemyDestroyVFX;
[SerializeField] int hitPoint = 3;
[SerializeField] int scoreValue = 10;
Scoreboard scoreboard;

private void Start() {
    scoreboard = FindFirstObjectByType<Scoreboard>();
}
private void OnParticleCollision(GameObject other)
    {
        ProcessHit();

    }

    private void ProcessHit()
    {
        hitPoint--;
        if (hitPoint <= 0)
        {
            scoreboard.IncreaseScore(scoreValue);
            Instantiate(enemyDestroyVFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);

        }
    }
}
