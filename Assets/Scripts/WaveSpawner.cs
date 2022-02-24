using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public Transform enemyPrefab;
    public Transform fastEnemyPrefab;
    public Transform strongEnemyPrefab;

    public static int enemiesAlive;
    public float timeBetweenWaves = 4f;
    private float countdown = 4f;

    public Text waveCountdownText;
    public Text roundsCounter;

    public Transform spawnPoint;

    private int waveIndex = 0;

    void Update()
    {
        if (waveIndex == 0)
        {
            enemiesAlive = 0;
        }

        if (enemiesAlive > 0)
            return;

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);

        roundsCounter.text = "Rounds: " + PlayerStats.Rounds;
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        PlayerStats.Rounds++;

        for (int i = 0; i < waveIndex; i++)
        {
            int enemyType = Random.Range(1, 4);

            if (enemyType == 1)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(0.5f);
                enemiesAlive++;
            }

            if (enemyType == 2)
            {
                SpawnFastEnemy();
                yield return new WaitForSeconds(0.3f);
                enemiesAlive++;
            }

            if (enemyType == 3)
            {
                SpawnStrongEnemy();
                yield return new WaitForSeconds(1f);
                enemiesAlive++;
            }
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
    void SpawnFastEnemy()
    {
        Instantiate(fastEnemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
    void SpawnStrongEnemy()
    {
        Instantiate(strongEnemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
