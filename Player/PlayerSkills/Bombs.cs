using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bombs : PlayerSkill
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private Button launchBombButton;
    [SerializeField] private TextMeshProUGUI textCount;
    [SerializeField] private EtherStorage etherStorage;
    
    [SerializeField] private int price = 150;

    [SerializeField] private Transform parentIcon;
    [SerializeField] private RectTransform rectTransformCanvas;
    [SerializeField] private bool isSpawner = false;
    
    

    
    

    public void RunSkill()
    {
        StartCoroutine(Reloading());
        Count--;
        textCount.text = Count + "";
        GameObject gameObject = Instantiate(bombPrefab, player.transform.position, Quaternion.identity);
        if (isSpawner)
        {
            SpawnerTurret spawnerTurret = gameObject.GetComponent<SpawnerTurret>();
            spawnerTurret.ParentIcon = parentIcon;
            spawnerTurret.RectTransformCanvas = rectTransformCanvas;
        }
    }

    public override void AddSkill(int isShop)
    {
        if (isShop == 1)
        {
            if (etherStorage.ReduceEther(price))
            {
                CheckActivity();
                Count++;
                textCount.text = Count + "";
            }
        }
        else
        {
            CheckActivity();
            Count++;
            textCount.text = Count + "";
        }
        
    }

    

    IEnumerator Reloading()
    {
        IsReloading = true;
        yield return new WaitForSeconds(5f);
        IsReloading = false;
        CheckActivity();

    }
}
