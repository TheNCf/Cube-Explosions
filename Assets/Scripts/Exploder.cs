using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    public void Explode(Vector3 explosionCenter, ExplosiveCube explosiveCube, float explosionForce = 250.0f, float upwardsForce = 25.0f, float explosionRadius = 25.0f)
    {
        explosiveCube.Rigidbody.AddExplosionForce(explosionForce, explosionCenter, explosionRadius, upwardsForce);
    }

    public void ExplodeAround(ExplosiveCube explosiveCube)
    {
        Collider[] contacts = Physics.OverlapSphere(explosiveCube.transform.position, explosiveCube.ExplosionRadius);

        foreach (Collider contact in contacts)
            if (contact.TryGetComponent(out ExplosiveCube cube))
                Explode(explosiveCube.transform.position, cube, explosiveCube.ExplosionForce, explosionRadius: explosiveCube.ExplosionRadius);
    }
}
