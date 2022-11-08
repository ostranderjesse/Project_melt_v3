using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectStar : MonoBehaviour
{
    //public AudioSource collectSound;

  // [SerializeField] private CollectCoins collectCoinsRef;

    private void OnTriggerEnter(Collider other)
    {
        //play sound
        //collectSound.Play();
        //change score
       // collectCoinsRef = GetComponent<CollectCoins>();

        CollectCoins.theScore += 50;

        PlayerPrefs.SetInt("numberofCoins", CollectCoins.theScore);

        Destroy(gameObject);

    }
}