using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerField : MonoBehaviour
{
    private float lifeTime = 20.0f;

    public Transform PlayerPosition, PlayerCore;

    void Start() => Destroy(gameObject, lifeTime);

    void Update()
    {
        //Follow the player's position and scale
        transform.position = PlayerPosition.transform.position;
        transform.localScale = new Vector3(transform.localScale.x, PlayerCore.localScale.y / Math.Abs(PlayerCore.localScale.y), transform.localScale.z);
    }
}
