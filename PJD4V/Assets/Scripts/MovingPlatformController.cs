using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MovingPlatformController : MonoBehaviour
{
    public float moveSpeed;
    public bool useTransform;
    public bool shouldFlip;
    
    [SerializeField] private Vector2 movePosition;
    [SerializeField] private Transform moveDestination;
    
    private Vector2 _initialPosition;

    private Vector2 _moveTarget;
    
    private Vector2 _currentMoveDirection;
    
    private bool _isReturning;

    private float _originalLocalScaleX;
    
    // Start is called before the first frame update
    void Start()
    {
        if (shouldFlip) _originalLocalScaleX = transform.localScale.x;
        
        if (useTransform)
        {
            _moveTarget = moveDestination.localPosition;
        }
        else
        {
            _moveTarget = movePosition;
        }
        _initialPosition = transform.position;
        _currentMoveDirection = (_initialPosition + _moveTarget - (Vector2) transform.position).normalized;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlatform();
    }

    private void MovePlatform()
    {
        if (!_isReturning)
        {
            if (Vector2.Distance(transform.position, _initialPosition + _moveTarget) < 0.1f)
            {
                _isReturning = true;
                _currentMoveDirection = (_initialPosition - (Vector2) transform.position).normalized;
            }
        }
        else
        {
            if (Vector2.Distance(transform.position, _initialPosition) < 0.1f)
            {
                _isReturning = false;
                _currentMoveDirection = (_initialPosition + _moveTarget - (Vector2) transform.position).normalized;
            }
        }

        if (shouldFlip)
        {
            if (_isReturning)
                transform.localScale =
                    new Vector3(-_originalLocalScaleX, transform.localScale.y, transform.localScale.z);
            else
                transform.localScale = new Vector3(_originalLocalScaleX, transform.localScale.y, transform.localScale.z);
        }

        transform.position += (Vector3)_currentMoveDirection * (moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
        }
    }
    
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }

    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            if (useTransform)
            {
                Debug.DrawLine(_initialPosition, (Vector3)_initialPosition + moveDestination.localPosition, Color.yellow);
            }
            else
            {
                Debug.DrawLine(_initialPosition, (Vector3)_initialPosition + (Vector3)movePosition, Color.red);
            }
        }
        else
        {
            if (useTransform)
            {
                Debug.DrawLine(transform.position, transform.position + moveDestination.localPosition, Color.yellow);
            }
            else
            {
                Debug.DrawLine(transform.position, transform.position + (Vector3)movePosition, Color.red);
            }
        }
        
    }
}
