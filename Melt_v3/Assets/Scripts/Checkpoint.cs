
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private LevelManager levelManagerRef;

    // Start is called before the first frame update
    void Start()
    {
        levelManagerRef = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "player(Clone)")
        {
            levelManagerRef.currentCheckPoint =  gameObject;

            Debug.Log("Current checkpoint: " + transform.position);
        }
    }
}
