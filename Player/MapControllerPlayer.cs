using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControllerPlayer : MapController
{
    [SerializeField] private RectTransform rectTransformCanvas;


    void Start()
    {
        levelInfo = LevelInfo.levelData;
        if (rectTransformCanvas != null)
            aspectX = levelInfo.AspectX;
    }
}
