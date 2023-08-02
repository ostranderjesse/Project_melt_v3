
using UnityEngine;

public class forcePatrollNumber : MonoBehaviour
{
    public EnemyTestPatrol enemyTestPatrolRef;
    public SphereCollider colliderTrigger;



    public void Start()
    {
        colliderTrigger = GetComponent<SphereCollider>();

        enemyTestPatrolRef = FindObjectOfType<EnemyTestPatrol>();


        if (enemyTestPatrolRef != null)
        {
            Debug.Log("EnemyReference Found!");
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "enemyPatrollerConstent")
        {
           
            if (enemyTestPatrolRef == null)
            {
                enemyTestPatrolRef = FindObjectOfType<EnemyTestPatrol>();
            }

                Debug.Log("Collision with enemy forcing target increase");
            enemyTestPatrolRef.IncreaseTargetInt();
        }

    }
}