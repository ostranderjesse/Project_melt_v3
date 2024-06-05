using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpObjectA2B : MonoBehaviour
{
    [SerializeField]
    private Transform startCube;
    [SerializeField]
    private Transform endCube;

    [SerializeField]
    [Range(0f,1f)]
    private float lerpAmount = 0.5f;

    [SerializeField]
    private bool faceingRight = true;

    private void Start()
    {
        faceingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(startCube.position, endCube.position, lerpAmount * Time.deltaTime);

        //if (transform.position == startCube.position)
        //{
        //    FlipEnemy();
        //}
        //else if(transform.position == endCube.position)
        //    FlipEnemy();
       
    }


    private void FlipEnemy()
    {
        faceingRight = !faceingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
