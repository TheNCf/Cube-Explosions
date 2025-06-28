using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private ExplosiveCube _cubePrefab;
    [Space(20)]

    [SerializeField, Min(1)] private int _spawnCountMin = 2;
    [SerializeField, Min(1)] private int _spawnCountMax = 6;

    private float changeFactor = 2.0f;

    private void OnValidate()
    {
        if (_spawnCountMin > _spawnCountMax)
            _spawnCountMin = _spawnCountMax;
    }

    public List<ExplosiveCube> Spawn(ExplosiveCube explosiveCube)
    {
        List<ExplosiveCube> spawnedCubes = new List<ExplosiveCube>();

        int count = Random.Range(_spawnCountMin, _spawnCountMax + 1);

        for (int i = 0; i < count; i++)
        {
            float deviationFactor = 0.01f;
            Vector3 randomPositionDeviation = new Vector3(Random.Range(-deviationFactor, deviationFactor), 0, Random.Range(-deviationFactor, deviationFactor));

            ExplosiveCube childCube = Instantiate(_cubePrefab, explosiveCube.transform.position + randomPositionDeviation, Quaternion.identity);

            float chance = explosiveCube.SpawnChildrenChance / changeFactor;
            Vector3 scale = explosiveCube.transform.localScale / changeFactor;
            float explosionRadius = explosiveCube.ExplosionRadius * changeFactor;
            float explosionForce = explosiveCube.ExplosionForce * changeFactor;
            childCube.Initialize(chance, scale, explosionRadius, explosionForce);

            spawnedCubes.Add(childCube);
        }

        return spawnedCubes;
    }
}
