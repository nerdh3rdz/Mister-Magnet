using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject turretBulletPrefab;
    private Bullet turretBullet;
    public float enemyFireRate = 3.0f;

    void Update()
    {
        if (Time.time >= enemyFireRate)
        {
            turretBullet = Instantiate(turretBulletPrefab, transform.position, Quaternion.identity).GetComponent<Bullet>();
            turretBullet.facingRight = (transform.rotation.y == 1);
            enemyFireRate += 3.0f;
        }
    }
}

