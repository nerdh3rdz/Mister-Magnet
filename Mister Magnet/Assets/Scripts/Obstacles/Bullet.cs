using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed = 5.0f;
    [SerializeField]
    private float lifeTime = 1.0f;

    public bool facingRight = true;
   // public float Damage { get; set; }
    // The above property is a shortcut for this:
    /*
       private float _damage;

       public float Damage
       {
           get { return _damage; }
           set { _damage = value; }
       }*/

    private Rigidbody2D _rigidbody;

    void Start()
    {
        //METHOD 3 of movement: setting the velocity of the rigidbody of the gameobject
        //Assign the attached Rigidbody2D component of our gameobject to the _rigidbody variable
        _rigidbody = GetComponent<Rigidbody2D>();
        //This is for the bullet's direction which will depend on where the turret is pointing at.
        _rigidbody.velocity = new Vector2(facingRight ? bulletSpeed : -bulletSpeed, 0);

        Destroy(this.gameObject, lifeTime);
    }
    public float BulletSpeed => facingRight ? bulletSpeed : -bulletSpeed;
}
