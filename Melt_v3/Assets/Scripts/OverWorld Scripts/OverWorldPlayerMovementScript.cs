
using UnityEngine;

public class OverWorldPlayerMovementScript : MonoBehaviour
{
    //controllers
    public CharacterController controller;
    [Space]

    //Player
    public GameObject player;
    [Space]

    //speeds
    public int moveSpeed;
    public float _gravity = 9.81f;
   // public int jumpSpeed = 8;
    [Space]

    //movement
    public Vector3 moveDirection;
    private float _directionY;
    public float moveVelocity;
    [Space]

    //bool
    public bool facingRight = true;

    //animator
    // public Animator anim;


    // references
    [SerializeField]
    private OverWorldPlayerMovementScript OWPlayerMovementScriptRef;

    // Start is called before the first frame update
    void Start()
    {
        OWPlayerMovementScriptRef = FindObjectOfType<OverWorldPlayerMovementScript>();


        controller = GetComponent<CharacterController>();

        player = GameObject.FindGameObjectWithTag("OWPlayer"); // OverWorld Player
    }

    // Update is called once per frame
    void Update()
    {
        float horizInput = Input.GetAxis("Horizontal");

        moveDirection = new Vector3(horizInput, 0, 0); // store input in moveDirection

        if (controller.isGrounded == true)
        {
            // Debug.Log("character controller is grounded");

            //  anim.SetBool("isJumping", false);

            _directionY = 0;

            moveVelocity = 0f;
        }
        else if (controller.isGrounded == false)
        {
            //anim.SetBool("isJumping", true);
            _directionY -= _gravity * Time.deltaTime; // this is your jumping stuff and gravity
        }

        //flip player arround as they move left or right
        if (horizInput < 0 && facingRight)
        {
            Flip();
        }
        else if (horizInput > 0 && !facingRight)
        {
            Flip();
        }

        moveVelocity = moveSpeed;
            moveDirection *= moveSpeed;
            moveDirection.y = _directionY;


        if (horizInput != 0)
        {
            //  anim.SetBool("isRunning", true);
            Quaternion newRoation = Quaternion.LookRotation(new Vector3(horizInput, 0, 0));
            //model.rotation = newRotation;
        }
        else if (horizInput == 0)
        {
            //  anim.SetBool("isRunning", false);
        }
        //move player left and right
        controller.Move(moveDirection * Time.deltaTime); //runs in seconds at the same amount

    }

    //methods

    public void Flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
    }
}
