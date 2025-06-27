using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private ExplosiveCube _cubePrefab;
    [Space(20)]

    [SerializeField, Min(1)] private int _spawnCountMin = 2;
    [SerializeField, Min(1)] private int _spawnCountMax = 6;

    private float reductionFactor = 2.0f;

    private void OnValidate()
    {
        if (_spawnCountMin > _spawnCountMax)
            _spawnCountMin = _spawnCountMax;
    }

    public List<ExplosiveCube> Spawn(ExplosiveCube explosiveCube)
    {
        Destroy(explosiveCube.gameObject);

        int minChance = 0;
        int maxChance = 100;
        int randomPercent = Random.Range(minChance, maxChance);

        if (randomPercent >= explosiveCube.SpawnChildrenChance)
            return null;

        List<ExplosiveCube> spawnedCubes = new List<ExplosiveCube>();

        int count = Random.Range(_spawnCountMin, _spawnCountMax + 1);

        for (int i = 0; i < count; i++)
        {
            float deviationFactor = 0.01f;
            Vector3 randomPositionDeviation = new Vector3(Random.Range(-deviationFactor, deviationFactor), 0, Random.Range(-deviationFactor, deviationFactor));

            ExplosiveCube childCube = Instantiate(_cubePrefab, explosiveCube.transform.position + randomPositionDeviation, Quaternion.identity);
            childCube.SetChanceAndSize(explosiveCube.SpawnChildrenChance / reductionFactor, explosiveCube.transform.localScale / reductionFactor);
            spawnedCubes.Add(childCube);
        }

        return spawnedCubes;
    }
}
