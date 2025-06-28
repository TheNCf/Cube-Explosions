using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private Exploder _exploder;

    private void OnValidate()
    {
        if (_inputReader == null)
        {
            Debug.LogWarning($"Field \"{_inputReader.GetType().Name}\" must be assigned in {typeof(ClickHandler).Name} component!");
        }
        else if (_cubeSpawner == null)
        {
            Debug.LogWarning($"Field \"{_cubeSpawner.GetType().Name}\" must be assigned in {typeof(ClickHandler).Name} component!");
        }
        else if (_exploder == null)
        {
            Debug.LogWarning($"Field \"{_exploder.GetType().Name}\" must be assigned in {typeof(ClickHandler).Name} component!");
        }
    }

    private void OnEnable()
    {
        _inputReader.CubeHit += OnCubeClick;
    }

    private void OnDisable()
    {
        _inputReader.CubeHit -= OnCubeClick;
    }

    private void OnCubeClick(ExplosiveCube explosiveCube)
    {
        Destroy(explosiveCube.gameObject);

        int minChance = 0;
        int maxChance = 100;
        int randomPercent = Random.Range(minChance, maxChance);

        if (randomPercent >= explosiveCube.SpawnChildrenChance)
        {
            _exploder.ExplodeAround(explosiveCube);
        }
        else
        {
            List<ExplosiveCube> spawnedCubes = _cubeSpawner.Spawn(explosiveCube);

            foreach (var cube in spawnedCubes)
                _exploder.Explode(explosiveCube.transform.position, cube);

        }
    }
}
