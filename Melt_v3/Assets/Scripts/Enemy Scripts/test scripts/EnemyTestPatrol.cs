
using UnityEngine;

public class EnemyTestPatrol : MonoBehaviour
{
    #region unused variables
    //public int chaseRange =5;
    //public bool isChasing = false;
    #endregion
   // [SerializeField] Transform target;
    public float speed;
    public bool faceingRight = true;
    public int targetPoints;

    public GameObject[] patrolPoints;

    public bool killObject = false;
    public float lifeTimeofObject = 3f;


    // Start is called before the first frame update
    void Start()
    {
        if (targetPoints >= patrolPoints.Length) // if (targetPoints >= patrollingPoints.Length) change if not work
        {
            targetPoints = 0;
        }

       
        patrolPoints = GameObject.FindGameObjectsWithTag("Patrol");

       foreach(GameObject patrolPointschildren in patrolPoints)
        {
            Debug.Log("Transform of object is:" + patrolPointschildren.transform.position);
        }

        //foreach(Transform transformOfObject in patrollingPoints)
        //{
        //    Debug.Log("Transform of object is:" + patrollingPoints + transformOfObject.transform.position);
        //}


        targetPoints = 0;
        faceingRight = true;
        #region unused cached variables
        //target = GameObject.FindGameObjectWithTag("Player").transform;
        // isChasing = false;
        #endregion
        
    }

    // Update is called once per frame
    void Update()
    {
        // float distance = Vector3.Distance(transform.position, target.position);

        if (transform.position.y < 5.53f)
        {
            transform.position = new Vector3(transform.position.x, 5.53f, transform.position.z);

        }
        else if (transform.position.y > 5.53f)
        {
            transform.position = new Vector3(transform.position.x, 5.53f, transform.position.z);
        }

        if (transform.position == patrolPoints[targetPoints].transform.position) //.x       //if (transform.position == patrollingPoints[targetPoints].position) //.x
        {
            IncreaseTargetInt();
        }

        #region old flip enemy code
        ////if (targetPoints == 0 && faceingRight)
        ////{
        ////    //face left
        ////    FlipEnemey();
        ////}
        ////else if (targetPoints != 0 && !faceingRight)
        ////{
        ////    //face right
        ////    FlipEnemey();
        ////}
        ///
        #endregion

        if (targetPoints == 0 && !faceingRight)
        {
            FlipEnemey();
        }
        else if (targetPoints !=0 && faceingRight)
        {
            FlipEnemey();
        }




        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoints].transform.position, speed * Time.deltaTime);  // transform.position = Vector3.MoveTowards(transform.position, patrollingPoints[targetPoints].position, speed * Time.deltaTime);


        lifeTimeofObject -= Time.deltaTime;
        if(lifeTimeofObject <=0)
        {
            Debug.Log("Lifetime: " + lifeTimeofObject.ToString());
            killObject = true;
        }

        if(killObject == true)
        {
            Destroy(gameObject);

            //add explosion animation + damage if near player
        }




        #region distance <= chaseRange
        //if (distance <= chaseRange)
        //{
        ////    //chase player
        //    Debug.Log("chase player now!");
        //    isChasing = true;

        //    transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        //}
        //else if (distance >= chaseRange)
        //{
        ////    //chase player
        //    Debug.Log("Dont chase the player!");

        //    isChasing = false;
        //    transform.position = Vector3.MoveTowards(transform.position, patrollingPoints[targetPoints].position, speed * Time.deltaTime);

        //}
        #endregion
    }

    private void FlipEnemey()
    {
        faceingRight = !faceingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    public void IncreaseTargetInt()
    {

       // Debug.Log("adding 1 to targetpoints" + targetPoints);
        targetPoints++;
       // Debug.Log("targetpoints" + targetPoints);

        if (targetPoints >= patrolPoints.Length) // if (targetPoints >= patrollingPoints.Length) change if not work
        {
            targetPoints = 0;
        }
    }

   




    #region unused code
    //private void FaceEnemyPlayer()
    //{
    //    if( isChasing == true)
    //    {
    //        Debug.Log("face player until out of chaseRange");
    //    }
    //    else if (isChasing == false)
    //    {
    //        Debug.Log("Face nearest patrol point and start patrolling again");
    //    }
    //}
    #endregion
}