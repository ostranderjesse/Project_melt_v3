using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManagerScript : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";

    //reference animatior controller
    public Animator anim;


    [SerializeField] private Transform _selected;
    private RaycastHit hit;

    private ISelectionResponse  _selectionResponse;


    private void Awake()
    {
        _selectionResponse = GetComponent<ISelectionResponse>();
    }

    private void Start()
    {
        anim.SetBool("playHover", false);
    }

    private void Update()
    {
        //deselection/selection respon
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
        #endregion

        //deselection/selection respon
        if (_selected != null)
        {
            _selectionResponse.SelectObject(_selected);
    
        }
    }
}
