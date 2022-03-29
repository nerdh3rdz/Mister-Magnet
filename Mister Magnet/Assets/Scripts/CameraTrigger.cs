using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraTrigger : MonoBehaviour
{
    private CinemachineVirtualCamera Camera;
    private static int CameraPrio = 1;

    void Start() => Camera = GetComponent<CinemachineVirtualCamera>();

    void Update()
    {
        if (Camera.Priority < CameraPrio && Camera.Priority != 0)
            gameObject.SetActive(false);    //This is to prevent the player and camera from respectively triggering and transitioning to the PREVIOUS camera.
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Camera.m_Follow = collision.gameObject.transform;
            Camera.Priority = ++CameraPrio;
         
        }
    }

}
