using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlitedSelectResponse : MonoBehaviour, ISelectionResponse
{
    [SerializeField] public Material highlitedMaterial;
    [SerializeField] public Material defaultMaterial;
    public PowerUpDisplay powerUpDisplayRef;





    // public Animator anim;

    public void SelectObject(Transform selection)
    {
        var selectionRenderer = selection.GetComponent<Renderer>();
        var selectionAnimator = selection.GetComponentInChildren<Animator>();

        if(selectionAnimator != null)
        {
            selectionAnimator.SetBool("playHover", true);
        }

        if (selectionRenderer != null)
        {
            
            selectionRenderer.material = this.highlitedMaterial;

        }
    }

    public void DeslectObject(Transform selection)
    {
        var selectionRender = selection.GetComponent<Renderer>();
        var selectionAnimator = selection.GetComponentInChildren<Animator>();
        if (selectionRender != null)
        {
            //selectionRender.material = this.defaultMaterial;

            selectionRender.material = powerUpDisplayRef.modelMaterialYouWantToChange;
            //anim.SetBool("playHover", false);
        }

        if(selectionAnimator != null)
        {
            selectionAnimator.SetBool("playHover", false);
            
        }
        
    }
}

