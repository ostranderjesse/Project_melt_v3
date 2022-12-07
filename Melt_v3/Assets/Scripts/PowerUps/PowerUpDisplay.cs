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





   public  BoxCollider m_collider;
   public float m_ScaleX, m_ScaleY, m_ScaleZ;

    //public GameObject gameobjectPrefab; // item you change to

    public GameObject testItemMesh; // item you start with

    public BoxCollider newCollider;


  
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

        //testItemMesh = powerUpEffectScriptableObjectRef.ItemPrefab;


        var selectionRenderer = this.GetComponent<Renderer>();

        m_collider = GetComponent<BoxCollider>();



        m_ScaleX = 2.0f;
        m_ScaleY = 2.0f;
        m_ScaleZ = 2.0f;

       
       


        // Debug.Log(powerUpEffectScriptableObjectRef.name);

        powerUpTextName.text = powerUpEffectScriptableObjectRef.name;

        modelYouWantToChange.mesh = powerUpEffectScriptableObjectRef.modelYouWantToUse;

       // selectionRenderer.material = modelMaterialYouWantToChange; // this.modelMaterialYouWantToChange is the original


        selectionRenderer.material = powerUpEffectScriptableObjectRef.defaultMaterial;

        this.modelMaterialYouWantToChange = selectionRenderer.material;

        m_collider.size = new Vector3(m_ScaleX, m_ScaleY, m_ScaleZ);

        m_collider.center = new Vector3(0, .46f, 0);

    }

    public void Update()
    {
        var selectionRenderer = this.GetComponent<Renderer>();

        selectionRenderer.material = powerUpEffectScriptableObjectRef.defaultMaterial;
    }


}
