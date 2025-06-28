using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ExplosiveCube : MonoBehaviour
{
    [field: SerializeField, Range(0, 100)] public float SpawnChildrenChance { get; private set; } = 100.0f;
    [field: SerializeField] public float ExplosionRadius { get; private set; } = 5.0f;
    [field: SerializeField] public float ExplosionForce { get; private set; } = 200.0f;
    [field: SerializeField] public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    public void Initialize(float chance, Vector3 size, float explosionRadius, float explosionForce)
    {
        SpawnChildrenChance = chance;
        transform.localScale = size;
        ExplosionRadius = explosionRadius;
        ExplosionForce = explosionForce;
    }
}
