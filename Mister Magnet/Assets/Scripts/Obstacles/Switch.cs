using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : Obstacle
{
    public GameObject objectToDeactivate, objectToActivate;
    private Obstacle obstacle1, obstacle2;

    protected override void Start()
    {
        base.Start();
        if (objectToDeactivate != null)
            obstacle1 = objectToDeactivate.GetComponent<Obstacle>();
        if (objectToActivate != null)
            obstacle2 = objectToActivate.GetComponent<Obstacle>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (objectToDeactivate != null)
                    obstacle1.Deactivate();
                if(objectToActivate!=null)
                    obstacle2.Activate();

                this.Deactivate();
            }
    }
}
