using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * - Скрипт одновременно овечает и за логику проигрыша и за логику в случае уничтожении дрона
 *
 * - The script is simultaneously responsible for the logic of losing and for the logic in case of drone destruction
 */
public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject panelDrone;
    [SerializeField] private GameObject player;
    [SerializeField] private Health health;
    [SerializeField] private EtherStorage etherStorage;
    [SerializeField] private Vector3 spawnPos;
    [SerializeField] private List<GunPlayer> gunsPlayer;
    [SerializeField] private GameObject expl;
    [SerializeField] private int coast = 1000;
    public void Losing()
    {
        Time.timeScale = 0;
        panel.SetActive(true);
    }

    public void DroneDestroy()
    {
        Instantiate(expl, transform.position, Quaternion.identity);
        player.SetActive(false);
        panelDrone.SetActive(true);
    }

    public void DroneCreate()
    {
        player.transform.position = spawnPos;
        player.SetActive(true);
        panelDrone.SetActive(false);
        health.Healing(health.MaxHealth);
        etherStorage.Ether -= coast;
        foreach (GunPlayer gunPlayer in gunsPlayer)
        {
            gunPlayer.StartFire();
        }
    }

    public void LevelComplete(int number)
    {
        int? l = PlayerPrefs.GetInt("levels");
        if (l != null)
        {
            if (number < (int)l)
            {
                return;
            }
        }
        PlayerPrefs.SetInt("levels", number);

    }
}
