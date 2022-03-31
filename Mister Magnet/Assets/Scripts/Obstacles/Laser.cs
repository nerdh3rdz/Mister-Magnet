using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject LaserBeamPrefab;
    public float LaserInterval = 2f;

    void Update()
    {
        if (Time.time >= LaserInterval)
        {
            Instantiate(LaserBeamPrefab, transform.position, Quaternion.identity);
            LaserInterval += 2f;
        }
    }
}
