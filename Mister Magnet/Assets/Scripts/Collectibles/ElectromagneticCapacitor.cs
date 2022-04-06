using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectromagneticCapacitor : PowerUp
{
    private PlayerInteraction Magnathan;

    protected override void GetPowerUp(Collider2D collision)
    {
            Magnathan = collision.gameObject.GetComponent<PlayerInteraction>();
            Magnathan.StartCoroutine(Magnathan.StartImmunity());
    }
}
