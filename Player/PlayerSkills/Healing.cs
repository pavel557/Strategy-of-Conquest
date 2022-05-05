using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : PlayerSkill
{
    [SerializeField] private int price;
    [SerializeField] private int healthCount;
    private Health health;
    private EtherStorage etherStorage;

    private void Start()
    {
        health = GetComponent<Health>();
        etherStorage = GetComponent<EtherStorage>();
    }

    public void DoHealing()
    {
        if ((etherStorage.Ether >= price) && (health._Health < health.MaxHealth)) 
        {
            health.Healing(healthCount);
            etherStorage.ReduceEther(price);
        }
    }

    public override void AddSkill(int isShop)
    {
        health.Healing(10);
    }

    protected override void CheckActivity()
    {

    }

}
