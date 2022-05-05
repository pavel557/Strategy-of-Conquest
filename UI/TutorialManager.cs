using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject[] lists;
    private GameObject listActive;
    private int index;

    private void Start()
    {
        listActive = lists[0];
        index = 0;
    }

    public void OnButtonNextEnter()
    {
        if (lists.Length - 1 == index)
        {
            listActive.SetActive(false);
            return;
        }
        listActive.SetActive(false);
        index++;
        listActive = lists[index];
        listActive.SetActive(true);
    }

    public void OnButtonBackEnter()
    {
        if (index == 0)
        {
            return;
        }
        listActive.SetActive(false);
        index--;
        listActive = lists[index];
        listActive.SetActive(true);
    }

    public void CloseTutorial()
    {
        panel.SetActive(false);
    }
}
