using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class ExplosiveCubeController : MonoBehaviour
{
    [SerializeField] private GameObject _childPrefab;
    [SerializeField] private float _explosionForce = 3.0f;
    [SerializeField] private float _upwardsForce = 3.0f;
    [SerializeField] private float _explosionRadius = 3.0f;
    [SerializeField, Range(0, 100)] private float _spawnChildrenChance = 100.0f;
    [SerializeField, Min(1)] private int _spawnCountMin = 2;
    [SerializeField, Min(1)] private int _spawnCountMax = 6;

    private MeshRenderer _meshRenderer;

    public void ReduceChanceAndSize()
    {
        float reductionFactor = 2.0f;
        _spawnChildrenChance /= reductionFactor;
        transform.localScale /= reductionFactor;
    }

    private void OnValidate()
    {
        if (_spawnCountMin > _spawnCountMax)
            _spawnCountMin = _spawnCountMax;
    }

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();

        PickRandomColor();
    }

    private void OnMouseDown()
    {
        int minChance = 0;
        int maxChance = 100;
        int randomPercent = Random.Range(minChance, maxChance);

        if (randomPercent < _spawnChildrenChance)
            SpawnChildren();

        Destroy(gameObject);
    }

    private void PickRandomColor()
    {
        _meshRenderer.material.color = Color.HSVToRGB(Random.value, Random.value, Random.value);
    }

    private void SpawnChildren()
    {
        int count = Random.Range(_spawnCountMin, _spawnCountMax + 1);

        for (int i = 0; i < count; i++)
        {
            float deviationFactor = 0.01f;
            Vector3 randomPositionDeviation = new Vector3(Random.Range(-deviationFactor, deviationFactor), 0, Random.Range(-deviationFactor, deviationFactor));
            GameObject childCube = Instantiate(gameObject, transform.position + randomPositionDeviation, Quaternion.identity);

            Rigidbody childCubeRigidbody = childCube.GetComponent<Rigidbody>();
            childCubeRigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius, _upwardsForce);

            ExplosiveCubeController childController = childCube.GetComponent<ExplosiveCubeController>();
            childController.ReduceChanceAndSize();
        }
    }
}
