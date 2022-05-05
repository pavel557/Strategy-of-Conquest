using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class PlayerSkill: MonoBehaviour
{

    [SerializeField] private bool isSpawn = false;
    [SerializeField] private Button skillButton;
    [SerializeField] private int count = 5;
    [SerializeField] private bool isReloading = false;

    public bool IsSpawn
    {
        get => isSpawn;
        set
        {
            isSpawn = value;
            CheckActivity();
        }
    }

    public bool IsReloading
    {
        get => isReloading;
        set
        {
            isReloading = value;
            CheckActivity();
        }
    }

    protected int Count
    {
        get => count;
        set
        {
            count = value;
            CheckActivity();
        }
    }

    protected virtual void CheckActivity()
    {
        if ((Count > 0) && (!isSpawn) && (!isReloading))
        {
            skillButton.interactable = true;
        }
        else
        {
            skillButton.interactable = false;
        }
    }

    public abstract void AddSkill(int isShop);
}
