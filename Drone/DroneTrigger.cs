using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneTrigger : MonoBehaviour
{

    [SerializeField] private Link link;
    [SerializeField] private GunDrone gun;
    [SerializeField] private GameObject pointer;

    void Start()
    {
        pointer = link.Pointer;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gun != null)
        {
            gun.PlayerIsFound = true;
        }
        
        if (pointer != null)
        {
            pointer.SetActive(true);
        }    
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gun != null)
        {
            gun.PlayerIsFound = false;
        }
        if (pointer != null)
        {
            pointer.SetActive(false);
        }
    }
}
