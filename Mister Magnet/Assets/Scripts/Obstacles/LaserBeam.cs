using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    [SerializeField]
    private float lifeTime = 1.05f;

    // public float Damage { get; set; }
    // The above property is a shortcut for this:
    /*
       private float _damage;

       public float Damage
       {
           get { return _damage; }
           set { _damage = value; }
       }*/

    void Start() => Destroy(this.gameObject, lifeTime);
}
