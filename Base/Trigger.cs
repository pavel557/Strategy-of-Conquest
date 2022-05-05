using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private bool isActive = false;
    [SerializeField] private LayerMask layerMask;

    public bool IsActive { get => isActive; set => isActive = value; }
    public LayerMask LayerMask { get => layerMask; set => layerMask = value; }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if ((layerMask.value & (1 << collision.gameObject.layer)) != 0)
        {
            isActive = true;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    { 
        if ((layerMask.value & (1 << collision.gameObject.layer)) != 0)
        {
            isActive = true;
        }
        else
        {
            isActive = false;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if ((layerMask.value & (1 << collision.gameObject.layer)) != 0)
        {
            isActive = false;
        }
    }
}
