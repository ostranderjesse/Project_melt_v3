
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    #region variables

    public GameObject tPlayer;
    public Transform tfollowTarget;
    [SerializeField] private CinemachineVirtualCamera vcam;

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
        tPlayer = GameObject.FindGameObjectWithTag("Player");

        if( vcam == null)
        {
            vcam = GetComponent<CinemachineVirtualCamera>();
        }

        if(tPlayer == null)
        {
            tPlayer = GameObject.FindGameObjectWithTag("Player");
        }
        tfollowTarget = tPlayer.transform;
        vcam.LookAt = tfollowTarget;
        vcam.Follow = tfollowTarget;

    }
}
