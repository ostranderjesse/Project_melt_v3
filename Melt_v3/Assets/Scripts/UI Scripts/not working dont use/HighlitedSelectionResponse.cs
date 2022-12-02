
using UnityEngine;

internal class HighlightSelectionResponse : MonoBehaviour, ISelectionResponse
{
    [SerializeField] public Material highlitedMaterial;
    [SerializeField] public Material defaultMaterial;

    public void SelectObject(Transform selection)
    {
        var selectionRenderer = selection.GetComponent<Renderer>();
        if (selectionRenderer != null)
        {
            selectionRenderer.material = this.highlitedMaterial;
        }
    }

    public void DeslectObject(Transform selection)
    {
        var selectionRender = selection.GetComponent<Renderer>();
        if (selectionRender != null)
        {
            selectionRender.material = this.defaultMaterial;
        }
    }

}
