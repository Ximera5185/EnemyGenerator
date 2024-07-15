using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Move : MonoBehaviour
{
    private float _rotationY;
    private Vector3 _direction;
    private float _speed = 1f;

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    public void Initialise(float rotation,Vector3 direction) 
    {
        _rotationY = rotation;

        _direction = direction;

        transform.rotation = Quaternion.Euler(0,rotation,0);

       // transform.Rotate(0, _rotationY, 0);
    }
}
