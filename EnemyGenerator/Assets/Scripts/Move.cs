using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Move : MonoBehaviour
{
    [SerializeField] Spawner _spawner;

    private Rigidbody _rigidbody;

    private float _speed = 10f;

    private Vector3 _position;
    private Quaternion _rotation;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _position = _spawner.GetDirectionVector();
        _rotation = _spawner.GetQuaternion();
        transform.rotation = _rotation;
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(transform.position + _position * Time.deltaTime * _speed);

        // _rigidbody.rotation = _rotation;
        // transform.Translate(_position);

    }
}
