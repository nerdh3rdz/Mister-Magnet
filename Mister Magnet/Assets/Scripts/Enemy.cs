using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    public float enemySpeed;

    protected Vector3 originalPosition;

    protected Animator animator;
    protected bool facingLeft = true;

    protected virtual void Start()
    {
        originalPosition = transform.position;
        animator = GetComponent<Animator>();
    }

    protected void Update()
    {
        Flip(enemySpeed);
        animator.SetFloat("speed", Mathf.Abs(enemySpeed));
        Move();

    }

    protected virtual void Move()
    {
        if (Math.Abs(originalPosition.x - transform.position.x) >= 2.0f)
            enemySpeed = -enemySpeed;
        transform.position += Vector3.right * enemySpeed * Time.deltaTime;
    }

    protected void Flip(float movement)
    {
        //if we have positive input and not facing right (facing left)
        // OR
        //if we have negative input and we are facing right
        if (movement < 0 && !facingLeft || movement > 0 && facingLeft)
        {
            //toggle the boolean
            facingLeft = !facingLeft;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enemySpeed = -enemySpeed;
            originalPosition.x += originalPosition.x - transform.position.x;
        }
    }
}
