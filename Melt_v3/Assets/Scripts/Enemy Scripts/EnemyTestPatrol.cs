using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTestPatrol : MonoBehaviour
{
    [SerializeField] Transform target;
    public float speed;
    public bool faceingRight = true;
    public int chaseRange =5;

    public int targetPoints;
    public Transform[] patrollingPoints;
    public GameObject theEnemy;


    // Start is called before the first frame update
    void Start()
    {
        targetPoints = 0;

        //theEnemy = this.gameObject;
        target = GameObject.FindGameObjectWithTag("Player").transform;

      // transform.position = new Vector3()
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        //if(transform.position.y < 5.7f)
        //{
        //    transform.position = new Vector3(transform.position.x, 5.7f, transform.position.z);
        //}


        if(transform.position.x == patrollingPoints[targetPoints].position.x)
        {
            IncreaseTargetInt();
        }

        if (targetPoints == 0 && faceingRight)
        {
            //face left
            FlipEnemey();
        }
        else if (targetPoints != 0 && !faceingRight)
        {
            //face right
            FlipEnemey();
        }

        if (transform.position.y > 5.616f)
        {
            transform.position = new Vector3(transform.position.x, 5.7f, transform.position.z);
        }

        transform.position = Vector3.MoveTowards(transform.position, patrollingPoints[targetPoints].position, speed * Time.deltaTime);
        //MoveAiToPatrollPoint();


        if (distance <= chaseRange)
        {
            //chase player
            Debug.Log("chase player now!");
            MoveTheAiToPlayer();

        }
        else if (distance >= chaseRange)
        {
            //chase player
            Debug.Log("Dont chase the player!");
           // MoveAiToPatrollPoint();


        }

        //if(target.position.x > transform.position.x)
        //{
        //    //move right
        //    transform.Translate(transform.right * speed * Time.deltaTime);

        //}else
        //{
        //    //move left
        //    transform.Translate(-transform.right * speed * Time.deltaTime);
        //}


    }

    private void MoveAiToPatrollPoint()
    {
        if (transform.position.y > 5.616f)
        {
            transform.position = new Vector3(transform.position.x, 5.7f, transform.position.z);
        }

        if (patrollingPoints[targetPoints].position.x > transform.position.x)
        {
            //move left
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
        else
        {
            //move right
            transform.Translate(-transform.right * speed * Time.deltaTime);
        }
    }

    private void MoveTheAiToPlayer()
    {
        if (target.position.x > transform.position.x)
        {
            //move right
            if(transform.position.y > 5.616f)
            {
                transform.position = new Vector3(transform.position.x, 5.7f, transform.position.z);
            }
            transform.Translate(transform.right * speed * Time.deltaTime);

        }
        else
        {
            //move left
            transform.Translate(-transform.right * speed * Time.deltaTime);
        }
    }

    private void FlipEnemey()
    {
        faceingRight = !faceingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    private void IncreaseTargetInt()
    {
        Debug.Log("adding 1 to targetpoints" + targetPoints);
        targetPoints++;
        Debug.Log("targetpoints" + targetPoints);

        if (targetPoints >= patrollingPoints.Length)
        {
            targetPoints = 0;
        }
    }


}
