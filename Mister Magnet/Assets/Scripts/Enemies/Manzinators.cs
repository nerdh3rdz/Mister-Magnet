using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manzinators : Enemy
{
    private bool isMovementUpCooldown;
    private float enemyFlightSpeed;

    protected override void Start()
    {
        base.Start();
        enemyFlightSpeed = enemySpeed;
    }
    protected override void Update()
    {
        base.Update();
        transform.localPosition += Vector3.up * enemyFlightSpeed * Time.deltaTime;
    }

    protected override void Move()
    {
        base.Move();
        if (Math.Abs(originalPosition.y - transform.localPosition.y) >= enemyRange && !isMovementUpCooldown)
        {
            enemyFlightSpeed = -enemyFlightSpeed;       //4 2 1 0 1 2 3 4
            StartCoroutine(MovementUpCooldown());
            isMovementUpCooldown = true;
        }
    }

    private IEnumerator MovementUpCooldown()
    {
        yield return new WaitForSeconds(1.5f);
        isMovementUpCooldown = false;
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if (collision.gameObject.tag == "Player")
        {
            originalPosition.y = transform.localPosition.y - (2 * (enemyFlightSpeed / Math.Abs(enemyFlightSpeed)));
            enemyFlightSpeed *= -1;
        }
    }
}
