using UnityEngine.UI;
using UnityEngine;

public class HighlitedSelectResponse : MonoBehaviour, ISelectionResponse
{
    [SerializeField] public Material highlitedMaterial;
    [SerializeField] public Material defaultMaterial;


    [SerializeField] private Text nameText;
    [SerializeField] private Text descriptionText;
    [SerializeField] private Text damageText;
    [SerializeField] private Text heatResText;
    [SerializeField] private Text ammoText;

    [SerializeField] public GameObject uiDisplay;

    private void Start()
    {
        uiDisplay.SetActive(false);
    }

    public void SelectObject(Transform selection)
    {
        

        var selectionRenderer = selection.GetComponent<Renderer>();
        var selectionAnimator = selection.GetComponentInChildren<Animator>();

        var selectedPowerupDisplayRef = selection.GetComponent<PowerUpDisplay>();



        if (selectedPowerupDisplayRef != null)
        {
            uiDisplay.SetActive(true);
            Debug.Log("Powerup display reference found! On select");
            nameText.text = selectedPowerupDisplayRef.powerUpEffectScriptableObjectRef.name;
            descriptionText.text = selectedPowerupDisplayRef.powerUpEffectScriptableObjectRef.description;

            damageText.text = selectedPowerupDisplayRef.powerUpEffectScriptableObjectRef.damage.ToString();
            heatResText.text = selectedPowerupDisplayRef.powerUpEffectScriptableObjectRef.heatResistence.ToString();
            ammoText.text = selectedPowerupDisplayRef.powerUpEffectScriptableObjectRef.snowBalls.ToString();

        }
       // else
          // return;

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

        uiDisplay.SetActive(false);

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

