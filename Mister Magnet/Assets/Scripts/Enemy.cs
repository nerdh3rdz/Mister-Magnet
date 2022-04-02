using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movement")]
    public float enemySpeed;
    public float enemyRange;

    protected Vector3 originalPosition;

    protected Animator animator;
    protected bool facingLeft = true;

    private bool isMovementCooldown;

    protected virtual void Start()
    {
        //Arisa - changed to localPosition
        originalPosition = transform.localPosition;
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
        //Debug.Log("difference is " + (originalPosition.x - transform.position.x));
        //Arisa:
        //if (Math.Abs(originalPosition.x - transform.localPosition.x) >= 2.0f)
        //The problem lies on this^ condition, since it is called in the update every frame, 
        //When the player collides, this statement would always be true and it always switches the enemy speed

        //Solution: Added a "cooldown" for the checker to ensure that the enemy keeps a certain distance first
        //before checking if they need to change directions again

        //Also, I used localPosition instead of the transform since it's a good practice to use the localspace
        //when your game object is a child or has a parent
        if (Math.Abs(originalPosition.x - transform.localPosition.x) >= enemyRange && !isMovementCooldown)
        {
            enemySpeed = -enemySpeed;       //4 2 1 0 1 2 3 4
            StartCoroutine(MovementCooldown());
            isMovementCooldown = true;
        }
        transform.localPosition += Vector3.right * enemySpeed * Time.deltaTime;
    }

    private IEnumerator MovementCooldown()
    {
        yield return new WaitForSeconds(1.5f);
        isMovementCooldown = false;
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
                //Arisa - changed to localPosition
                //James - Fixed the updating of the original position.
                //Bug - Enemy keeps on changing direction once the distance between
                //the original position and localPosition becomes greater than 2.
                originalPosition.x = transform.localPosition.x - (2 * (enemySpeed / Math.Abs(enemySpeed)));
                enemySpeed *= -1;
            }
    }
}
