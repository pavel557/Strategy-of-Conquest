using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
 * Бизнес логику и интерфейс лучше разделять
 * 
 * It is better to separate business logic and interface
 */

public class Collector : MonoBehaviour
{
    [SerializeField] private int ether;
    [SerializeField] private int maxEther;
    [SerializeField] private int increaseEther;
    [SerializeField] private float period;
    [SerializeField] private float coefParticleSize;
    [SerializeField] private TextMeshProUGUI textCount;
    [SerializeField] private EtherStorage etherStorage;
    [SerializeField] private ParticleSystem particleSystem;

    public EtherStorage EtherStorage { get => etherStorage; set => etherStorage = value; }

    void Start()
    {
        StartCoroutine(AddEther());
    }

    public void OnButtonAddEtherEnter()
    {
        EtherStorage.AddEther(ether);
        ether = 0;
        textCount.text = ether + " / " + maxEther;
        particleSystem.startSize = ether * 0.005f;
    }

    IEnumerator AddEther()
    {
        while (true)
        {
            if (ether < maxEther)
            {
                ether += increaseEther;
                if (ether > maxEther)
                {
                    ether = maxEther;
                }
                textCount.text = ether + " / " + maxEther;
                particleSystem.startSize = ether *coefParticleSize;
            }
            yield return new WaitForSeconds(period);
        }
    }
}
