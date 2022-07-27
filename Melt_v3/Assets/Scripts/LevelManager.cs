﻿using System.Collections;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject currentCheckPoint;

    public PlayerMovementScript playerRef;




    // Start is called before the first frame update
    void Start()
    {
        playerRef = FindObjectOfType<PlayerMovementScript>();

        if(playerRef == null)
        {
            playerRef = FindObjectOfType<PlayerMovementScript>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnPlayer()
    {
        Debug.Log("Player Respawn");

        playerRef.controller.enabled = false;
        playerRef.transform.position = currentCheckPoint.transform.position;
        playerRef.controller.enabled = true;


    }

}