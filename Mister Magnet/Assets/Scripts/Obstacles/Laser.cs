using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Obstacle
{
    public GameObject LaserBeamPrefab;
    public float LaserInterval = 2.0f;

    protected override void Start() { } //This is to ignore the Start function of the base class since the laser shooters have no animator.

    protected override void Update()
    {
        if (!IsOff && Time.time >= LaserInterval)
        {
            Instantiate(LaserBeamPrefab, transform.position, Quaternion.identity);
            LaserInterval += 2.0f;
        }
    }
}
