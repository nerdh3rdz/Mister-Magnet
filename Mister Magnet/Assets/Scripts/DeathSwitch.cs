using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSwitch : MonoBehaviour
{
    [SerializeField]
    private GameObject DeathRoom;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            if (Input.GetKeyDown(KeyCode.Space))
                DeathRoom.SetActive(true);
    }
}
