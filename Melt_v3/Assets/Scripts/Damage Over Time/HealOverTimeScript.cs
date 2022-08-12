using UnityEngine;
using System.Collections;

public class HealOverTimeScript : MonoBehaviour
{
    #region variables

    public float ticTimeH;

    [SerializeField]
    private PlayerHealth PlayerHealthRef;

    #endregion

    public void Start()
    {
        PlayerHealthRef = FindObjectOfType<PlayerHealth>();

        if (PlayerHealthRef == null)
        {
            PlayerHealthRef = FindObjectOfType<PlayerHealth>();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")     //if(other.name == "player(Clone)")  "DamageOverTimeAera"
        {

            StartCoroutine(Wait2HealCoroutine());
            StopCoroutine(Wait2HealCoroutine());

                ticTimeH -= Time.deltaTime;

            if (ticTimeH <= 0)
            {
                PlayerHealthRef.HealDamage(10.0f);
                Debug.Log("Healed");
                ticTimeH = 0.5f;
                //Debug.Log("tickTimeH reset");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
       if(other.gameObject.tag == "Player")
        {
            Debug.Log("exited heal area");

            if(ticTimeH != 0.5f) //1.0f
            {
                ticTimeH = 0.5f; // 1.0f
                Debug.Log("ticTime heal has been reset to: " + ticTimeH);
            }
        }
    }


    IEnumerator Wait2HealCoroutine()
    {
        Debug.Log("Started coroutine at timestamp:" + Time.time);

        yield return new WaitForSeconds(5);

        Debug.Log("Stopped coroutine at timestamp:" + Time.time);

    }

}
