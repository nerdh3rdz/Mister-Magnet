using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : Collectible
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.gameObject.tag == "Player")
        {
            GetPowerUp(collision);
            Destroy(this.gameObject);
        }
    }

    protected abstract void GetPowerUp(Collider2D collision);
}
