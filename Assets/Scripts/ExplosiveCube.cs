using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveCube : MonoBehaviour
{
    [field: SerializeField, Range(0, 100)] public float SpawnChildrenChance { get; private set; } = 100.0f;
    [field: SerializeField] public float ExplosionRadius { get; private set; } = 5.0f;
    [field: SerializeField] public float ExplosionForce { get; private set; } = 200.0f;

    public void SetChanceAndSize(float chance, Vector3 size)
    {
        SpawnChildrenChance = chance;
        transform.localScale = size;
    }

    public void SetExplosionRadiusAndForce(float explosionRadius, float explosionForce)
    {
        ExplosionRadius = explosionRadius;
        ExplosionForce = explosionForce;
    }
}
