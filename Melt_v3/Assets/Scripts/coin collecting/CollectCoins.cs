using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectCoins : MonoBehaviour
{

    public GameObject scoreText;
    public static int theScore;


    private void Awake()
    {
        theScore = PlayerPrefs.GetInt("numberofCoins",0); //defualt value
    }

    private void Update()
    {
        //change the scroe
        scoreText.GetComponent<Text>().text = theScore.ToString();


    }
}
