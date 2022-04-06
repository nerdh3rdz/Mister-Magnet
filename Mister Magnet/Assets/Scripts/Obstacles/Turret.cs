using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Obstacle
{
    public GameObject turretBulletPrefab;
    private Bullet turretBullet;
    private float previousshot = 0.0f;
    public float enemyFireRate = 1.0f;
    [SerializeField]
    private bool facingRight;    //Couldn't get EulerAngles to work here zz

    protected override void Update()
    {
        base.Update();
        if (!IsOff && Time.time >= previousshot)
        {
            turretBullet = Instantiate(turretBulletPrefab, transform.position, Quaternion.identity).GetComponent<Bullet>();
            //This is to change the direction of the bullet depending on which side the turret is facing. 
            turretBullet.facingRight = facingRight;
            previousshot += enemyFireRate;
        }
    }
}

