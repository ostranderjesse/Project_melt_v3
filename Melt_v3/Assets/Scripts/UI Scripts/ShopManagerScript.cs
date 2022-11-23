using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManagerScript : MonoBehaviour
{
    public Text textObject1;
   // public Text textObject2;
    //public Text textObject3;
    public Animation anim;
  

    public void Start()
    {

        anim = textObject1.GetComponent<Animation>();
        

        if(textObject1.GetComponent<Animation>() != null)
        Debug.Log("animator found");

        anim.Play("TextMovementAnimation");
 

    }

    private void Update()
    {
        if (textObject1.GetComponent<Animation>() != null)
            Debug.Log("animator ! found");

      

    }

    public void OnMouseOver()
    {
        //play animation
        anim.Play("TextMovementAnimation");

    }

    public void OnMouseExit()
    {
        //stop animation
       // anim1.Stop("TextMovementAnimation");
     
    }
}
