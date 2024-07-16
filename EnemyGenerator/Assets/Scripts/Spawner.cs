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

    public Vector3 GetDirectionVector()
    {
        return Vector3.right;
    }

    public float GetRotation()
    {
        float minValueRotation = -180f;
        float maxValueRotation = 180f;

        return Random.Range(minValueRotation, maxValueRotation);
    }

    private void SpawnEnemies()
    {
        int index = Random.Range(0, _spawnPoints.Count);

        if (_anemyPool.TryGetObject(out Enemy enemy))
        {
            enemy.transform.position = _spawnPoints [index].position;

            enemy.gameObject.SetActive(true);

            enemy.Initialise(GetRotation(), GetDirectionVector());
        }
        else
        {
            _anemyPool.IncreasePool();
        }
    }

    private IEnumerator Counting()
    {
        while (enabled)
        {
            SpawnEnemies();

            yield return _waitForSeconds;
        }
    }
}