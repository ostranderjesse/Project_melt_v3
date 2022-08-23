using UnityEngine;
using Cinemachine;

public class CameraFollowOverWorld : MonoBehaviour
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
        tPlayer = GameObject.FindGameObjectWithTag("OWPlayer");

        if (vcam == null)
        {
            vcam = GetComponent<CinemachineVirtualCamera>();
        }

        if (tPlayer == null)
        {
            tPlayer = GameObject.FindGameObjectWithTag("OWPlayer");
        }
        tfollowTarget = tPlayer.transform;
        vcam.LookAt = tfollowTarget;
        vcam.Follow = tfollowTarget;

    }
}
