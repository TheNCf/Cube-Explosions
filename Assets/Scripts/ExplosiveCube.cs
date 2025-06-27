using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveCube : MonoBehaviour
{
    [field: SerializeField, Range(0, 100)] public float SpawnChildrenChance { get; private set; } = 100.0f;

    public void SetChanceAndSize(float chance, Vector3 size)
    {
        SpawnChildrenChance = chance;
        transform.localScale = size;
    }
}
