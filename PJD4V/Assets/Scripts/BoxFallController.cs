using System;
using UnityEngine;

public class BoxFallController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        GetComponent<AudioSource>().Play();
    }
}
