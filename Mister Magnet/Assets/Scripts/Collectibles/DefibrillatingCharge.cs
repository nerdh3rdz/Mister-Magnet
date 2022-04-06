using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefibrillatingCharge : PowerUp
{
    protected override void GetPowerUp(Collider2D collision) => HealthManager.Instance.RestoreHealth();
}
