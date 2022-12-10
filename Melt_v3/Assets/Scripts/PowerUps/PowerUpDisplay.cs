
using UnityEngine;
using UnityEngine.UI;

public class PowerUpDisplay : MonoBehaviour
{

    public PowerUpEffect powerUpEffectScriptableObjectRef;
    public GameObject powerUpGameObject;

    [Space]
    public Text powerUpTextName;
    [Space]
    public MeshFilter modelYouWantToChange;
    [Space]
    public Material modelMaterialYouWantToChange;
    [Space]
   public  BoxCollider m_collider;
    [Space]
   public float m_ScaleX, m_ScaleY, m_ScaleZ;
    //[Space]
    //public Text powerUpDamage;
    //public Text powerUpHeatResistence;
    public Text powerUpDescription;


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

        powerUpGameObject = this.gameObject;


        var selectionRenderer = this.GetComponent<Renderer>();

        m_collider = GetComponent<BoxCollider>();

        m_ScaleX = 2.0f;
        m_ScaleY = 2.0f;
        m_ScaleZ = 2.0f;


        powerUpTextName.text = powerUpEffectScriptableObjectRef.name;

        

        //powerUpHeatResistence.text = powerUpEffectScriptableObjectRef.heatResistence.ToString();

        //powerUpDescription.text = powerUpEffectScriptableObjectRef.description.ToString();

        modelYouWantToChange.mesh = powerUpEffectScriptableObjectRef.modelYouWantToUse;

        selectionRenderer.material = powerUpEffectScriptableObjectRef.defaultMaterial;

        this.modelMaterialYouWantToChange = selectionRenderer.material;

        m_collider.size = new Vector3(m_ScaleX, m_ScaleY, m_ScaleZ);

        m_collider.center = new Vector3(0, .46f, 0);

    }

    public void Update()
    {
        var selectionRenderer = this.GetComponent<Renderer>();

        selectionRenderer.material = powerUpEffectScriptableObjectRef.defaultMaterial;


       // powerUpDamage.text = powerUpEffectScriptableObjectRef.damage.ToString();


    }
}