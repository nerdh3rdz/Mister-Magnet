using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : Obstacle
{
    public GameObject objectToDeactivate;
    private Obstacle obstacle;

    protected override void Start()
    {
        base.Start();
        obstacle = objectToDeactivate.GetComponent<Obstacle>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            if (Input.GetKeyDown(KeyCode.Space))
            {
                obstacle.Deactivate();
                this.Deactivate();
            }
    }
}
