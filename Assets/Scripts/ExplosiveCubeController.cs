using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent (typeof(ChildrenSpawner))]
public class ExplosiveCubeController : MonoBehaviour
{
    private ChildrenSpawner _childrenSpawner;

    private void Awake()
    {
        _childrenSpawner = GetComponent<ChildrenSpawner>();
    }

    private void OnMouseDown()
    {
        _childrenSpawner.Spawn();
        Destroy(gameObject);
    }
}
