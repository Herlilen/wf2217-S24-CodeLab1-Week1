using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    
    [Header("Movement")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float speedCap;
    private Vector3 rotationSpeed;  // v3 for eula rotation
    [SerializeField] private float rotationSpeedY; // the rotation tweaking value for v3
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        // set the v3 value
        rotationSpeed = new Vector3(0, rotationSpeedY, 0);
    }

    private void FixedUpdate()
    {
        // movement control input
        if (Input.GetKey(KeyCode.W)) // move forward
        {
            _rb.AddForce(movementSpeed * Vector3.forward);
        }

        if (Input.GetKey(KeyCode.S)) // move back
        {
            _rb.AddForce(movementSpeed * Vector3.back);
        }
        
        if (Input.GetKey(KeyCode.A)) // move left
        {
            _rb.AddForce(movementSpeed * Vector3.left);
        }
        
        if (Input.GetKey(KeyCode.D)) // move right
        {
            _rb.AddForce(movementSpeed * Vector3.right);
        }
        
        //use normalization and magnitude to maintain maxVelocity or less
        if (_rb.velocity.magnitude > speedCap)
        {
            Vector3 newSpeed = _rb.velocity.normalized;
            newSpeed *= speedCap;
            _rb.velocity = newSpeed;
        }
    }
    
}
