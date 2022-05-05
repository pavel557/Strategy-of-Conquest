using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    [SerializeField] private GameObject icon;
    [SerializeField] private GameObject iconPref;
    [SerializeField] private LevelInfo levelInfo;

    private void Start()
    {
        //aspectX = widthMap / sizeLocX;
        //aspectY = heightMap / sizeLocY;
        //offsetY = 24f * aspectY;
        levelInfo = LevelInfo.levelData;
    }

    void Update()
    {
        if (icon != null)
        {
            icon.transform.localPosition = new Vector2(transform.position.x * levelInfo.MiniAspectX, (transform.position.y * levelInfo.MiniAspectY - levelInfo.MiniOffsetY));
        }
    }

    public void CreateIcon(Transform parent, RectTransform rectTransformCanvas)
    {
        icon = Instantiate(iconPref, parent);

    }

    public void DestroyIcon()
    {
        if (icon != null)
        {
            Destroy(icon);
        }
    }
}
