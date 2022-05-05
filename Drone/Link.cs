using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link : MonoBehaviour
{
    [SerializeField] private GameObject objectLink;
    [SerializeField] private Transform parentIcon;
    [SerializeField] private GameObject pointer;

    public GameObject ObjectLink { get => objectLink; set => objectLink = value; }
    public Transform ParentIcon { get => parentIcon; set => parentIcon = value; }
    public GameObject Pointer { get => pointer; set => pointer = value; }

    public void OnEnable()
    {
        if (objectLink == null)
        {
            objectLink = GameObject.Find("Player");
        }
    }
}
