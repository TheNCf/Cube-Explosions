using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 3.0f;
    [SerializeField] private float _upwardsForce = 3.0f;
    [SerializeField] private float _explosionRadius = 3.0f;

    public void Explode(Vector3 explosionCenter, ExplosiveCube explosiveCube)
    {
        if (explosiveCube.TryGetComponent(out Rigidbody rigidbody))
            rigidbody.AddExplosionForce(_explosionForce, explosionCenter, _explosionRadius, _upwardsForce);
    }
}
