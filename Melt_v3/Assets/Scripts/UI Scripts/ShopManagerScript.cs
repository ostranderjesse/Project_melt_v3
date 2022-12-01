using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManagerScript : MonoBehaviour
{
    [SerializeField] private Material highlightedMaterial;

    [SerializeField] private Animator anim;

    public void Start()
    {
        anim = GetComponentInChildren<Animator>();

        anim.SetBool("playHover", true);
    }

    private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            var selectionsRenderer = selection.GetComponent<Renderer>();

            if(selectionsRenderer != CompareTag("Item")) // != null is original
            {
                selectionsRenderer.material = highlightedMaterial;

                anim.SetBool("playHover", false);
            }
            else if(selectionsRenderer == CompareTag("Item")) // this was not origonlly here
            {
                anim.SetBool("playHover", true);
            }
        }
    }
}
