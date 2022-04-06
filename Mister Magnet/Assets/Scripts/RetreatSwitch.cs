using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetreatSwitch : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            if (Input.GetKeyDown(KeyCode.Space))
                SceneManager.LoadScene(4);
    }
}
