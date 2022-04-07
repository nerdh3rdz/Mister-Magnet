using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : Obstacle
{
    public GameObject objectToDeactivate, objectToActivate;
    private Obstacle obstacle1, obstacle2;
    private bool TouchButton = false;
    protected override void Start()
    {
        base.Start();
        if (objectToDeactivate != null)
            obstacle1 = objectToDeactivate.GetComponent<Obstacle>();
        if (objectToActivate != null)
            obstacle2 = objectToActivate.GetComponent<Obstacle>();
    }
    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Space) && TouchButton)
        {
            if (objectToDeactivate != null)
                obstacle1.Deactivate();
            if (objectToActivate != null)
                obstacle2.Activate();

            this.Deactivate();
        }
    }

    //Detect when the player is near the button or not.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            TouchButton = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            TouchButton = false;
    }
}
