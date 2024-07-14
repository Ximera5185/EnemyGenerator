using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ObjectPool _anemyPool;
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

    public Vector3 GetDirectionVector() 
    {
        float vectorX = Random.Range(-1f, 1f);
        float vectorY = 0;
        float vectorZ = 0;

        return new Vector3(vectorX, vectorY,vectorZ);
    }
    public Quaternion  GetQuaternion() 
    {
        return Quaternion.Euler(0, Random.Range(-180f, 180f), 0);
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
