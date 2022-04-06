using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gonzalbeasts : Enemy
{
    private bool IsCharging = false;
   
    protected override void Move()
    {
        if (!IsCharging)
            base.Move();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            IsCharging = true;
            enemySpeed *=2;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            IsCharging = false;
            enemySpeed /=2;
            originalPosition.x = transform.localPosition.x - (2 * (enemySpeed / Math.Abs(enemySpeed)));
            enemySpeed *= -1;
        }
    }
}
