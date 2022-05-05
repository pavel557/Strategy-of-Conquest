using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private Image[] gameObjectsButton;
    [SerializeField] private Button[] buttons;
    private int? levels = 0;

    private void Start()
    {
        
        levels = PlayerPrefs.GetInt("levels");
        Debug.Log(levels);
        if (levels != null)
        {
            for (int i = (int)levels; i > 0; i--)
            {
                if (i != 8)
                {
                    gameObjectsButton[i].color = new Color(1f, 1f, 1f, 1f);
                    buttons[i].interactable = true;
                }
                
            }
        }
        
    }
}
