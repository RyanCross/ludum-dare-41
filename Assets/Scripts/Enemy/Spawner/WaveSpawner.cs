using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    public Transform enemyPrefab;

    public static int waveNum = 1;

    //Left and Right Bounds of whatever door enemies spawn through;
    public Transform spawnPointA;
    public Transform spawnPointB;

    public float timeBetweenWaves = 5f;
    public float pauseDuringWave = .1f;
    public int firstPush = 5;
    public int secondPush = 9;

    //Time until first wave
    private float countdown = 2f;
    private int waveIndex = 0;

    private void Update()
    {
        if (waveNum == 1)
        {
            FirstWave();
        }
        else if (waveNum == 2)
        {
            SecondWave();
        }
    }

    /*
     * Spawn a wave of waveCount zombies from this gate. 
     */
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

    private void FirstWave()
    {
        if (countdown <= 0f && waveIndex < firstPush)
        {
            StartCoroutine(SpawnWave(waveIndex++));
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }

    private void SecondWave()
    {
        if (countdown <= 0f && waveIndex < secondPush)
        {
            StartCoroutine(SpawnWave(waveIndex++));
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }
}
