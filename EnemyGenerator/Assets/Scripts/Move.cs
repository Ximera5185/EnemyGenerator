using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
       // rigidbody.AddForce(5*Time.deltaTime,0,0,ForceMode.Acceleration);
        rigidbody.MovePosition(transform.position+Vector3.right*0.1f);
    }
}
