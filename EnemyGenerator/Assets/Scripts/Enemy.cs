using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Move _move;

    private WaitForSeconds _waitForSeconds;

    private float _lifetime = 5f;

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(_lifetime);
    }

    private void OnEnable()
    {
        StartCoroutine(Counting());
    }

    public void Initialise(float rotation, Vector3 direction)
    {
        _move.Initialise(rotation, direction);
    }

    private IEnumerator Counting()
    {
        yield return _waitForSeconds;

        gameObject.SetActive(false);
    }
}