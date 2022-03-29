using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    public float enemySpeed = 0.5f;

    private Vector3 originalPosition;

    private Animator animator;

    private bool facingLeft = true;


    void Start()
    {
        originalPosition = transform.position;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Flip(enemySpeed);
        if (Math.Abs(originalPosition.x - transform.position.x) >= 2.0f)
            enemySpeed = -enemySpeed;
        animator.SetFloat("speed", Mathf.Abs(enemySpeed));

        transform.position += Vector3.right * enemySpeed * Time.deltaTime;
    }

    private void Flip(float movement)
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
}
