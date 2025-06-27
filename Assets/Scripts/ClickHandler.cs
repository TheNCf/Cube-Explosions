using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private Exploder _exploder;

    private void Awake()
    {
        if (_inputReader == null)
        {
            Debug.LogError($"Field \"{_inputReader.GetType().Name}\" must be assigned in {typeof(ClickHandler).Name} component!");
            enabled = false;
            return;
        }
        else if (_cubeSpawner == null)
        {
            Debug.LogError($"Field \"{_cubeSpawner.GetType().Name}\" must be assigned in {typeof(ClickHandler).Name} component!");
            enabled = false;
            return;
        }
        else if (_exploder == null)
        {
            Debug.LogError($"Field \"{_exploder.GetType().Name}\" must be assigned in {typeof(ClickHandler).Name} component!");
            enabled = false;
            return;
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
            return;

        List<ExplosiveCube> spawnedCubes = _cubeSpawner.Spawn(explosiveCube);

        if (spawnedCubes != null)
            foreach (var cube in spawnedCubes)
                _exploder.Explode(explosiveCube.transform.position, cube);
    }
}
