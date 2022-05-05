using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyUnitPro : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyUnitPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform parentIcon;
    [SerializeField] private RectTransform rectTransformCanvas;
    [SerializeField] private Trigger trigger;
    [SerializeField] private SpawnerEther spawnerEther;

    [Space]
    [Header("timeBeforeStart")]
    [SerializeField] private float minTimeBeforeStart;
    [SerializeField] private float maxTimeBeforeStart;

    [Space]
    [Header("smallPeriodsOfTime")]
    [SerializeField] private float minSmallPeriodsOfTime;
    [SerializeField] private float maxSmallPeriodsOfTime;

    [Space]
    [Header("longPeriodsOfTime")]
    [SerializeField] private float minLongPeriodsOfTime;
    [SerializeField] private float maxLongPeriodsOfTime;

    [Space]
    [Header("longPeriodsOfTime")]
    [SerializeField] private int minNumberOfUnits;
    [SerializeField] private int maxNumberOfUnits;

    [Space]
    [Header("periodOfIncreasingDifficulty")]
    [SerializeField] private int minPeriodOfIncreasingDifficulty;
    [SerializeField] private int maxPeriodOfIncreasingDifficulty;

    private void Start()
    {
        StartCoroutine(StartSpawn());
    }

    IEnumerator IncreasingDifficulty()
    {
        yield return new WaitForSeconds(GetRandomFloat(minPeriodOfIncreasingDifficulty, maxPeriodOfIncreasingDifficulty));
        minNumberOfUnits++;
        maxNumberOfUnits++;
    }

    private float GetRandomFloat(float min, float max)
    {
        return Random.Range(min, max);
    }

    IEnumerator StartSpawn()
    {
        yield return new WaitForSeconds(GetRandomFloat(minTimeBeforeStart, maxTimeBeforeStart));
        StartCoroutine(LongTime());
        StartCoroutine(IncreasingDifficulty());
    }

    IEnumerator LongTime()
    {
        yield return new WaitForSeconds(GetRandomFloat(minLongPeriodsOfTime, maxLongPeriodsOfTime));
        StartCoroutine(SmallTime());
    }

    IEnumerator SmallTime()
    {
        int count = Random.Range(minNumberOfUnits, maxNumberOfUnits);
        while (count > 0)
        {
            count--;
            int enemyIndex = Random.Range(0, enemyUnitPrefab.Count);
            if (trigger.IsActive == false)
            {

                GameObject gameObject = Instantiate(enemyUnitPrefab[enemyIndex], spawnPoint.position, Quaternion.identity);
                gameObject.GetComponent<MapController>().CreateIcon(parentIcon, rectTransformCanvas);
                gameObject.GetComponent<CreateObject>().SpawnerEther = spawnerEther;
            }
            yield return new WaitForSeconds(GetRandomFloat(minSmallPeriodsOfTime, maxSmallPeriodsOfTime));
        }
        StartCoroutine(LongTime());
    }
}
