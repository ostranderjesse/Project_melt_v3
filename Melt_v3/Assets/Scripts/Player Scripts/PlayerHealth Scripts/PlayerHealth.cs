using System.IO;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public  float MAXHEALTH = 1.0f;
    public float currentHealth;

    public HealthBar healthBarRef;

    public PlayerMovementScript thePlayer;

    public void Awake()
    {
        //string path = Application.persistentDataPath + "/Player.Perks";

        ////check to see if file exists
        //if (File.Exists(path))
        //{
        //    SaveSystem.LoadPlayer();

        //}else if(!File.Exists(path))
        //{
        //    Debug.Log("no file exists in: " + path);
        //}


        //find the player
        thePlayer = FindObjectOfType<PlayerMovementScript>();

    }

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

   public void DamagePlayer(float damage, Vector3 dDirection)
    {
      currentHealth -= damage;
        thePlayer.KnockBack(dDirection);
    }

    public void killPlayer(float damage) // just damage the player
    {
        //direction = new Vector3(1, 1, 1);
        currentHealth -= damage;


       // thePlayer.KnockBack(direction);

        healthBarRef.SetHealth(currentHealth);
    }

    public void DamageOverTimeDamage(float damage)
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

    //public  void SavePlayerData()
    //{
    //    SaveSystem.SavePlayerPerks(this);
    //}

    //public  void LoadPlayerData()
    //{
    //    PlayerData data = SaveSystem.LoadPlayer();
    //    MAXHEALTH = data.totalHealth;
    //}




}
