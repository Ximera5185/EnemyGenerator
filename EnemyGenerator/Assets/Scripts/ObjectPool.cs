using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private List<Enemy> _poolEnemys;
    [SerializeField] private Enemy _enemy;

    private int _amountToPool = 5;

    private void Awake()
    {
        _poolEnemys = new List<Enemy>();

        CreateEnemies();
    }

    public bool TryGetObject(out Enemy enemy)
    {
        for (int i = 0; i < _poolEnemys.Count; i++)
        {
            if (_poolEnemys [i].gameObject.activeSelf == false)
            {
                enemy = _poolEnemys [i];

                return true;
            }
        }

        enemy = null;

        return false;
    }

    public void IncreasePool()
    {
        Enemy enemy = Instantiate(_enemy);

        enemy.gameObject.SetActive(false);

        _poolEnemys.Add(enemy);
    }

    private void CreateEnemies()
    {
        for (int i = 0; i < _amountToPool; i++)
        {
            IncreasePool();
        }
    }
}