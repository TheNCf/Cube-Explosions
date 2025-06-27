using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    public void Explode(Vector3 explosionCenter, ExplosiveCube explosiveCube, float explosionForce = 250.0f, float upwardsForce = 25.0f, float explosionRadius = 25.0f)
    {
        if (explosiveCube.TryGetComponent(out Rigidbody rigidbody))
            rigidbody.AddExplosionForce(explosionForce, explosionCenter, explosionRadius, upwardsForce);
    }
}
