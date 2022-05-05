using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundHandler : MonoBehaviour
{
    [SerializeField] private AudioMixer masterMixer;
    public float musicVolume;
    public float soundVolume;

    public static SoundHandler Instance;

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    public void SetMusic(float musicLevel)
    {
        musicVolume = musicLevel;
        masterMixer.SetFloat("MusicVolume", musicVolume);
    }

    public void SetSound(float soundLevel)
    {
        soundVolume = soundLevel;
        masterMixer.SetFloat("SoundVolume", soundVolume);
    }
}
