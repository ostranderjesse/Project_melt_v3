using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManagerScript : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";
  //   [SerializeField] private PowerUpEffect powerUpEffectRef;

    //[SerializeField] private HighlitedSelectResponse highlightSelectResponsRef;

    // [Space]

    // public Text 

    //reference animatior controller
    public Animator anim;


    [SerializeField] private Transform _selected;
    private RaycastHit hit;

    private ISelectionResponse  _selectionResponse;


    private void Awake()
    {
        _selectionResponse = GetComponent<ISelectionResponse>();
      //  highlightSelectResponsRef = GetComponent<HighlitedSelectResponse>();

    }

    private void Start()
    {
        anim.SetBool("playHover", false);
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
            if(Physics.Raycast(ray, out hit))
            {
                var selection = hit.transform;
               
               // var selectionsPowerUpEffectRef = selection.GetComponent<PowerUpEffect>();
                

                if (selection.CompareTag(selectableTag))
                {
                    _selected = selection;

                  
                    //Debug.Log("you clciked on item: " + selection.name);

                  
                    Debug.Log(selection.GetComponent<PowerUpDisplay>().powerUpTextName.text);
                   // Debug.Log(selection.GetComponent<PowerUpDisplay>().powerUpDescription.text);
                    // Debug.Log(selection.GetComponent<PowerUpDisplay>().powerUpDamage.ToString());
                   // Debug.Log(selection.GetComponent<PowerUpDisplay>().powerUpDescription.ToString()); // doesnt work


                    //selection.GetComponent<PowerUpDisplay>().powerUpTextName.text = selection.GetComponent<PowerUpDisplay>().powerUpDescription.ToString();

                    //Debug.Log(selection.GetComponent<PowerUpDisplay>().powerUpTextName.text);

                    // add buffs from selected powerup


                    Destroy(selection.gameObject);

                }

            }
        }

        #endregion

        //deselection/selection respon
        if (_selected != null)
        {
            _selectionResponse.SelectObject(_selected);
    
        }
    }
}
