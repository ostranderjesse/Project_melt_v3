using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public List<Enemy> enemies = new List<Enemy>();
    [Space]
    public int currentWave;
    [Space]
    public int waveValue;
    [Space]
    public List<GameObject> enemiesToSpawn = new List<GameObject>();
    public Transform spawnLocation;
    public int waveDuration;
 
     public float waveTimer;

    public float spawnInterval;

    public float spawnTimer;

    // Start is called before the first frame update

    private void Start()
    {
        GenerateWave();
    }

    private void Update()
    {
        if(spawnTimer <=0)
        {
            //spawn an enemy
            if(enemiesToSpawn.Count >0)
            {
                Instantiate(enemiesToSpawn[0], spawnLocation.position, Quaternion.identity); //spawn first enemy in list
                enemiesToSpawn.RemoveAt(0); // and remove it
                spawnTimer = spawnInterval;
            }
            else
            {
                waveTimer = 0;
            }
        }
        else
        {
            spawnTimer -= Time.fixedDeltaTime;
            waveTimer -= Time.fixedDeltaTime;
        }
    }


    public void GenerateWave()
    {
        waveValue = currentWave * 10;
        GenerateEnemies();

        spawnInterval = waveDuration / enemiesToSpawn.Count; // gives a fixed time between each spawn
        waveTimer = waveDuration; // wave duration is read only
    }
    public void GenerateEnemies()
    {
        List<GameObject> generatedEnemies = new List<GameObject>();
        while(waveValue >0)
        {
            int randEnemyId = Random.Range(0, enemies.Count);
            int randomEnemyCost = enemies[randEnemyId].cost;

            if(waveValue - randomEnemyCost >0)
            {
                generatedEnemies.Add(enemies[randEnemyId].enemyPrefab);
                waveValue -= randomEnemyCost;
            }
            else if (waveValue <= 0)
            {
                break;
            }
        }
        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
    }

    [System.Serializable]
    public class Enemy
    {
        public GameObject enemyPrefab;
        public int cost;
    }
}
