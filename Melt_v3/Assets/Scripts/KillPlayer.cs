using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private LevelManager levelManagerRef;
    void Start()
    {
        levelManagerRef = FindObjectOfType<LevelManager>();

        if(levelManagerRef == null)
        {
            levelManagerRef = FindObjectOfType<LevelManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "player(Clone)")
        {
            levelManagerRef.RespawnPlayer();
        }
    }
}
