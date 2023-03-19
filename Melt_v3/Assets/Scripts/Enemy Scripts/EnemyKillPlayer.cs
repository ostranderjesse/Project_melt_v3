﻿using UnityEngine;

public class EnemyKillPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private LevelManager levelManagerRef;

    [SerializeField]
    private PlayerHealth playerHealthRef;

    [SerializeField]
    private PlayerMovementScript playerMovementRef;

    void Start()
    {
        levelManagerRef = FindObjectOfType<LevelManager>();

        playerHealthRef = FindObjectOfType<PlayerHealth>();

        playerMovementRef = FindObjectOfType<PlayerMovementScript>();

        if (levelManagerRef == null)
        {
            levelManagerRef = FindObjectOfType<LevelManager>();
        }

        if (playerHealthRef == null)
        {
            playerHealthRef = FindObjectOfType<PlayerHealth>();
        }

        if (playerMovementRef == null)
        {
            playerMovementRef = FindObjectOfType<PlayerMovementScript>();
        }

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Snowman Player(Clone)")                         //"player(Clone)")
        {
            playerHealthRef.TakeDanage(10.0f);

            levelManagerRef.RespawnPlayer();
        }
    }

}