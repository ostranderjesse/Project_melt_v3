[System.Serializable]

public  class UnlockableMatrixScript
{
    //Health perks
    public bool hasHealthPerk1 = false; //150 hp
   // public bool hasHealthPerk2; //200 hp
   // public bool hasHealthPerk3; //300 hp

    //ammo perks
    public bool hasAmmoPerk1 = false; // increase ammo count by 1
   // public bool hasAmmoPerk2; // increase ammo count by 2
   // public bool hasAmmoPerk3; // increase ammo count by 3

    //damage perks
    public bool hasDamagePerk1 = false; // increase damage delt by 1
  //  public bool hasDamagePerk2; // increase damage delt by 2
   // public bool hasDamagePerk3; // increase damage delt by 3

    //heat Resistence perks
    public bool hasHeatResistencePerk1 = false; // increase Heat Resistence by 1: Damage taken = 1 less
  //  public bool hasHeatResistencePerk2; // increase Heat Resistence by 2: Damage taken = 2 less
   // public bool hasHeatResistencePerk3; // increase Heat Resistence by 3: Damage taken = 3 less

    #region use this to make player bought skins
    //if all above works use it to make saved player skins. just make a character select screen like in tankapalooza!
    #endregion
}
