using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    public event Action<ExplosiveCube> CubeHit;

    private void Start()
    {
        if (_camera == null)
        {
            Debug.LogError($"Field \"{_camera.GetType().Name}\" must be assigned in {typeof(InputReader).Name} component!");
            enabled = false;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                if (raycastHit.collider.TryGetComponent(out ExplosiveCube explosiveCube))
                {
                    CubeHit?.Invoke(explosiveCube);
                }
            }
        }
    }
}
