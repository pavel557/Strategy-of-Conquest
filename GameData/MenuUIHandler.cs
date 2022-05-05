using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(1000)]

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject menuBlock;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundSlider;
    [SerializeField] private Animator slidingPanel;
    [SerializeField] private GameObject shopButton;
    [SerializeField] private PlayerSkill[] playerSkills;
    [SerializeField] private FixedJoystick[] fixedJoysticks;
    [SerializeField] private Animator animator;
    [SerializeField] private bool SettingsFlag = false;

    private AsyncOperation asyncOperation;

    public void Start()
    {
        Time.timeScale = 1;

        if (SoundHandler.Instance != null)
        {
            if (musicSlider != null)
            {
                musicSlider.value = SoundHandler.Instance.musicVolume;
                musicSlider.onValueChanged.AddListener(delegate { SoundHandler.Instance.SetMusic(musicSlider.value); }); // Программно добавляет к событию слайдера метод SetMusic
            }

            if (soundSlider != null)
            {
                soundSlider.value = SoundHandler.Instance.soundVolume;
                soundSlider.onValueChanged.AddListener(delegate { SoundHandler.Instance.SetSound(soundSlider.value); }); // Программно добавляет к событию слайдера метод SetMusic
            }
        }
    }

    public void OpenGame()
    {
        menuBlock.SetActive(true);
        asyncOperation = SceneManager.LoadSceneAsync(1);
        //SceneManager.LoadScene(1);
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void SwitchSettings()
    {

        if (SettingsFlag == true)
        {
            settingsMenu.SetActive(false);
            Time.timeScale = 1;
            SettingsFlag = false;
            
        }
        else if ((SettingsFlag == false))
        {
            settingsMenu.SetActive(true);
            Time.timeScale = 0;
            SettingsFlag = true;
        }
        
    }

    

    public void ActiveSettingsPanelAnim()
    {
        settingsMenu.SetActive(true);
    }

    public void DeactiveSettingsPanelAnim()
    {
        settingsMenu.SetActive(false);
    }

    public void ShopButtonSetActive(bool isActive)
    {
        shopButton.SetActive(isActive);
    }



    public void OpenUnitPanel()
    {
        shopButton.SetActive(false);
        foreach (PlayerSkill playerSkill in playerSkills)
        {
            playerSkill.IsSpawn = true;
        }
        foreach (FixedJoystick fixedJoystick in fixedJoysticks)
        {
            fixedJoystick.enabled = false;
        }
        slidingPanel.SetBool("mapUp", true);
        
    }

    public void CloseUnitPanel()
    {
        slidingPanel.SetBool("mapUp", false);
        foreach (PlayerSkill playerSkill in playerSkills)
        {
            playerSkill.IsSpawn = false;
        }
        foreach (FixedJoystick fixedJoystick in fixedJoysticks)
        {
            fixedJoystick.enabled = true;
        }
        ShopButtonSetActive(true);
        
    }

}
