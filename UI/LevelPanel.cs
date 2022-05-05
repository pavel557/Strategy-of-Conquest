using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPanel : MonoBehaviour
{
    [SerializeField] private GameObject levelPanel;

    public void LevelPanelSetActiveTrue()
    {
        levelPanel.SetActive(true);
    }

    public void LevelPanelSetActiveFalse()
    {
        levelPanel.SetActive(false);
    }
}
