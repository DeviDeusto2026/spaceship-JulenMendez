using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemies")]
    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private float spawnCooldown;
    private float timeToNextSpawn;

    [Header("Player")]
    [SerializeField] private GameObject player;
    [SerializeField] private float spawnDistance;

    [Header("Boss")]
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private float timeToBoss;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeToNextSpawn = spawnCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        timeToNextSpawn -= Time.deltaTime;
        timeToBoss -= Time.deltaTime;

        if (timeToNextSpawn > 0) return;

        SpawnEnemy(getSpawnPosition());
        timeToNextSpawn = spawnCooldown;

        if (timeToBoss < 0)
        {
            SpawnBoss();
            this.enabled = false;
        }

    }



    private Vector3 getSpawnPosition()
    {
        Vector3 spawndirection = new Vector3(
            Random.Range(-1, 1),
            Random.Range(-1, 1),
            Random.Range(-1, 1)
        ).normalized;


        Vector3 position = player.transform.position + (spawndirection * spawnDistance);

        if (spawndirection == Vector3.zero) return getSpawnPosition();
        else return position;
    }

    public void SpawnEnemy(Vector3 spawnPosition)
    {
        GameObject enemy = Instantiate(enemyPrefab);

        enemy.transform.position = spawnPosition;
        enemy.transform.LookAt(player.transform);
        enemy.GetComponent<EnemyMovement>().SetPlayer(player);
    }


    private void SpawnBoss()
    {
        GameObject boss = Instantiate(bossPrefab);

        boss.transform.position = Vector3.zero;
        boss.transform.LookAt(player.transform);
        boss.GetComponent<EnemyMovement>().SetPlayer(player);
        boss.GetComponentInChildren<BossHealth>().SetEnemySpawner(this);
    }


}
