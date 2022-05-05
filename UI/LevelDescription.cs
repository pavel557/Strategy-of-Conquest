using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelDescription : MonoBehaviour
{
    [SerializeField] private List<Image> levelButton;
    [SerializeField] private List<GameObject> levelDesc;
    private GameObject activeDesc;
    private int index;

    public void LevelDescSetActive(int levelNumber)
    {
        if (activeDesc != null)
        {
            activeDesc.SetActive(false);
            levelButton[index].color = new Color(1f, 1f, 1f, 1f);
        }
        levelDesc[levelNumber - 1].SetActive(true);
        activeDesc = levelDesc[levelNumber - 1];
        levelButton[levelNumber - 1].color = new Color(0.8f, 0.8f, 0.8f, 1f);

        index = levelNumber - 1;
    }

    public void LevelDescSetActiveFalse()
    {
        if (activeDesc != null)
        {
            activeDesc.SetActive(false);
            levelButton[index].color = new Color(1f, 1f, 1f, 1f);
        }
    }

}
