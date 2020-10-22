using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class ProjectileBazooka : Projectile
{
    [SerializeField] private float explosionRadius;

    Vector3 hitPosition;
    public override void OnCollisionEvent(Collision collision)
    {
        // Ignore Triggers
        if (collision.collider.isTrigger)
        {
            return;
        }

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb && MinForceHit != 0)
        {
            float zVel = System.Math.Abs(transform.InverseTransformDirection(rb.velocity).z);

            // Minimum Force not achieved
            if (zVel < MinForceHit)
            {
                return;
            }
        }

        hitPosition = collision.contacts[0].point;
        Vector3 normal = collision.contacts[0].normal;
        Quaternion hitNormal = Quaternion.FromToRotation(Vector3.forward, normal);

        // FX - Particles, Decals, etc.
        DoHitFX(hitPosition, hitNormal, collision.collider);

        var col = Physics.OverlapSphere(hitPosition, explosionRadius);
        foreach(var c in col)
        {
            // Damage if possible
            Damageable d = c.GetComponent<Damageable>();
            if (d)
            {
                d.DealDamage(Damage);

                if (onDealtDamageEvent != null)
                {
                    onDealtDamageEvent.Invoke();
                }
            }

            c.SendMessageUpwards("HitCallback", new HealthManager.DamageInfo(c.transform.position, (c.transform.position - hitPosition).normalized, 200f, c), SendMessageOptions.DontRequireReceiver);
        }

        if (StickToObject)
        {
            // tryStickToObject
        }
        else
        {
            // Done with this projectile
            Destroy(this.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(hitPosition, explosionRadius);
    }
}
