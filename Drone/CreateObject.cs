using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Название класса не информативно
 * 
 * The class name is not informative
 */

public class CreateObject : MonoBehaviour
{
    [SerializeField] private SpawnerEther spawnerEther;
    [SerializeField] private int countEther;

    public SpawnerEther SpawnerEther { get => spawnerEther; set => spawnerEther = value; }

    public void InstantiateObject()
    {
        if (spawnerEther != null)
        {
            SpawnerEther.SpawnInCirlceLocation(gameObject.transform, countEther);
        }
    }

    public void CreateEther()
    {
        if (spawnerEther != null)
        {
            SpawnerEther.SpawnInSpecificLocation(gameObject.transform, countEther);
        }
    }
}
