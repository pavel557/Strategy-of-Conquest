using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitData", menuName = "ScriptableObjects/UnitData", order = 1)]
public class UnitData : ScriptableObject
{
    public GameObject unitPrefab;
    public float timeCreation;
    public GameObject buttonPrefab;
    public int price;
}
