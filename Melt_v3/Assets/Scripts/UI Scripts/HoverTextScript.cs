using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HoverTextScript : MonoBehaviour
{
    public Text textToMove;
    public float timePassed;

    public float speed;

    // Update is called once per frame
    void Update()
    {
        // transform.Rotate(Vector3.left * speed * Time.deltaTime);

        //float y = Mathf.PingPong(Time.time * speed, 1) * 6 - 3;

        //textToMove.transform.position = new Vector3(0, y, 0);
     

      // textToMove.transform.position = new Vector3(0, y, 0);
        //transform.Rotate(0, y, 0);

    }

}
