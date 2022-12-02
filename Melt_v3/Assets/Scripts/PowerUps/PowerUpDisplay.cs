using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpDisplay : MonoBehaviour
{

    public PowerUpEffect powerUpEffectScriptableObjectRef;
    [Space]
    public MeshFilter modelYouWantToChange;
    [Space]
    public Text powerUpTextName;

    public Material modelMaterialYouWantToChange;

   // public var selectRendererCache;
    #region more variables if needed
    //public Material defaultMaterial;
    //public Text description;
    //  public Text damage; // the amount of each snowball
    //public Text heatResistence; //the rate ate which you melt
    //public Text snowBalls; // the ammount you can throw
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        var selectionRenderer = this.GetComponent<Renderer>();
        // Debug.Log(powerUpEffectScriptableObjectRef.name);

        powerUpTextName.text = powerUpEffectScriptableObjectRef.name;

        modelYouWantToChange.mesh = powerUpEffectScriptableObjectRef.modelYouWantToUse;

        selectionRenderer.material = modelMaterialYouWantToChange; // this.modelMaterialYouWantToChange is the original

        // this.modelMaterialYouWantToChange = selectionRenderer.material;
    }

    public void Update()
    {
        var selectionRenderer = this.GetComponent<Renderer>();

        selectionRenderer.material = modelMaterialYouWantToChange;
    }


}
