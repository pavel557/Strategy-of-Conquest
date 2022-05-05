using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapDrone : MonoBehaviour
{
    [SerializeField] private GameObject icon;
    [SerializeField] private GameObject iconPref;
    [SerializeField] private Transform parentIcon;
    [SerializeField] private Link link;
    [SerializeField] private LayerMask layerScaner;
    [SerializeField] private LevelInfo levelInfo;

    private void Start()
    {
        //aspectX = widthMap / sizeLocX;
        //aspectY = heightMap / sizeLocY;
        // offsetY = 24f * aspectY;
        levelInfo = LevelInfo.levelData;
        parentIcon = link.ParentIcon;
        
    }

    public GameObject CreateIcon()
    {
        icon = Instantiate(iconPref, parentIcon);
        icon.transform.localPosition = new Vector2(transform.position.x * levelInfo.MiniAspectX, (transform.position.y * levelInfo.MiniAspectY - levelInfo.MiniOffsetY));
        return icon;
    }

    public void DestroyIcon()
    {
        Destroy(icon);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((layerScaner.value & (1 << collision.gameObject.layer)) != 0)
        {
            if (icon == null)
            {
                icon = CreateIcon();
            }
        }
    }


}
