using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{

    private void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        Vector3 force = (Vector3.forward * zInput * speed) + (Vector3.right * xInput * speed);

        rb.AddForce(force);
    }

    protected override void ResolveUnitCollision(Collision collision)
    {
        Bounce(collision);
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
