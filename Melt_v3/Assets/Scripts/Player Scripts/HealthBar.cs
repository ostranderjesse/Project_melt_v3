
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PlayerHealth PlayerHealthRef;
    public Image fillImage;

    public Slider slider;

    [SerializeField]
    private Image snowmangeimageFull, snowManImageMelted, snowmanImageMoreMelted, snowManImageVeryMelted;
  

    private void Start()
    {
        slider = GetComponent<Slider>();
        snowmangeimageFull = GameObject.Find("SnowmanFull").GetComponentInChildren<Image>();
        Debug.Log("snowmane image full: " + snowmangeimageFull);
        snowManImageMelted = GameObject.Find("SnowmanMelt1").GetComponentInChildren<Image>();
        Debug.Log("snowmane image full: " + snowManImageMelted);
        snowmanImageMoreMelted = GameObject.Find("SnowmanMelt2").GetComponentInChildren<Image>();
        Debug.Log("snowmane image full: " + snowmanImageMoreMelted);
        snowManImageVeryMelted = GameObject.Find("SnowmanVeryMelted").GetComponentInChildren<Image>();
        Debug.Log("snowmane image full: " + snowManImageVeryMelted);



        PlayerHealthRef = FindObjectOfType<PlayerHealth>();

        if(PlayerHealthRef == null)
        {
            Debug.Log("playerHealthRef not found please find it");
        }

        snowmangeimageFull.enabled = true;
        snowManImageMelted.enabled = false;
        snowmanImageMoreMelted.enabled = false;
        snowManImageVeryMelted.enabled = false;
    }

    private void Update()
    {
        //update the health bar
        if(slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
            Debug.Log("fill image was false");
        }

        if(slider.value > slider.minValue && !fillImage.enabled)
        {
            fillImage.enabled = true;
            Debug.Log("fill image was disabled");
        }

        float fillValue = PlayerHealthRef.currentHealth; /// PlayerHealthRef.MAXHEALTH;

        //set slider value to fill value
        slider.value = fillValue;

        #region original code ment for hp 0 - 1
        //if(fillValue <= .75f && fillValue >= .50f)
        //{
        //    snowmangeimageFull.enabled = false; // 100% image
        //    snowManImageMelted.enabled = true; // 75% image
        //}
        //if(fillValue <= .49f && fillValue >= .26f)
        //{
        //    snowmangeimageFull.enabled = false;
        //    snowManImageMelted.enabled = false;
        //    snowmanImageMoreMelted.enabled = true; // 50% image
        //}

        //if (fillValue <= .25f && fillValue >=0.1f)
        //{
        //    snowmangeimageFull.enabled = false;
        //    snowManImageMelted.enabled = false;
        //    snowmanImageMoreMelted.enabled = false;
        //    snowManImageVeryMelted.enabled = true; // 25% image
        //}
        #endregion

        if(fillValue >75 )
        {
            snowmangeimageFull.enabled = true; // 100% image
            snowManImageMelted.enabled = false; // 75% image
            snowmanImageMoreMelted.enabled = false; // 50% image
            snowManImageVeryMelted.enabled = false; // 25% image
        }

        if(fillValue <= 74 && fillValue >= 50 )
        {
            snowmangeimageFull.enabled = false; // 100% image
            snowManImageMelted.enabled = true; // 75% image
            snowmanImageMoreMelted.enabled = false;
            snowManImageVeryMelted.enabled = false;
        }
        else if (fillValue >= 26 && fillValue <= 49 )
        {
            snowmangeimageFull.enabled = false;
            snowManImageMelted.enabled = false;
            snowmanImageMoreMelted.enabled = true; // 50% image
            snowManImageVeryMelted.enabled = false;

        }
        else if (fillValue <= 25 && fillValue >= 1)
        {
            snowmangeimageFull.enabled = false;
            snowManImageMelted.enabled = false;
            snowmanImageMoreMelted.enabled = false;
            snowManImageVeryMelted.enabled = true; // 25% image
        }

        if (fillValue <= 0)
        {
            Debug.Log("player is now dead");
            //kill player here
        }

        #region health code v2

        ////health going from 100 - 0
        //if (fillValue <= 75 && fillValue >= 50)
        //{
        //    snowmangeimageFull.enabled = false; // 100% image
        //    snowManImageMelted.enabled = true; // 75% image
        //}
        //if (fillValue <= 49 && fillValue >= 26)
        //{
        //    snowmangeimageFull.enabled = false;
        //    snowManImageMelted.enabled = false;
        //    snowmanImageMoreMelted.enabled = true; // 50% image
        //}

        //if (fillValue <= 25 && fillValue >= 1)
        //{
        //    snowmangeimageFull.enabled = false;
        //    snowManImageMelted.enabled = false;
        //    snowmanImageMoreMelted.enabled = false;
        //    snowManImageVeryMelted.enabled = true; // 25% image
        //}

        //if(fillValue <= 0 )
        //{
        //    Debug.Log("player is now dead");
        //    //kill player here
        //}
        #endregion
    }

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(float health)
    {
        slider.value = health;


    }
}
