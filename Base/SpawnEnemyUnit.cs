using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Устаревшая версия спавнера вражеских юнитов
 *
 * An outdated version of the enemy unit spawner
*/
public class SpawnEnemyUnit : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyUnitPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform parentIcon;
    [SerializeField] private RectTransform rectTransformCanvas;
    [SerializeField] private Trigger trigger;
    [SerializeField] private SpawnerEther spawnerEther;
    [SerializeField] private int minTimeReload;
    [SerializeField] private int maxTimeReload;

    private bool isReload = false;

    private void Start()
    {
        CreateUnit();
    }

    private void CreateUnit()
    {
        StartCoroutine(SpawnEnemy());
    }

    public void SpawnUnitRandom(GameObject unit)
    {
        int rand = Random.Range(0, 2);
        if ((rand == 0)&&(!isReload))
        {
            SpawnThisUnit(unit);
            isReload = true;
            StartCoroutine(IsReload());
        }
    }

    IEnumerator IsReload()
    {
        yield return new WaitForSeconds(15f);
        isReload = false;
    }

    public void SpawnThisUnit(GameObject unit)
    {
        if (trigger.IsActive == false)
        {

            GameObject gameObject = Instantiate(unit, spawnPoint.position, Quaternion.identity);
            gameObject.GetComponent<MapController>().CreateIcon(parentIcon, rectTransformCanvas);
            gameObject.GetComponent<CreateObject>().SpawnerEther = spawnerEther;
        }
    }

    public void SpawnUnitAfter(GameObject unit, float time)
    {
        StartCoroutine(SpawnUnitAfterCoroutine(unit, time));
    }

    IEnumerator SpawnUnitAfterCoroutine(GameObject unit, float time)
    {
        yield return new WaitForSeconds(time);
        if (trigger.IsActive == false)
        {

            GameObject gameObject = Instantiate(unit, spawnPoint.position, Quaternion.identity);
            gameObject.GetComponent<MapController>().CreateIcon(parentIcon, rectTransformCanvas);
            gameObject.GetComponent<CreateObject>().SpawnerEther = spawnerEther;
        }
    }

    IEnumerator SpawnEnemy()
    {
        float timeSpawn = Random.Range(minTimeReload, maxTimeReload);
        int enemyIndex = Random.Range(0, enemyUnitPrefab.Count);
        yield return new WaitForSeconds(timeSpawn);
        if (trigger.IsActive == false)
        {
            
            GameObject gameObject = Instantiate(enemyUnitPrefab[enemyIndex], spawnPoint.position, Quaternion.identity);
            gameObject.GetComponent<MapController>().CreateIcon(parentIcon, rectTransformCanvas);
            gameObject.GetComponent<CreateObject>().SpawnerEther = spawnerEther;
        }
        CreateUnit();
    }
}
