using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    protected override void ResolveUnitCollision(Collision collision)
    {
        TakeDamage();
    }

    protected override void ResolveWallCollision(Collision collision)
    {
        Bounce(collision);
    }

    protected override void UnitDeath()
    {
        base.UnitDeath();
    }
}
