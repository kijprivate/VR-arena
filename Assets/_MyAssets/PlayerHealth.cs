using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : HealthManager
{
    public float health = 100f;

    public override void TakeDamage(Vector3 location, Vector3 direction, float damage, Collider bodyPart, GameObject origin)
    {
        health -= damage;

        if (health <= 0f)
            Debug.LogError("DEAD");
    }
}
