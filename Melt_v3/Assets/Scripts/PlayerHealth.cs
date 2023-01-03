
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public  float MAXHEALTH = 1.0f;
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


    public void HealDamage(float heal)
    {
        currentHealth += heal;

        healthBarRef.SetHealth(currentHealth);

        if(currentHealth >= MAXHEALTH)
        {
            //Debug.Log("Player health is larger then max set it to max");
            currentHealth = MAXHEALTH;
        }
    }

    public  void SavePlayerData()
    {
        SaveSystem.SavePlayerPerks(this);
    }

    public  void LoadPlayerData()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        MAXHEALTH = data.totalHealth;
    }




}
