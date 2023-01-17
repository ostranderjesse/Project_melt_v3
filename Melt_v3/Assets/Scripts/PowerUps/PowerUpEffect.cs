using UnityEngine;

#region old code for scriptableobjects
[CreateAssetMenu(menuName = "PowerUpEffects/PurchasePower")]

public class PowerUpEffect : ScriptableObject
{
    public new string name; //name of power up
    public string description; //brief description of power up

    public Mesh modelYouWantToUse;
    public Material defaultMaterial;

    public int damage; // the amount of each snowball
    public int heatResistence; //the rate ate which you melt
    public int ammo; // attack you can use
    public float HEALTHMAXUPGRADE;

    //public GameObject powerupGameObject; // used to spawn in the item you want to click and hold the power up

}

#endregion


#region new way of doing scriptableobjects, see youyube video powerups, you know the one that has a goku on it
//public abstract class PowerUpEffects :ScriptableObject
//{
//    public abstract void applyPowerUpEffect(GameObject target);
//}
#endregion