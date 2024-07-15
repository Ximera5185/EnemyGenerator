using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ObjectPool _anemyPool;
    [SerializeField] private List<Transform> _spawnPoints;
    private WaitForSeconds _waitForSeconds;

    private float _timeSpawn = 2f;

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(_timeSpawn);
    }

    private void Start()
    {
        StartCoroutine(Counting());
    }

    private void SpawnCubes()
    {
        int index = Random.Range(0, _spawnPoints.Count);

        if (_anemyPool.TryGetObject(out Anemy anemy))
        {
            anemy.transform.position = _spawnPoints [index].position;

            anemy.gameObject.SetActive(true);

            anemy.Initialise(GetRotation(),GetDirectionVector());
        }
        else
        {
            _anemyPool.IncreasePool();
        }
    }

    public Vector3 GetDirectionVector()
    {
        return Vector3.right;
    }

    public float  GetRotation() 
    {
        return  Random.Range(-180, 180);
    }

    private IEnumerator Counting()
    {
        while (enabled)
        {
            SpawnCubes();

            yield return _waitForSeconds;
        }
    }
}
