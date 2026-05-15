using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{

    private EnemySpawner enemySpawner;
    [SerializeField] GameObject enemySpawnPoint;

    [SerializeField] private int health;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Bullet"))
        {
            health -= 1;
            enemySpawner.SpawnEnemy(enemySpawnPoint.transform.position);
        }

        if (collider.gameObject.CompareTag("Bomb"))
        {
            health -= health;
        }

        if (health == 0)
        {
            Die();
        }
    }


    public void SetEnemySpawner(EnemySpawner enemySpawner)
    {
        this.enemySpawner = enemySpawner;
    }





    private void Die()
    {
        SceneManager.LoadScene("VictoryScene");

    }

}
