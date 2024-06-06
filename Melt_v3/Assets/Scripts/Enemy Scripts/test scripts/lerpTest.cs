using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lerpTest : MonoBehaviour
{
    public GameObject startPos;
    public GameObject endPos;
    public bool repeatable = false;
    public float speed = 1.0f;

    [SerializeField]
    private EnemyFactoryScript enemyFactoryScriptRef;


    public float duration = 3.0f;

    float startTime, TotalDistance;

 
    IEnumerator Start()
    {

       

          startPos = GameObject.Find("PatrolSphere1");
         endPos = GameObject.Find("PatrolSphere2");



        if(startPos == null)
        {
            Debug.Log("not found startPos");
            startPos = GameObject.Find("PatrolSphere1");
        }
        else
            Debug.Log("found startPos");


        if (endPos == null)
        {
            Debug.Log("not found endPos");
            endPos = GameObject.Find("PatrolSphere2");
        }
        else
            Debug.Log("found endPos");


        



        startTime = Time.time;
        TotalDistance = Vector3.Distance(startPos.transform.position, endPos.transform.position);
        while(repeatable)
        {
            yield return RepeatLerp(startPos.transform.position, endPos.transform.position, duration);
            yield return RepeatLerp(endPos.transform.position, startPos.transform.position, duration);
        }
    }

    private void Update()
    {
        if(!repeatable)
        {
            float currentDuration = (Time.time - startTime) * speed;
            float journyFraction = currentDuration / TotalDistance;

           // this.transform.position = Vector3.Lerp(startPos.transform.position, endPos.transform.position, journyFraction);
            transform.position = Vector3.Lerp(startPos.transform.position, endPos.transform.position, journyFraction);
        }
    }

    public IEnumerator RepeatLerp(Vector3 a, Vector3 b, float time)
    {
        float i = 0.0f;
        float rate = (1.0f / time) * speed;
        while(i< 1.0f)
        {
            i += Time.deltaTime * rate;
            //this.transform.position = Vector3.Lerp(a, b, i);
            transform.position = Vector3.Lerp(a, b, i);
            yield return null;
        }
    }
}
