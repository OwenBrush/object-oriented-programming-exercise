using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] protected float bounceValue;
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
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            ResolveWallCollision(collision);
        }
        else if (collision.gameObject.CompareTag("Unit"))
        {
            ResolveUnitCollision(collision);
        }

    }
  protected void Bounce(Collision collision)
    {
        rb.AddForce(collision.contacts[0].normal * bounceValue);
    }
        
        protected void TakeDamage()
    {
        health -= damageValue;
    }
    
    protected virtual void ResolveUnitCollision(Collision collision)
    {
        Debug.Log($"{gameObject.name} collision with unit");
    }

    protected virtual void ResolveWallCollision(Collision collision)
    {
        Debug.Log($"{gameObject.name} collision with wall");
    }

    protected virtual void UnitDeath()
    {
        Destroy(gameObject);
    }

}
