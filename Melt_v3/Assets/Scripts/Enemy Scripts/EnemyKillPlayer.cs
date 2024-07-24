using UnityEngine;

public class EnemyKillPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private LevelManager levelManagerRef;

    [SerializeField]
    private PlayerHealth playerHealthRef;

    [SerializeField]
    private PlayerMovementScript playerMovementRef;


    public Vector3 distanceThrown;

    void Start()
    {

        distanceThrown = new Vector3(1.0f, 1.0f, 0.0f);


        levelManagerRef = FindObjectOfType<LevelManager>();

        playerHealthRef = FindObjectOfType<PlayerHealth>();

        playerMovementRef = FindObjectOfType<PlayerMovementScript>();

        if (levelManagerRef == null)
        {
            levelManagerRef = FindObjectOfType<LevelManager>();
        }

        if (playerHealthRef == null)
        {
            playerHealthRef = FindObjectOfType<PlayerHealth>();
        }

        if (playerMovementRef == null)
        {
            playerMovementRef = FindObjectOfType<PlayerMovementScript>();
        }

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Snowman Player(Clone)")                         //"player(Clone)")
        {

            Vector3 hitDirection = other.transform.position - distanceThrown;
            //hitDirection = hitDirection.normalized;

            playerHealthRef.killPlayer(10.0f);

            levelManagerRef.RespawnPlayer();
        }
    }

}