using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Obstacle
{
    public GameObject LaserBeamPrefab;
    public float LaserInterval = 2.0f;
    private LaserBeam laserBeam;

    protected override void Update()
    {
        base.Update();
        if (!IsOff && Time.time >= LaserInterval)
        {
            laserBeam = Instantiate(LaserBeamPrefab, transform.position, Quaternion.identity).GetComponent<LaserBeam>();
            laserBeam.zrotation = transform.eulerAngles.z;
            laserBeam.laserScale = transform.localScale;
            LaserInterval += 2.0f;
        }
    }
}
