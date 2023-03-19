using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolScript : MonoBehaviour
{

    public Transform[] patrolPoints;
    public int targetPoint;
    public float speed;

    public bool facingRight = true;
    public Transform targetedPlayer;
    public int chaseRange;

   // [SerializeField] private Rigidbody enemyRigidBody;

    #region unused variables
    // private string currentState = "IdleState";
    //  private Transform target;
    //public float chaseRange = 5;
    #endregion

    // Start is called before the first frame update
    void Start()
    {

        targetPoint = 0;
        targetedPlayer = GameObject.FindGameObjectWithTag("Player").transform;
      
        


    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(transform.position, targetedPlayer.transform.position);

        if(transform.position == patrolPoints[targetPoint].position)
        {
            IncreaseTargetInt();
        }

        // transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime); //OG Code without trying to chase down player the if distance code!

        //transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].transform.position, speed * Time.deltaTime); // testing
        

        
        



        //turn player
        if (targetPoint == 0 && facingRight)
        {
            //face left
            FlipEnemey();
        }
        else if (targetPoint != 0 && !facingRight)
        {
            //face right
            FlipEnemey();
        }
        
        if(distance <= chaseRange)
        {
           
            //chase player
            Debug.Log("chase player now!");
            // transform.Translate(transform.right * Time.deltaTime);
            //MoveAi();
            targetPoint = 0;

        }
        else if (distance > chaseRange)
        {
            //go back to patrolling
            Debug.Log("Go back to patrol point: " + targetPoint);

            transform.Translate(transform.position.x, patrolPoints[targetPoint].position.x, speed * Time.deltaTime);

        }




        #region code to work on for pursuing character
        //if player is within the desired area pursue the player
        // if player is outside the desired area pursue no more and go back to patroling
        //float distance = Vector3.Distance(transform.position, target.position);

        //if(distance < chaseRange)
        //{

        //}
        //else
        //{
        //    if(target.position.x > transform.position.x)
        //    {
        //        //move right
        //        transform.Translate(transform.right * speed * Time.deltaTime);

        //    }
        //    else
        //    {
        //        //move left
        //        transform.Translate(-transform.right * speed * Time.deltaTime);
        //    }
        //}
        #endregion
    }

    private void IncreaseTargetInt()
    {
        targetPoint++;

        if(targetPoint >= patrolPoints.Length)
        {
            targetPoint = 0;
        }
    }

    private void FlipEnemey()
    {
        facingRight = !facingRight;

        transform.Rotate(0f,180f,0f);
    }

    private void MoveAi()
    {
        if (targetedPlayer.position.x > transform.position.x)
        {
            //move right
            transform.Translate(transform.right * speed * Time.deltaTime);

        }
        else
        {
            //move left
            transform.Translate(-transform.right * speed * Time.deltaTime);
        }
    }
        
}