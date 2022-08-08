
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float MAXHEALTH = 1.0f;
    public float currentHealth;

    public HealthBar healthBarRef;

    public void Start()
    {
        healthBarRef = FindObjectOfType<HealthBar>();

        if(healthBarRef == null)
        {
            Debug.Log("healthbar reference not found");
        }
        currentHealth = MAXHEALTH;
        healthBarRef.SetMaxHealth(MAXHEALTH);
    }

    private void Update()
    {
        ////damage player
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    TakeDanage(10.0f);
        //}
    }

   public void TakeDanage(float damage)
    {
        currentHealth -= damage;

        healthBarRef.SetHealth(currentHealth);
    }










}
