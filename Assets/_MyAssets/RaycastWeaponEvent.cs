using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class RaycastWeaponEvent : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<RaycastWeapon>().onRaycastHitEvent.AddListener(OnRaycastHit);
    }

    private void OnRaycastHit(RaycastHit hit)
    {
        if (hit.collider)
            hit.collider.SendMessageUpwards("HitCallback", new HealthManager.DamageInfo(hit.point, GetComponent<RaycastWeapon>().MuzzlePointTransform.forward, 20f, hit.collider), SendMessageOptions.DontRequireReceiver);
    }
}
