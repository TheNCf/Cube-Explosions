using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Exploder))]
public class ChildrenSpawner : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private float _spawnChildrenChance = 100.0f;
    [SerializeField, Min(1)] private int _spawnCountMin = 2;
    [SerializeField, Min(1)] private int _spawnCountMax = 6;

    private Exploder _exploder;

    private void Awake()
    {
        _exploder = GetComponent<Exploder>();
    }

    private void OnValidate()
    {
        if (_spawnCountMin > _spawnCountMax)
            _spawnCountMin = _spawnCountMax;
    }

    public void Spawn()
    {
        int minChance = 0;
        int maxChance = 100;
        int randomPercent = Random.Range(minChance, maxChance);

        if (randomPercent >= _spawnChildrenChance)
            return;

        int count = Random.Range(_spawnCountMin, _spawnCountMax + 1);

        for (int i = 0; i < count; i++)
        {
            float deviationFactor = 0.01f;
            Vector3 randomPositionDeviation = new Vector3(Random.Range(-deviationFactor, deviationFactor), 0, Random.Range(-deviationFactor, deviationFactor));
            GameObject childCube = Instantiate(gameObject, transform.position + randomPositionDeviation, Quaternion.identity);

            Rigidbody childCubeRigidbody = childCube.GetComponent<Rigidbody>();
            _exploder.Explode(childCubeRigidbody);

            ChildrenSpawner childController = childCube.GetComponent<ChildrenSpawner>();
            childController.ReduceChanceAndSize();
        }
    }

    public void ReduceChanceAndSize()
    {
        float reductionFactor = 2.0f;
        _spawnChildrenChance /= reductionFactor;
        transform.localScale /= reductionFactor;
    }
}
