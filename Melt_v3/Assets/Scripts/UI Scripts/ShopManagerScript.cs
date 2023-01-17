using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ShopManagerScript : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";

    [SerializeField] private string HealthPerkName1 = "HealthPerk1";
    [SerializeField] private string ammoPerkName1 = "AmmoPerk1";
    [SerializeField] private string damagePerkName1 = "DamagePerk1";
    [SerializeField] private string heatResPerkName1 = "HeatResistencePerk1";

    //add world perks if this works

    [Space]
    //reference animatior controller
    public Animator anim;
    [Space]
    [SerializeField] private Transform _selected;

    private RaycastHit hit;
    private ISelectionResponse _selectionResponse;
    public GameObject uiItemDisplay;

    public GameObject perkGameObject1;
    public GameObject perkGameObject2;
    public GameObject perkGameObject3;

    public UnlockableMatrixScript unlockableMatrixRef;

   [SerializeField] public static string unlockMatrixPath;


    #region nots no how to make it work
    //added to try saving game info
    // public GameObject purchasedItem;
    //stop added to try saveing info ends here
    #endregion




    private void Awake()
    {
        _selectionResponse = GetComponent<ISelectionResponse>();


        //cache the path
        unlockMatrixPath = $"{Application.persistentDataPath}/UnlockMatrix.json";

        if (File.Exists(unlockMatrixPath))
        {

            Debug.Log("File exists");

            string json = File.ReadAllText(unlockMatrixPath);
            unlockableMatrixRef = JsonUtility.FromJson<UnlockableMatrixScript>(json);

            RenderShop();
            //LoadJson();

        }
        else if(!File.Exists(unlockMatrixPath))
        {
            Debug.Log("File Should not exist");
            RenderShop();
        }
        


    }

    private void Start()
    {
        //cache the path
        //unlockMatrixPath = $"{Application.persistentDataPath}/UnlockMatrix.json";

        //if (File.Exists(unlockMatrixPath))
        //{
        //    string json = File.ReadAllText(unlockMatrixPath);
        //    unlockableMatrixRef = JsonUtility.FromJson<UnlockableMatrixScript>(json);

        //    RenderShop();

        //}


        //RenderShop();

        anim.SetBool("playHover", false);


    }

    private void Update()
    {
        if(File.Exists(unlockMatrixPath))
        {
            RenderShop();
        }
        //else if(!File.Exists(unlockMatrixPath))
        //{
        //    RenderShop();
        //}


        //deselection/selection respon - hover
        if (_selected != null)
        {
            _selectionResponse.DeslectObject(_selected);
        }

        #region create ray
        //create ray
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //selection detection
        _selected = null;
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag))
            {
                _selected = selection;

            }
        }

        if (Input.GetMouseButtonDown(0))
        {

            if (Physics.Raycast(ray, out hit))
            {
                var selection = hit.transform;



                if (selection.CompareTag(selectableTag))
                {

                    _selected = selection;



                    Debug.Log(selection.GetComponent<PowerUpDisplay>().powerUpTextName.text);


                    if (selection.GetComponent<PowerUpDisplay>().powerUpTextName.text == "Health perk 1")// .name
                    {
                        Debug.Log("Health power up found!");

                        BuyHealthPerk1();

                        //Destroy(selection.gameObject);

                    }

                    if (selection.GetComponent<PowerUpDisplay>().powerUpTextName.text == "Ammo Perk 1")
                    {
                        Debug.Log("Ammo power up found!");
                        BuyAmmoPerk1();

                    }

                    if (selection.GetComponent<PowerUpDisplay>().powerUpTextName.text == "Damage perk 1")
                    {
                        Debug.Log("Ammo power up found!");
                        BuyDamagePerk1();

                    }


                    if (selection.GetComponent<PowerUpDisplay>().powerUpTextName.text == "Heat Res Perk 1")
                    {
                        Debug.Log("Heat res power up found!");
                        BuyHeatResPerk1();

                    }

                }

            }
        }

        #endregion

        //deactivate the UI display when clicked
        if (_selected == null)
        {
            uiItemDisplay.SetActive(false);
        }



        //deselection/selection respon
        if (_selected != null)
        {
            _selectionResponse.SelectObject(_selected);

        }
    }



    //methods

    //buy health perks
    public void BuyHealthPerk1()
    {
        unlockableMatrixRef.hasHealthPerk1 = true;
        RenderShop();
        SaveJson();
    }


    public void BuyAmmoPerk1()
    {
        unlockableMatrixRef.hasAmmoPerk1 = true;
        RenderShop();
        SaveJson();
    }

 
    public void BuyDamagePerk1()
    {
        unlockableMatrixRef.hasDamagePerk1 = true;
        RenderShop();
        SaveJson();
    }

    public void BuyHeatResPerk1()
    {
        unlockableMatrixRef.hasHeatResistencePerk1 = true;
        RenderShop();
        SaveJson();
    }




    public void RenderShop()
    {

        if (unlockableMatrixRef.hasHealthPerk1 == true) 
        {
            Debug.Log("Destroy  health perk Game object");
            
            perkGameObject1.SetActive(false);
        }
        
        if (unlockableMatrixRef.hasAmmoPerk1 == true)
        {
            Debug.Log("Destroy  ammo perk Game object");
            perkGameObject2.SetActive(false);
           
        }
        
        if (unlockableMatrixRef.hasDamagePerk1 == true)
        {
            Debug.Log("Destroy  damage perk Game object");
            perkGameObject3.SetActive(false);
            
        }
  
    }

    private void SaveJson()
    {
        string json = JsonUtility.ToJson(unlockableMatrixRef);
        File.WriteAllText(unlockMatrixPath, json);
    }
    public  void DelSaveJson()
    {
        string json = JsonUtility.ToJson(unlockableMatrixRef);


        Debug.Log("Created json to look at now deleted");
        if(File.Exists(unlockMatrixPath))
        {
            Debug.Log("File json now deleted" + json);
             File.Delete(unlockMatrixPath); //unlockMatrixPath
            unlockableMatrixRef.hasAmmoPerk1 = false;
            unlockableMatrixRef.hasDamagePerk1 = false;
            unlockableMatrixRef.hasHealthPerk1 = false;
            unlockableMatrixRef.hasHeatResistencePerk1 = false;


            Debug.Log("Files from:" + unlockMatrixPath + "has been deleted");

            if(!File.Exists(unlockMatrixPath))
            {
                Debug.Log("File: " + unlockMatrixPath + "does not exist");
            }
       }

    }

    public void LoadJson()
    {
        string json = JsonUtility.ToJson(unlockableMatrixRef);
        File.ReadAllText(unlockMatrixPath);
        
    }




}
