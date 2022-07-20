using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{

    //variables
    public CharacterController controller;
    //multi jump
    public int extraJumps;
    public int extraJumpValue;
    [Space]
    //animator
    public Animator anim;
    [Space]
    //used to warp player
    public GameObject player;
    public Transform warpLocationIn;
    public Transform warpLocationOut;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
