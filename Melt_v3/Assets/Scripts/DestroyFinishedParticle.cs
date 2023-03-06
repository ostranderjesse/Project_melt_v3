using UnityEngine;

public class DestroyFinishedParticle : MonoBehaviour
{

    private ParticleSystem thisParticleSystem;


    // Start is called before the first frame update
    void Start()
    {
        thisParticleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(thisParticleSystem.isPlaying)
        {
            return;
        }
        else
        Destroy(gameObject); // original code = gameobject
        
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}