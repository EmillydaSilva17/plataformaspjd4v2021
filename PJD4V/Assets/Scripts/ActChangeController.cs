using System;
using UnityEngine;

public class ActChangeController : MonoBehaviour
{
    public int actNumber;
    
    [SerializeField] private BoxCollider2D boxCollider;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HUDObserverManager.ActChanged(this.actNumber);
            gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        if(actNumber==2) Gizmos.color = Color.cyan;
        else if(actNumber==3) Gizmos.color = Color.magenta;
        Gizmos.DrawCube(transform.position + (Vector3)boxCollider.offset, boxCollider.size);
    }
}
