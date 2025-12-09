using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatformController : MonoBehaviour
{
    public float timeToFall;
    public float resetTime;
    
    private Rigidbody2D _rigidbody2D;

    private Vector2 _initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _initialPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
            Invoke("DropPlatform", timeToFall);
        }
    }
    
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }

    private void DropPlatform()
    {
        _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        
        Invoke("ResetPlatform", resetTime);
    }

    private void ResetPlatform()
    {
        _rigidbody2D.bodyType = RigidbodyType2D.Static;
        transform.position = _initialPosition;
    }
    
    
}
