using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDrone : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private List<GameObject> drone;
    [SerializeField] private List<GameObject> collector;
    [SerializeField] private List<Transform> existingDrones;
    [SerializeField] private float minDistance;
    [SerializeField] private int maxDrone;
    [SerializeField] private int maxcollector;
    [SerializeField] private int maxSattempts;

    [SerializeField] private float min_X_position;
    [SerializeField] private float min_Y_position;
    [SerializeField] private float max_X_position;
    [SerializeField] private float max_Y_position;

    [SerializeField] private Transform parentIcon;

    [SerializeField] private GameObject pointerPref;
    [SerializeField] private GameObject pointerParent;

    [SerializeField] private EtherStorage etherStorage;
    [SerializeField] private SpawnerEther spawnerEther;

    public void StartSpawn()
    {
        StartCoroutine(SpawnDron());
    }

    IEnumerator SpawnDron()
    {
        int countSattempts = 0;
        while ((countSattempts < maxSattempts) && (existingDrones.Count < maxcollector))
        {
            Vector2 positionDron = new Vector2(Random.Range(min_X_position, max_X_position), Random.Range(min_Y_position, max_Y_position));
            if (AccessPosition(positionDron))
            {
                GameObject gameObject = Instantiate(collector[Random.Range(0, collector.Count)], positionDron, Quaternion.identity);
                Link link = gameObject.GetComponent<Link>();
                if (link != null)
                {
                    link.ObjectLink = player;
                    link.ParentIcon = parentIcon;
                    Collector collector = gameObject.GetComponent<Collector>();
                    if (collector != null)
                    {
                        collector.EtherStorage = etherStorage;
                    }
                    else
                    {
                        link.Pointer = Instantiate(pointerPref, pointerParent.transform);
                        link.Pointer.GetComponent<PointerController>().EnemyDrone = gameObject.transform;
                        
                    }

                }

                existingDrones.Add(gameObject.transform);
                countSattempts = 0;
            }
            countSattempts++;
            yield return new WaitForEndOfFrame();
        }


        while ((countSattempts < maxSattempts)&&(existingDrones.Count < maxDrone + maxcollector))
        {
            Vector2 positionDron = new Vector2(Random.Range(min_X_position, max_X_position), Random.Range(min_Y_position, max_Y_position));
            if (AccessPosition(positionDron))
            {
                GameObject gameObject = Instantiate(drone[Random.Range(0, drone.Count)], positionDron, Quaternion.identity);
                Link link = gameObject.GetComponent<Link>();
                if (link != null)
                {
                    link.ObjectLink = player;
                    link.ParentIcon = parentIcon;
                    Collector collector = gameObject.GetComponent<Collector>();
                    if (collector != null)
                    {
                        collector.EtherStorage = etherStorage;
                    }
                    else
                    {
                        link.Pointer = Instantiate(pointerPref, pointerParent.transform);
                        link.Pointer.GetComponent<PointerController>().EnemyDrone = gameObject.transform;
                        gameObject.GetComponent<CreateObject>().SpawnerEther = spawnerEther;
                    }
                    
                }
                
                existingDrones.Add(gameObject.transform);
                countSattempts = 0;
            }
            countSattempts++;
            yield return new WaitForEndOfFrame();
        }
        //loadBlock.SetActive(false);
        //Time.timeScale = 1;
    }

    private bool AccessPosition(Vector2 positionDron)
    {
        int i = 0;
        while (i < existingDrones.Count)
        {
            if (Vector2.Distance(positionDron, existingDrones[i].position) < minDistance)
            {
                return false;
            }
            i++;
        }
        return true;
    }
}
