using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] protected GameObject iconPref;
    [SerializeField] protected GameObject icon;
    protected float aspectX = 6.643f;
    [SerializeField] protected LevelInfo levelInfo;


    private void Start()
    {
        levelInfo = LevelInfo.levelData;
        aspectX = levelInfo.AspectX;
    }

    void Update()
    {
        if (icon != null)
        {
            icon.transform.localPosition = new Vector2(transform.position.x * aspectX, 0f);
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
