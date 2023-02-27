using UnityEngine.UI;
using UnityEngine;

public class BossHealthBar : MonoBehaviour
{
    public BossHealth bossHealthRef;
    public Image fillImage;

    public Slider slider;




    // Start is called before the first frame update
   public void Start()
   {
        slider = GetComponent<Slider>();

        bossHealthRef = FindObjectOfType<BossHealth>();

        if(bossHealthRef == null)
        {
            Debug.Log("BossHealthRef not found please find it");
        }
    }

    // Update is called once per frame
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

        float fillValue = bossHealthRef.currentBossHealth; /// BossHealthRef.MAXHEALTH;

        //set slider value to fill value
        slider.value = fillValue;


   }

    public void SetBossMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetBossHealth(float health)
    {
        slider.value = health;


    }




}
