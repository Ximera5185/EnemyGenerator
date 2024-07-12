using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private List<Anemy> _poolAnemys;

    [SerializeField] private Anemy _anemy;

    private int _amountToPool = 10;

    private void Start()
    {
        _poolAnemys = new List<Anemy>();

        CreatePoolCubes();
    }

    public bool TryGetObject(out Anemy anemy)
    {
        for (int i = 0; i < _poolAnemys.Count; i++)
        {
            if (_poolAnemys [i].gameObject.activeSelf == false)
            {
                anemy = _poolAnemys [i];

                return true;
            }
        }

        anemy = null;

        return false;
    }

    public void IncreasePool()
    {
        Anemy anemy = Instantiate(_anemy);

        anemy.gameObject.SetActive(false);

        _poolAnemys.Add(anemy);
    }

    private void CreatePoolCubes()
    {
        for (int i = 0; i < _amountToPool; i++)
        {
            IncreasePool();
        }
    }
}
