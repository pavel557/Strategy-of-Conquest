using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IncreasedAttack : PlayerSkill
{
    [SerializeField] private int price = 100;
    [SerializeField] private float increasedReloading = 0.05f;
    [SerializeField] private float workingTime = 6;
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI textCount;
    [SerializeField] private GameObject player;
    private EtherStorage etherStorage;
    [SerializeField] private List<GunPlayer> gunPlayer;

    private void Start()
    {
        etherStorage = player.GetComponent<EtherStorage>();
    }

    public void RunSkill()
    {
        StartCoroutine(Enable());
        Count--;
        textCount.text = Count + "";

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

    IEnumerator Enable()
    {
        IsReloading = true;
        float reloading = 0.2f;
        for (int i=0; i<gunPlayer.Count;i++)
        {
            if (i == 0)
            {
                reloading = gunPlayer[i].Reloading;
            }
            gunPlayer[i].Reloading = increasedReloading;
        }
        yield return new WaitForSeconds(workingTime);

        IsReloading = false;

        for (int i = 0; i < gunPlayer.Count; i++)
        {
            gunPlayer[i].Reloading = reloading;
        }
    }
}
