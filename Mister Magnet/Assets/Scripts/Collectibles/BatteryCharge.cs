using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryCharge : Collectible
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.gameObject.tag == "Player")
        {
            ScoreManager.Instance.AddScore(1);
            //AudioManager.Instance.PlaySound("Coin");
            Destroy(gameObject);
        }
    }
}
