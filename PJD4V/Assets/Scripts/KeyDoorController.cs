using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoorController : MonoBehaviour
{

    private bool _isOpen;
    
    public bool UseKey()
    {
        if (_isOpen) return false;
        
        GetComponent<Animator>().Play("Opening");
        GetComponent<AudioSource>().Play();
        GetComponentsInChildren<BoxCollider2D>()[1].enabled = false;
        _isOpen = true;
        return true;

    }
}
