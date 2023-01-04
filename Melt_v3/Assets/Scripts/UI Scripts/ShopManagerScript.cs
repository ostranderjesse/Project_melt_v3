using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManagerScript : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";
    [Space]
    //reference animatior controller
    public Animator anim;
    [Space]
    [SerializeField] private Transform _selected;

    private RaycastHit hit;
    private ISelectionResponse  _selectionResponse;
    public GameObject uiItemDisplay;

    //added to try saving game info
    public GameObject purchasedItem;
    //stop added to try saveing info ends here

    private void Awake()
    {
        _selectionResponse = GetComponent<ISelectionResponse>();
    }

    private void Start()
    {
        anim.SetBool("playHover", false);

        purchasedItem = GameObject.Find("PowerUp");

        Debug.Log("Purchase Item Name is:" + purchasedItem.name);

    }

    private void Update()
    {
        //deselection/selection respon - hover
        if(_selected != null)
        {
            _selectionResponse.DeslectObject(_selected);
        }

        #region create ray
        //create ray
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //selection detection
        _selected = null;
        if(Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if(selection.CompareTag(selectableTag))
            {
                _selected = selection;
               
            }
        }

        if(Input.GetMouseButtonDown(0))
        {

            if (Physics.Raycast(ray, out hit))
            {
                var selection = hit.transform;
        
                

                if (selection.CompareTag(selectableTag))
                {
                    
                    _selected = selection;

                

                    Debug.Log(selection.GetComponent<PowerUpDisplay>().powerUpTextName.text);



                    //add buffs or skins to character sections
                    //destroy gameobject you clicked

                    //check to see if enough curency is obtained
                    //if currency != enough dont let the player buy the item they are hovering over















                    if (selection == purchasedItem)
                    {
                        Debug.Log("PowerUp (1) found");
                        PlayerHealth ph = gameObject.GetComponent<PlayerHealth>();
                        
                        ph.SavePlayerData();

                        Destroy(selection.gameObject);
                    }
                    else if( selection.name != "PowerUp")
                    {
                        Debug.Log("PowerUp  not found power ups name is: " + selection.name);

                        //Destroy(selection.gameObject);
                    }

                  //  Destroy(selection.gameObject); // origonal area of deleting item

                    


                    //add buff
                    

                   

                }

            }
        }

        //deactivate the UI display when clicked
        if (_selected == null)
        {
            uiItemDisplay.SetActive(false);
        }

        #endregion

        //deselection/selection respon
        if (_selected != null)
        {
            _selectionResponse.SelectObject(_selected);
    
        }
    }

}
