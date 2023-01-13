using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    WaveConfigSO currentWave;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] List<WaveConfigSO> waveConfigs;
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }
    public WaveConfigSO GetCurrentWave(){
        return currentWave;
    }
    IEnumerator SpawnEnemies(){ //SpawnsEnemyWaves
        foreach (WaveConfigSO wave in waveConfigs)
        {
            currentWave = wave;
            for (int i = 0; i < currentWave.GetEnemyCount(); i++)
            {
                Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetStartingWaypoin().position, Quaternion.identity, transform);
                yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
            }   
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }
}
