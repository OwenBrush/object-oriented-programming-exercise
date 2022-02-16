using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] protected float damageValue;
    [SerializeField] protected float speed;
    [SerializeField] protected float health
    {
        get { return health; }
        set
        {
            if (value <= 0f)
            {
                health = 0;
                UnitDeath();
            }
            else
            {
                health = value;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            ResolveWallCollision();
        }
        else if (collision.gameObject.CompareTag("Unit"))
        {
            ResolveUnitCollision();
        }

    }

    protected void TakeDamage()
    {
        health -= damageValue;
    }

    protected virtual void ResolveUnitCollision()
    {
        Debug.Log($"{gameObject.name} collision with unit");
    }

    protected virtual void ResolveWallCollision()
    {
        Debug.Log($"{gameObject.name} collision with wall");
    }

    protected virtual void UnitDeath()
    {
        Destroy(gameObject);
    }

}
