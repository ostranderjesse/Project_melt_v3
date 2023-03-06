using UnityEngine;

public class DamageOverTimeScript : MonoBehaviour
{
    #region variables

    public float ticTimeD; // tic Damage

    [SerializeField]
    private PlayerHealth PlayerHealthRef;

    public bool playerInDamageArea;

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
        if(other.gameObject.tag == "Player")     //if(other.name == "player(Clone)")  "DamageOverTimeAera"
        {
            playerInDamageArea = true;

            ticTimeD -= Time.deltaTime;

            if (ticTimeD <= 0)
            {
                PlayerHealthRef.TakeDanage(5);
                Debug.Log("Damaged");
                ticTimeD = 2.0f;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerInDamageArea = false;

            //reset ticTime back to 2
            ticTimeD = 1.0f;

            //Debug.Log("Reset ticTime back to: " + ticTimeD);

        }
    }
}