using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 3.0f;
    [SerializeField] private float _upwardsForce = 3.0f;
    [SerializeField] private float _explosionRadius = 3.0f;

    public void Explode(Rigidbody bodyToApply)
    {
        bodyToApply.AddExplosionForce(_explosionForce, transform.position, _explosionRadius, _upwardsForce);
    }
}
