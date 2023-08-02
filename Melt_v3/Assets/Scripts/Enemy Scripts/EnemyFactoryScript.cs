using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactoryScript : MonoBehaviour
{

    public float lifeTime = 10f;

    [SerializeField] private float nextSpawnTime;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnDelay;

    [SerializeField] private bool timeToDie = false;

    [SerializeField]
    private LevelManager levelManagerScriptRef;

    public void Start()
    {
        levelManagerScriptRef = FindObjectOfType<LevelManager>();

        if (levelManagerScriptRef == null)
        {
            levelManagerScriptRef = FindObjectOfType<LevelManager>();
        }
    }


    public void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Debug.Log("Lifetime: " + lifeTime.ToString());
            timeToDie = true;
        }

        if (timeToDie == true)
        {
            Destroy(gameObject);
            levelManagerScriptRef.factoryInExistence.RemoveAt(0);

        }


        if(ShouldSpawn())
        {
            Spawn();
        }


    }

    private void Spawn()
    {
        nextSpawnTime = Time.time + spawnDelay;
        Instantiate(enemyPrefab, transform.position, transform.rotation);
    }

    private bool ShouldSpawn()
    {
        return Time.time >= nextSpawnTime;
    }

}
