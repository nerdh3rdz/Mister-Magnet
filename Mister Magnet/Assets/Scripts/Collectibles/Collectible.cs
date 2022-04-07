using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    protected Vector3 originalPosition;
    protected float collectibleSpeed = 0.125f;
    protected float collectibleRange = 0.125f;
    private bool isMovementCooldown, goToPlayer;

    private Rigidbody2D collectibleRigidBody;
    private Transform player;
    private Vector2 playerDirection;
    private float timeStamp;

    void Start()
    {
        originalPosition = transform.localPosition;
        collectibleRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() => Move();

    private void Move()
    {
        if (Math.Abs(originalPosition.y - transform.localPosition.y) >= collectibleRange && !isMovementCooldown)
        {
            collectibleSpeed *= -1;
            StartCoroutine(MovementCooldown());
            isMovementCooldown = true;
        }
        if(!goToPlayer) //collectible will move up and down unless the player has a magnet power-up and is near the collectible.
            transform.localPosition += Vector3.up * collectibleSpeed * Time.deltaTime;
        else
        {
            playerDirection = -(transform.position - player.position).normalized;
            collectibleRigidBody.velocity = new Vector2(playerDirection.x, playerDirection.y) * 25.0f * (Time.time / timeStamp);
        }
    }
    private IEnumerator MovementCooldown()
    {
        yield return new WaitForSeconds(0.25f);
        isMovementCooldown = false;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Magnetic Field")
        {
            timeStamp = Time.time;
            player = collision.gameObject.transform;
            goToPlayer = true;
        }
    }
}
