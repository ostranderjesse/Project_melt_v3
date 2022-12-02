using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlitedSelectResponse : MonoBehaviour, ISelectionResponse
{
    [SerializeField] public Material highlitedMaterial;
    [SerializeField] public Material defaultMaterial;

    public Animator anim;

    public void SelectObject(Transform selection)
    {
        var selectionRenderer = selection.GetComponent<Renderer>();
        if (selectionRenderer != null)
        {
            //stop animation
            selectionRenderer.material = this.highlitedMaterial;
            anim.SetBool("playHover", true);
            anim.Play("playHover");
        }
    }

    public void DeslectObject(Transform selection)
    {
        var selectionRender = selection.GetComponent<Renderer>();
        if (selectionRender != null)
        {
            selectionRender.material = this.defaultMaterial;
            anim.SetBool("playHover", false);
        }
    }
}

