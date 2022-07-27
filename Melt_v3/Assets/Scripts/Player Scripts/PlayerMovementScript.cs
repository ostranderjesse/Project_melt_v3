using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    #region Variables

    //controllers
    public CharacterController controller;
    [Space]

    //Player
    public GameObject player;
    [Space]

    //speeds
    public int moveSpeed;
    public float _gravity = 9.81f;
    public int jumpSpeed = 8;
    [Space]

    //movement
    public Vector3 moveDirection;
    private float _directionY;
    public float moveVelocity;

    [Space]
    //multi jump
    public int extraJumps;
   
    public int extraJumpValue;
    [Space]

    //animator
   // public Animator anim;
    [Space]
    //used to warp player
    public Transform warpLocationIn;
    public Transform warpLocationOut;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        player = GameObject.FindGameObjectWithTag("Player");
        
        // anim = GetComponent<Animator>();
        extraJumps = extraJumpValue;
    }

    // Update is called once per frame
    void Update()
    {
        float horizInput = Input.GetAxis("Horizontal");

        moveDirection = new Vector3(horizInput,0,0); // store input in moveDirection

        if(controller.isGrounded == true)
        {
           // Debug.Log("character controller is grounded");

            //  anim.SetBool("isJumping", false);

            _directionY = 0;

            extraJumps = extraJumpValue;

            moveVelocity = 0f;
        }
        else if(controller.isGrounded == false)
        {
            //anim.SetBool("isJumping", true);
            _directionY -= _gravity * Time.deltaTime; // this is your jumping stuff and gravity

            if(Input.GetKeyDown(KeyCode.W) && extraJumps >0)
            {
                // anim.SetTrigger("takeOff");

                _directionY = jumpSpeed;
                extraJumps--;
                Debug.Log("extra jump value: " + extraJumps + "else statment");
            }
        }

        //jumping
        if(controller.isGrounded == true && Input.GetKeyDown(KeyCode.W))
        {
            //take off animation
            // anim.SetTrigger("takeOff");

            _directionY = jumpSpeed;

            extraJumps--;

        }

        moveVelocity = moveSpeed;
        moveDirection *= moveSpeed;
        moveDirection.y = _directionY;

        if(horizInput != 0)
        {
            //  anim.SetBool("isRunning", true);
            Quaternion newRoation = Quaternion.LookRotation(new Vector3(horizInput, 0, 0));
            //model.rotation = newRotation;
        } else if (horizInput == 0)
        {
            //  anim.SetBool("isRunning", false);
        }
        //move player left and right
        controller.Move(moveDirection * Time.deltaTime); //runs in seconds at the same amount
    }

    public void OnTriggerEnter(Collider other)
    {
        //warp to warp exit
        if(other.tag == "WarpIn")
        {
            Debug.Log("change the position of the character to the warp position elsewhere");

            //disable controller
            controller.enabled = false;

            //move player to warp position
            player.transform.position = warpLocationOut.position;

            //re enable character controller
            controller.enabled = true;
        }

        //warp back to play area
        if (other.tag == "ExitWarp")
        {
            Debug.Log("change the position of the character to the warp position elsewhere");

            //disable controller
            controller.enabled = false;

            //move player to warp position
            player.transform.position = warpLocationOut.position;

            //re enable character controller
            controller.enabled = true;
        }
    }

}
