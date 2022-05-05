using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShopAccess : MonoBehaviour
{
    [SerializeField] private MenuUIHandler manager;
    [SerializeField] private GameObject joystickRight;
    [SerializeField] private Button healingButton;
    private bool unitPanelIsOpen = false;

    public bool UnitPanelIsOpen { get => unitPanelIsOpen; }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("LandingZone"))
        {
            manager.GetComponent<MenuUIHandler>().ShopButtonSetActive(true);
            unitPanelIsOpen = true;
        }
            
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("LandingZone"))
        {
            manager.GetComponent<MenuUIHandler>().ShopButtonSetActive(false);
            unitPanelIsOpen = false;
        }
    }
}
