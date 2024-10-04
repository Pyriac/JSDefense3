using UnityEngine;
using System.Collections;
using TMPro;

public class WaveSpawner : MonoBehaviour
{

[SerializeField]
private Transform enemyPrefab;

[SerializeField]
private Transform spawnPoint;

[SerializeField]
private float timeBetweenWaves = 5.5f;

private float countdown = 5f;

[SerializeField]
private TextMeshProUGUI WaveCountdownTimer;

[SerializeField]
private TextMeshProUGUI WaveCount;

private int waveIndex = 0;

    void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        WaveCountdownTimer.text = "Prochaine vague : " + string.Format("{00:0.0}", countdown);
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        WaveCount.text = "Vague " + waveIndex.ToString();
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
