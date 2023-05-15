using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactoryScript : MonoBehaviour
{

    public float lifeTime = 3f;


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
            timeToDie = true;
        }

        if (timeToDie == true)
        {
            
            Destroy(gameObject);
            levelManagerScriptRef.factoryInExistence.RemoveAt(0);

        }

    }






}
