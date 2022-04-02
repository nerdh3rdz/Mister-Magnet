using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryCharge : Collectible
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ScoreManager.Instance.AddScore(1);
            //AudioManager.Instance.PlaySound("Coin");
            Destroy(this.gameObject);
        }
    }
}
