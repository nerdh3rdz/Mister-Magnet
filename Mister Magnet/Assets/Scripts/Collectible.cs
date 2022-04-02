using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    protected Vector3 originalPosition;
    protected float collectibleSpeed = 0.25f;
    protected float collectibleRange = 0.125f;
    private bool isMovementCooldown;

    void Start() => originalPosition = transform.localPosition;

    // Update is called once per frame
    void Update() => Move();

    protected virtual void Move()
    {
        if (Math.Abs(originalPosition.y - transform.localPosition.y) >= collectibleRange && !isMovementCooldown)
        {
            collectibleSpeed *= -1;
            StartCoroutine(MovementCooldown());
            isMovementCooldown = true;
        }
        transform.localPosition += Vector3.up * collectibleSpeed * Time.deltaTime;
    }
    private IEnumerator MovementCooldown()
    {
        yield return new WaitForSeconds(0.25f);
        isMovementCooldown = false;
    }
}
