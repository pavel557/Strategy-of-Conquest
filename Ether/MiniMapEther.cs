using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapEther : MonoBehaviour
{
    [SerializeField] private GameObject icon;
    [SerializeField] private GameObject iconPref;
    [SerializeField] private LevelInfo levelInfo;

    private void OnEnable()
    {
        //aspectX = widthMap / sizeLocX;
        //aspectY = heightMap / sizeLocY;
        //offsetY = 24f * aspectY;
        levelInfo = LevelInfo.levelData;
    }

    public GameObject CreateIcon(Transform parent)
    {
        icon = Instantiate(iconPref, parent);
        icon.transform.localPosition = new Vector2(transform.position.x * levelInfo.MiniAspectX, (transform.position.y * levelInfo.MiniAspectY - levelInfo.MiniOffsetY));
        return icon;
    }
}
