using UnityEngine;

[System.Serializable]
public class PlayerData
{
    //public bool hasHealthPerk; // do you have perk
    public float totalHealth;
   // public int damage, heatRes; // perk stats

    public PlayerData(PlayerHealth health )
    {
        totalHealth = health.MAXHEALTH;

    }

}
