using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkills : MonoBehaviour
{
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private Button launchBombButton;
    [SerializeField] private int price=50;
    [SerializeField] private Text textCount;
    private PlayerShopAccess playerShopAccess;
    private EtherStorage etherStorage;
    private int count = 5;
    private bool isWorks = true;

    private void Start()
    {
        playerShopAccess = GetComponent<PlayerShopAccess>();
        etherStorage = GetComponent<EtherStorage>();
    }

    public void LaunchBomb()
    {
        if ((count > 0)&&(isWorks)&&(!playerShopAccess.UnitPanelIsOpen))
        {
            StartCoroutine(Reloading());
            count--;
            textCount.text = count + "";
            Instantiate(bombPrefab, transform.position, Quaternion.identity);
        }
        if(playerShopAccess.UnitPanelIsOpen)
        {
            if (etherStorage.ReduceEther(price))
            {
                count++;
                textCount.text = count + "";
            }
        }
    }

    IEnumerator Reloading()
    {
        isWorks = false;
        launchBombButton.interactable = false;
        yield return new WaitForSeconds(5f);
        launchBombButton.interactable = true;
        isWorks = true;
    }
}
