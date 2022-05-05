using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sprint : PlayerSkill
{
    [SerializeField] private int price = 75;
    [SerializeField] private float sprintSpeed = 10;
    [SerializeField] private float workingTime = 15;
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI textCount;
    [SerializeField] private GameObject player;
    private EtherStorage etherStorage;
    private MovementPlayer movementPlayer;
    

    private void Start()
    {
        movementPlayer = player.GetComponent<MovementPlayer>();
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
        float speed = movementPlayer.ChangeSpeed(sprintSpeed);
        yield return new WaitForSeconds(workingTime);
        IsReloading = false;
        movementPlayer.ChangeSpeed(speed);
    }

}
