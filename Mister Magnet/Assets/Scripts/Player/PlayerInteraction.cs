using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Player")]
    public GameObject player;
    private PlayerController Magnathan;
    [Header("Player Boots")]
    [SerializeField]
    private Transform playerBoots;
    [SerializeField]
    private float bootRadius = 0.2f;
    [SerializeField]
    private LayerMask enemyLayers;

    void Start() => Magnathan = player.GetComponent<PlayerController>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float force = 0;

        //METHOD 2 checking for collision with enemies/obstacles: Check the tag of the gameobject
        if (collision.gameObject.tag == "Enemies")
        {
            if (StompEnemy())   //This will check if it was the player's boots that collided with the enemy.
                Destroy(collision.gameObject);
            else
            {
                HealthManager.Instance.TakeDamage(2.5f);
                force = collision.gameObject.GetComponent<Enemy>().enemySpeed;
            }
        }

        if (HealthManager.Instance.GetHealth() <= 0.0f)
            Destroy(this.gameObject);
        
        if (collision.gameObject.tag != "Ground")
            KnockBack(force * 5);

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Ground")
            Magnathan.animator.SetBool("hit", false);
    }

    private void KnockBack(float force) //This will push the player back with a force depending on the object it collided with.
    {
        bool hit = Convert.ToBoolean(force);
        Magnathan.animator.SetBool("hit", hit);
        Debug.Log(hit);
        Magnathan.Flip(force); //This will flip the player if he is hit on the back.

        //transform.position += Vector3.right * force; //haven't figured this one out yet.
    }

    private bool StompEnemy()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(playerBoots.position, bootRadius, enemyLayers);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)//make sure that the gameobject we are colliding is not our own
                return true;
        }
        return false;
    }
}
