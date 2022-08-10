using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private LevelManager levelManagerRef;

    [SerializeField]
    private PlayerHealth PlayerHealthRef;

    void Start()
    {
        levelManagerRef = FindObjectOfType<LevelManager>();

        PlayerHealthRef = FindObjectOfType<PlayerHealth>();

        if (levelManagerRef == null)
        {
            levelManagerRef = FindObjectOfType<LevelManager>();
        }

        if (PlayerHealthRef == null)
        {
            PlayerHealthRef = FindObjectOfType<PlayerHealth>();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "player(Clone)")
        {

            PlayerHealthRef.TakeDanage(10.0f);

            levelManagerRef.RespawnPlayer();
        }
    }







}
