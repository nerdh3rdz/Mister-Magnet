using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemagnitizingField : Obstacle
{
    private BoxCollider2D dmf;

    protected override void Start()
    {
        base.Start();
        dmf = GetComponent<BoxCollider2D>();
    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (IsOff && this.transform.childCount >= 1)
            Destroy(transform.GetChild(0).gameObject);

        dmf.enabled = !IsOff;   //Disable collider when dmf is deactivated
    }
}
