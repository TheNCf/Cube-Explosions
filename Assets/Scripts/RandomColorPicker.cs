using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class RandomColorPicker : MonoBehaviour
{
    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();

        PickRandomColor();
    }

    private void PickRandomColor()
    {
        _meshRenderer.material.color = Color.HSVToRGB(Random.value, Random.value, Random.value);
    }
}
