using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraTrigger : MonoBehaviour
{
    public GameObject LookAheadCamera;
    private CinemachineVirtualCamera Camera, PreviewCamera;
    private static int CameraPrio = 1;

    void Start()
    {
        Camera = GetComponent<CinemachineVirtualCamera>();
        if (LookAheadCamera != null)
            PreviewCamera = LookAheadCamera.GetComponent<CinemachineVirtualCamera>();
    }

    void Update()
    {
        if (Camera.Priority < CameraPrio && Camera.Priority > 0)
            gameObject.SetActive(false);    //This is to prevent the player and camera from respectively triggering and transitioning to the PREVIOUS camera.
    }

    private void OnTriggerEnter2D(Collider2D collision) //switching of cameras
    {
        if (collision.gameObject.tag == "Player")
        {
            Camera.m_Follow = collision.gameObject.transform;
            Camera.Priority = ++CameraPrio;

            if (LookAheadCamera != null)
                StartCoroutine(SeeAhead());
        }
    }

    private IEnumerator SeeAhead()
    {
        PreviewCamera.Priority = CameraPrio + 10;
        yield return new WaitForSeconds(3.0f);
        PreviewCamera.Priority = CameraPrio - 1;
        LookAheadCamera.SetActive(false);
    }

}
