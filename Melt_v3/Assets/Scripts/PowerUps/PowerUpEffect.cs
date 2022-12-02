using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region old code for scriptableobjects
[CreateAssetMenu(menuName = "PowerUpEffects/PurchasePower")]

public class PowerUpEffect : ScriptableObject
{
    public new string name; //name of power up
    public string description; //brief description of power up


   // public MeshFilter modelYouWantToChange;
    public Mesh modelYouWantToUse;

    public Material defaultMaterial;
    // public MeshFilter meshOfPowerUp; // sprite

    public int damage; // the amount of each snowball
    public int heatResistence; //the rate ate which you melt
    public int snowBalls; // attack you can use

}
#endregion


#region new way of doing scriptableobjects, see youyube video powerups, you know the one that has a goku on it
//public abstract class PowerUpEffects :ScriptableObject
//{
//    public abstract void applyPowerUpEffect(GameObject target);
//}
#endregion