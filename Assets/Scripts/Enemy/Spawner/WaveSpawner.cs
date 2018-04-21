using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    public Transform enemyPrefab;

    //Left and Right Bounds of whatever door enemies spawn through;
    public Transform spawnPointA;
    public Transform spawnPointB;

    public float timeBetweenWaves = 5f;
    public float pauseDuringWave = .1f;

    //Time until first wave
    private float countdown = 2f;

    private int waveIndex = 0;

    private void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave(waveIndex++));
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave(int waveCount)
    {
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(pauseDuringWave);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, positionInRange(spawnPointA.position, spawnPointB.position), spawnPointA.rotation);
    }

    Vector3 positionInRange(Vector3 a, Vector3 b)
    {
        return new Vector3(
            Random.Range(a.x, b.x),
            Random.Range(a.y, b.y),
            Random.Range(a.z, b.z));
    }
}
