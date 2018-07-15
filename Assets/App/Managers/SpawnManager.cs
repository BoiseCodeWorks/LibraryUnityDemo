using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Spawnable
{
    public GameObject Enemy;
    public int Quantity;
    public GameObject SpawnPoint;
}

[System.Serializable]
public class SpawnWave
{
    public List<GameObject> SpawnPoints;
    public List<Spawnable> Spawnables;
    public List<Spawnable> EnemiesToSpawn;

    public float WaveDelay = 1;
    public float SpawnDelay = .25f;


    public void PrepareWave()
    {
        //I need to figure out a place to spawn 
        //each type of spawnable as well as the quatity 
        //for each spawnable type.
        EnemiesToSpawn = new List<Spawnable>();
        Spawnables.ForEach(spawnable =>
        {
            for (var i = 0; i < spawnable.Quantity; i++)
            {
                var enemy = new Spawnable()
                {
                    Enemy = spawnable.Enemy,
                };
                if (spawnable.SpawnPoint == null)
                {
                    var spawnIndex = UnityEngine.Random.Range(0, SpawnPoints.Count);
                    enemy.SpawnPoint = SpawnPoints[spawnIndex];
                }
                else
                {
                    enemy.SpawnPoint = spawnable.SpawnPoint;
                }

                EnemiesToSpawn.Add(enemy);
            }
        });
    }
}

public class SpawnManager : MonoBehaviour
{
    public List<SpawnWave> SpawnWaves;
    int spawnWaveIndex = -1;
    SpawnWave currentWave;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            spawnWaveIndex += 1;
            if (spawnWaveIndex < SpawnWaves.Count)
            {
                currentWave = SpawnWaves[spawnWaveIndex];
                currentWave.PrepareWave();
                StartCoroutine(StartSpawn());
            }
            else
            {
                Debug.Log("NO MORE WAVES");
            }
        }
    }

    IEnumerator StartSpawn()
    {
        foreach (var item in currentWave.EnemiesToSpawn)
        {
            yield return new WaitForSeconds(currentWave.SpawnDelay);
            SpawnEnemy(item);
        }
    }

    void SpawnEnemy(Spawnable item)
    {
        Debug.Log(item);
        var enemyGameObject = Instantiate(
                        item.Enemy,
                        item.SpawnPoint.transform.position,
                        item.SpawnPoint.transform.rotation);
        var enemyMotor = enemyGameObject.GetComponent<AIMotor>();
        enemyMotor.Target = GameObject.Find("Candy");
    }

}
