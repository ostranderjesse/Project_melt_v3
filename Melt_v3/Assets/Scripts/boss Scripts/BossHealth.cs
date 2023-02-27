using System.IO;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

    public float MAXHEALTH = 200.0f;
    public float currentBossHealth;

    public BossHealthBar bossHealthBarRef;



    public void Start()
    {
        bossHealthBarRef = FindObjectOfType<BossHealthBar>();

        if(bossHealthBarRef == null)
        {
            Debug.Log("Boss healthbar reference not found");
            bossHealthBarRef = FindObjectOfType<BossHealthBar>();
        }
        else
        {
            Debug.Log("Boss healthbar reference found");
        }
        currentBossHealth = MAXHEALTH;
        bossHealthBarRef.SetBossMaxHealth(MAXHEALTH);
       
    }


    public void TakeBossDamage(float damage)
    {
        currentBossHealth -= damage;
        bossHealthBarRef.SetBossHealth(currentBossHealth);
    }

}
