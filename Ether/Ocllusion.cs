using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ocllusion : MonoBehaviour
{
    [SerializeField] private GameObject ether;
    [SerializeField] private Transform parentIcon;

    public Transform ParentIcon { get => parentIcon; set => parentIcon = value; }

    private void Start()
    {
        Ether ether1 = ether.GetComponent<Ether>();
        ether1.SetMiniMapSettings(ParentIcon);
        ether1.ParentEther = gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ether.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ether.SetActive(false);
    }
}
