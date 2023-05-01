using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    public float life = 5f;
    public GameObject spawnFactory;


    public void Awake()
    {
        Destroy(gameObject, life);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }



    //if hits player destroy
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ground")
        {
            Destroy(gameObject);
            Instantiate(spawnFactory);

            Debug.Log("Factroy is spawned");
        }
    }


}
