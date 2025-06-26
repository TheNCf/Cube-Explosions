using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Exploder))]
public class ChildrenSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _childPrefab;
    [Space(20)]
    [SerializeField, Range(0, 100)] private float _spawnChildrenChance = 100.0f;
    [SerializeField, Min(1)] private int _spawnCountMin = 2;
    [SerializeField, Min(1)] private int _spawnCountMax = 6;

    private Exploder _exploder;
    private float reductionFactor = 2.0f;

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
            GameObject childCube = Instantiate(_childPrefab, transform.position + randomPositionDeviation, Quaternion.identity);

            Rigidbody childCubeRigidbody = childCube.GetComponent<Rigidbody>();
            _exploder.Explode(childCubeRigidbody);

            ChildrenSpawner childController = childCube.GetComponent<ChildrenSpawner>();
            childController.SetChanceAndSize(_spawnChildrenChance / reductionFactor, transform.localScale / reductionFactor);
        }
    }

    public void SetChanceAndSize(float chance, Vector3 size)
    {
        _spawnChildrenChance = chance;
        transform.localScale = size;
    }
}
