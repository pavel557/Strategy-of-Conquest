using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo : MonoBehaviour
{
    [SerializeField] private float miniAspectX;
    [SerializeField] private float miniAspectY;
    [SerializeField] private float miniOffsetY;
    [SerializeField] private float aspectX;
    public static LevelInfo levelData;

    public float MiniAspectX { get => miniAspectX;}
    public float MiniAspectY { get => miniAspectY;}
    public float MiniOffsetY { get => miniOffsetY;}
    public float AspectX { get => aspectX;}

    private void OnEnable()
    {
        levelData = this;
    }
}
