
using UnityEngine;

public class HighlitedSelectResponse : MonoBehaviour, ISelectionResponse
{
    [SerializeField] public Material highlitedMaterial;
    [SerializeField] public Material defaultMaterial;




    //public void ClickedObjected(Transform selection)
    //{
    //    var selectionPowerUpEffectScriptRef = selection.GetComponent<PowerUpDisplay>();




    //    if (selectionPowerUpEffectScriptRef != null)
    //    {
    //        Debug.Log("ClickedObject method");

    //       Destroy( selectionPowerUpEffectScriptRef.powerUpGameObject);

    //    }

       
    //    //Destroy(selection);
    //   // ItemDestroy(selection);


    //}

    public void SelectObject(Transform selection)
    {
        var selectedPowerupDisplayRef = selection.GetComponent<PowerUpDisplay>();

        var selectionRenderer = selection.GetComponent<Renderer>();
        var selectionAnimator = selection.GetComponentInChildren<Animator>();

        if(selectedPowerupDisplayRef != null)
        {
            Debug.Log("Powerup display reference found! on select");
           // selectedPowerupDisplayRef.powerUpDamage.ToString();
        }

        if(selectionAnimator != null)
        {
            selectionAnimator.SetBool("playHover", true);
        }

        if (selectionRenderer != null)
        {
            
            selectionRenderer.material = highlitedMaterial; // this.highlightedMaterial

        }
    }

    public void DeslectObject(Transform selection)
    {
        var selectedPowerupDisplayRef = selection.GetComponent<PowerUpDisplay>();

        var selectionRender = selection.GetComponent<Renderer>();
        var selectionAnimator = selection.GetComponentInChildren<Animator>();

        if (selectionRender != null)
        {
            selectionRender.material = selectedPowerupDisplayRef.modelMaterialYouWantToChange;

        }

        if(selectionAnimator != null)
        {
            selectionAnimator.SetBool("playHover", false);
        }
        
    }
}

