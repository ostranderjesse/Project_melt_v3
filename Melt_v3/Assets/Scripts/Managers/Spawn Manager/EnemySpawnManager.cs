using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> enimiesToUse;
    [SerializeField] private List<GameObject> enemiesToSpawn;
   

    [SerializeField] private bool isFactoryMade = false;

    [SerializeField] private LevelManager levelManagerRef;

    public int enemieWeight;

    private void Start()
    {
        levelManagerRef = FindObjectOfType<LevelManager>();

       

        //foreach (var enemie in enimiesToUse)
        //{
            
        //    enemieWeight = Random.Range(1, 3);
           


        //}
        Debug.Log("weight of enemy: " + enimiesToUse[0] + "is" + enemieWeight);
        Debug.Log("weight of enemy: " + enimiesToUse[1] + "is" + enemieWeight);
        Debug.Log("weight of enemy: " + enimiesToUse[2] + "is" + enemieWeight);


    }
    private void Update()
    {
        foreach (var enemie in enimiesToUse)
        {

            enemieWeight = Random.Range(1, 3);



        }
    }

    //private void Update()
    //{
    //    if(levelManagerRef.factoryInExistence == )
    //}

}
