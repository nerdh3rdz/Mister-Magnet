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
    private float bootRadius = 0.25f;
    [SerializeField]
    private LayerMask enemyLayers;

    public GameObject forceField, magneticField, deathAnimation, gameOverScreen;
    private PowerField barrier, misterMagnetMagnet;

    private bool immune = false;

    void Start() => Magnathan = player.GetComponent<PlayerController>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float force = 0;

        if (!immune)
        {
            //METHOD 2 checking for collision with enemies/obstacles: Check the tag of the gameobject
            if (collision.gameObject.tag == "Enemies")
            {
                if (StompEnemy())   //This will check if it was the player's boots that collided with the enemy.
                {
                    Destroy(collision.gameObject);
                    ScoreManager.Instance.AddScore(5);
                }
                else
                {
                    HealthManager.Instance.TakeDamage(2.5f);
                    force = collision.gameObject.GetComponent<Enemy>().enemySpeed;

                }
            }
            else if (collision.gameObject.tag == "Bullet")
            {
                Destroy(collision.gameObject);
                HealthManager.Instance.TakeDamage(5.0f);
                force = collision.gameObject.GetComponent<Bullet>().BulletSpeed;
            }
            else if (collision.gameObject.tag == "Laser")
            {
                HealthManager.Instance.TakeDamage(7.0f);
                force = 1.0f;
            }

            KnockBack(force / 10);
        }
        else if (collision.gameObject.tag != "Ground" && collision.gameObject.tag != "Door")
            Destroy(collision.gameObject);

        if (HealthManager.Instance.GetHealth() <= 0.0f)
        {
            Instantiate(deathAnimation, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            gameOverScreen.SetActive(true);
        }
    }

    private void KnockBack(float force) //This will push the player back with a force depending on the object it collided with.
    {
        Magnathan.Flip(-force); //This will flip the player if he is hit on the back.

        if (force != 0)
            StartCoroutine(HitAnimation());

        transform.position += Vector3.right * force;
    }

    private IEnumerator HitAnimation()
    {
        Magnathan.animator.SetBool("hit", true);
        yield return new WaitForSeconds(0.5f);
        Magnathan.animator.SetBool("hit", false);
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

    //The following functions are for the Demagnetizing Fields and EMP.
    private float slowAmount = 1.5f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Demagnetizing Field" && !immune)
            Magnathan.moveSpeed -= slowAmount;
        else if (collision.gameObject.tag == "EMP" && !immune)
        {
            Magnathan.moveSpeed -= slowAmount;
            HealthManager.Instance.TakeDamage(HealthManager.Instance.GetCurrentHealth()/5);
            StartCoroutine(HitAnimation());
            StartCoroutine(EMPEffect());
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Demagnetizing Field" && !immune)
            HealthManager.Instance.TakeDamage(0.0125f);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Demagnetizing Field")
            Magnathan.moveSpeed += slowAmount;
        else if (collision.gameObject.tag == "Bottomless Pit")
        {
            gameObject.SetActive(false);
            gameOverScreen.SetActive(true);
        }
    }

    private IEnumerator EMPEffect()
    {
        yield return new WaitForSeconds(2.0f);
        Magnathan.moveSpeed += slowAmount;
    }

    //Power-Ups on the Player.
    public IEnumerator StartImmunity()
    {
        immune = true;    Magnathan.moveSpeed = 10.0f;

        barrier = Instantiate(forceField, transform.position, Quaternion.identity).GetComponent<PowerField>();
        barrier.PlayerCore = transform;
        barrier.PlayerPosition = player.transform;

        yield return new WaitForSeconds(20.0f);
        immune = false;   Magnathan.moveSpeed = 5.0f;
    }

    public void StartMagneticism()
    {
        misterMagnetMagnet = Instantiate(magneticField, transform.position, Quaternion.identity).GetComponent<PowerField>();
        misterMagnetMagnet.PlayerPosition = transform;
        misterMagnetMagnet.PlayerCore = transform;
    }
}
