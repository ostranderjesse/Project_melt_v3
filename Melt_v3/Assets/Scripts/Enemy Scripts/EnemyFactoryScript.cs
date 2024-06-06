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

    //public GameObject spawnPosition;

  //  public GameObject spawnPos;

    

    public void Start()
    {
        // spawnPosition = transform.position;
        // this.spawnPos.transform.position = transform.position;

        //spawnPosition.transform.position = this.transform.position;

       //Debug.Log("the spawnposition of enemy factory is: " + spawnPosition.transform.position);

        levelManagerScriptRef = FindObjectOfType<LevelManager>();

        if (levelManagerScriptRef == null)
        {
            levelManagerScriptRef = FindObjectOfType<LevelManager>();
        }

       // if(spawnPosition == null)
      //  {
        //    spawnPosition.transform.position = this.transform.position;

         //   Debug.Log("the spawnposition of enemy factory is: " + spawnPosition.transform.position);
       // }
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

    public void Spawn()
    {
        
        nextSpawnTime = Time.time + spawnDelay;
        //Instantiate(enemyPrefab, transform.position, transform.rotation); // old code 
        Instantiate(enemyPrefab, transform.position, enemyPrefab.transform.rotation = Quaternion.identity); // new code
        //Instantiate(enemyPrefab.transform, transform.position, enemyPrefab.transform.rotation = Quaternion.identity); // newer code
    }

    private bool ShouldSpawn()
    {
        return Time.time >= nextSpawnTime;
    }

}
