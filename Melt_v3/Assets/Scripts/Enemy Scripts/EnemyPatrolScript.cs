using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolScript : MonoBehaviour
{

    public Transform[] patrolPoints;
    public int targetPoint;
    public float speed;

    public bool facingRight = true;

    #region unused variables
    // private string currentState = "IdleState";
    //  private Transform target;
    //public float chaseRange = 5;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        targetPoint = 0;
        //target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == patrolPoints[targetPoint].position)
        {
            IncreaseTargetInt();
        }
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);

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
}