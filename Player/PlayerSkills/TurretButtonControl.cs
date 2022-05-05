using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TurretButtonControl : MonoBehaviour
{
    [SerializeField] private List<PlayerSkill> buttonsTurretSpawn;
    [SerializeField] private Transform playerBase;
    [SerializeField] private Transform enemyBase;
    private float minPositionX;
    private float maxPositionX;
    private bool buttonInteractable = false;
    private PlayerShopAccess playerShopAccess;
    private void Start()
    {
        minPositionX = playerBase.position.x + 6f;
        maxPositionX = enemyBase.position.x - 25f;
        playerShopAccess = GetComponent<PlayerShopAccess>();
    }

    private void Update()
    {
        if ((transform.position.x > minPositionX)&&(transform.position.x < maxPositionX))
        {
            SetButtonsInteractable(true);
        }
        else
        {
            if (playerShopAccess.UnitPanelIsOpen)
            {
                SetButtonsInteractable(true);
            }
            else if (buttonInteractable == true)
            {
                SetButtonsInteractable(false);
            }
        }
    }

    private void SetButtonsInteractable(bool interactable)
    {
        for (int i = 0; i < buttonsTurretSpawn.Count; i++)
        {
        }
        buttonInteractable = interactable;
    }
}
