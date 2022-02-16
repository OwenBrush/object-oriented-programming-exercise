using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected float bounceValue;
    [SerializeField] protected float damageValue;
    [SerializeField] protected float speed;
    [SerializeField] protected float m_health;
    [SerializeField] protected float health
    {
        get { return m_health; }
        set
        {
            if (value <= 0f)
            {
                UnitDeath();
            }
            else
            {
                m_health = value;
            }
        }
    }
    private void Awake()
    {
        Debug.Log(health);
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
        rb.velocity *= bounceValue;
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
