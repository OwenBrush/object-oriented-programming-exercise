using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    protected override void ResolveUnitCollision(Collision collision)
    {
        base.ResolveUnitCollision(collision);
    }

    protected override void ResolveWallCollision(Collision collision)
    {
        TakeDamage();
    }

    protected override void UnitDeath()
    {
        base.UnitDeath();
    }
}
