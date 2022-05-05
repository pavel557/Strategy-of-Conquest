using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ether : MonoBehaviour
{
    [SerializeField] private int ether;
    [SerializeField] private LayerMask layerPlayer;
    //[SerializeField] private LayerMask layerScaner;
    [SerializeField] private LayerMask layerEther;
    [SerializeField] private Transform parentIcon;
    [SerializeField] private MiniMapEther miniMapEther;
    [SerializeField] private EtherStorage etherStorage;
    private GameObject icon;
    private GameObject parentEther;

    public int EtherCount { get => ether;}
    public GameObject ParentEther { get => parentEther; set => parentEther = value; }
    public EtherStorage EtherStorage { get => etherStorage; set => etherStorage = value; }

    private void Start()
    {
        if (icon == null)
        {
            icon = miniMapEther.CreateIcon(parentIcon);
        }
    }

    public void SetMiniMapSettings(Transform _parentIcon)
    {
        parentIcon = _parentIcon;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((layerPlayer.value & (1 << collision.gameObject.layer)) != 0)
        {
            EtherStorage.AddEther(EtherCount);
            Destroy(icon);
            Destroy(parentEther);

        }
        if ((layerEther.value & (1 << collision.gameObject.layer)) != 0)
        {
            Destroy(icon);
            Destroy(parentEther);
        }
    }
}
