using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ObjectPool _anemyPool;
    private WaitForSeconds _waitForSeconds;

    private float _timeSpawn = 0.4f;
    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(_timeSpawn);
    }

    private void Start()
    {
        StartCoroutine(Counting());
    }

    public void SpawnCubes()
    {
        if (_anemyPool.TryGetObject(out Anemy anemy))
        {
            anemy.transform.position = transform.position;

            anemy.gameObject.SetActive(true);
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
            SpawnCubes();

            yield return _waitForSeconds;
        }
    }
}
