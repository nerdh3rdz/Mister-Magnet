using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Obstacle
{
    private BoxCollider2D door;

    protected override void Start()
    {
        base.Start();
        door = GetComponent<BoxCollider2D>();
    }

    protected override void Update()
    {
        base.Update();
        door.enabled = !IsOff;
    }
}
