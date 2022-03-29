using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryCharge : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ScoreManager.Instance.AddScore(Random.Range(1,5));
            //AudioManager.Instance.PlaySound("Coin");
            Destroy(this.gameObject);
        }
    }
}
