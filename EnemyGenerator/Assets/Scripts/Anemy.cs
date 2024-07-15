using System.Collections;
using UnityEngine;

public class Anemy : MonoBehaviour
{
    private WaitForSeconds _waitForSeconds;

    private float _lifetime = 5f;

    [SerializeField] private Move _move;
    
    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(_lifetime);
    }

    private void Start()
    {
        StartCoroutine(Counting());
    }

    private IEnumerator Counting()
    {
        yield return _waitForSeconds;

        gameObject.SetActive(false);
    }

    public void Initialise(float rotation,Vector3 direction) 
    {
        _move.Initialise(rotation,direction);
    }
}
