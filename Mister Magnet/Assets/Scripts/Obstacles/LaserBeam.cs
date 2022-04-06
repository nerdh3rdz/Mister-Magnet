using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    [SerializeField]
    private float lifeTime = 1.05f;
    public float zrotation = 0.0f;
    public Vector3 laserScale;

    void Start()
    {
        transform.localScale = laserScale;
        transform.Rotate(0, 0, zrotation);
        Destroy(this.gameObject, lifeTime);
    }
}
