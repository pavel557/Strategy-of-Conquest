using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEther : MonoBehaviour
{
    [SerializeField] private int maxCountEther = 5000;
    [SerializeField] private int countEther = 0;
    [SerializeField] private float distanceX = 0.15f;
    [SerializeField] private float distanceY = 0.15f;
    //[SerializeField] private float degreeInfluenceAltitude = 50f;
    [SerializeField] private float BottomLineMin = 0.9f;
    [SerializeField] private float BottomLineMax = 0.95f;
    [SerializeField] private float scale = 0.1f;
    [SerializeField] private List<float> percentage;
    [SerializeField] private List<float> altitude;
    [SerializeField] private List<GameObject> ether;
    [SerializeField] private List<GameObject> bonus;
    [SerializeField] private Transform leftBorderT;
    [SerializeField] private Transform rightBorderT;
    [SerializeField] private Transform upBorderT;
    [SerializeField] private Transform downBorderT;
    [SerializeField] private GameObject etherParent;
    [SerializeField] private GameObject loadBlock;
    [SerializeField] private SpawnDrone spawnDrone;
    [SerializeField] private EtherStorage etherStorage;

    [SerializeField] private Transform parentIcon;

    private float leftBorderX;
    private float rightBorderX;
    private float upBorderY;
    private float downBorderY;

    private float xOffset, yOffset;

    public int CountEther { get => countEther; set => countEther = value; }

    private void OnEnable()
    {
        leftBorderX = leftBorderT.position.x;
        rightBorderX = rightBorderT.position.x;
        upBorderY = upBorderT.position.y;
        downBorderY = downBorderT.position.y;
        StartSpawn();
    }

    public void StartSpawn()
    {
        //loadBlock.SetActive(true);
        //Time.timeScale = 0;
        SliceComputation(BottomLineMax);
        StartCoroutine(SpawnEther());
    }

    private void SliceComputation(float BottomLine)
    {
        altitude[0] = BottomLine;
        altitude[altitude.Count - 1] = 1f;
        for (int i = 1; i < altitude.Count - 1; i++)
        {
            altitude[i] = (altitude[altitude.Count - 1] - altitude[0]) * percentage[i - 1] + altitude[i - 1];
        }
    }


    IEnumerator SpawnEther()
    {
        xOffset = Random.Range(-1000f, 1000f);
        yOffset = Random.Range(-1000f, 1000f);
        for (float i = downBorderY; i < upBorderY; i = i + distanceY)
        {
            float heightCoef = (i - downBorderY) / (upBorderY - downBorderY);
            for (float j = leftBorderX ; j < rightBorderX; j = j + distanceX)
            {
                float noise = Mathf.PerlinNoise(j * scale + xOffset , i * scale + yOffset);
                for (int k = 0; k < ether.Count; k++)
                {
                    Spawn(Mathf.Sqrt(noise), k, j, i);
                }
            }
            yield return new WaitForEndOfFrame();
            
            float bottomLine = BottomLineMax - ((BottomLineMax - BottomLineMin) * heightCoef);
            SliceComputation(bottomLine);
        }
        spawnDrone.StartSpawn();
        //StartCoroutine(SpawnEtherAfter());
    }

    IEnumerator SpawnEtherAfter()
    {
        while(true)
        {
            if (CountEther < maxCountEther)
            {
                xOffset = Random.Range(-1000f, 1000f);
                yOffset = Random.Range(-1000f, 1000f);
                for (float i = downBorderY; i < upBorderY; i = i + distanceY)
                {
                    if (CountEther < maxCountEther)
                    {
                        float heightCoef = (i - downBorderY) / (upBorderY - downBorderY);
                        for (float j = leftBorderX; j < rightBorderX; j = j + distanceX)
                        {
                            if (CountEther < maxCountEther)
                            {

                                float noise = Mathf.PerlinNoise(j * scale + xOffset, i * scale + yOffset);
                                for (int k = 0; k < ether.Count; k++)
                                {
                                    Spawn(Mathf.Sqrt(noise), k, j, i);
                                }
                            }

                        }
                        yield return new WaitForSeconds(0.5f);

                        float bottomLine = BottomLineMax - ((BottomLineMax - BottomLineMin) * heightCoef);
                        SliceComputation(bottomLine);
                    }
                }
            }
            yield return new WaitForSeconds(5f);
        }
    }

    //IEnumerator AlternativeSpawnEther()
    //{
    //    for (float i = leftBorderX; i<rightBorderX; i=i+distanceX)
    //    {
    //        for (float j = upBorderY; j>downBorderY; j=j-distanceY)
    //        {
    //            float noise = Mathf.PerlinNoise(i, j);
    //            float heightCoef = (j - downBorderY) / (upBorderY - downBorderY);
    //            float noiseResult = Mathf.Sqrt(Mathf.Sqrt(noise)) * Mathf.Pow(heightCoef, 1f/degreeInfluenceAltitude);
    //            for (int k = 0; k<ether.Count; k++)
    //            {
    //                Spawn(noiseResult, k, i, j);
    //            }
    //        }
    //        yield return new WaitForEndOfFrame();
    //    }
    //}

    private void Spawn(float noiseResult, int number, float i, float j)
    {
        if ((noiseResult > altitude[number]) && (noiseResult <= altitude[number+1]))
        {
            GameObject etherObject = Instantiate(ether[number], new Vector3(i, j, transform.position.z), Quaternion.identity);
            etherObject.transform.parent = etherParent.transform;
            etherObject.GetComponent<Ocllusion>().ParentIcon = parentIcon;
            etherObject.transform.GetChild(0).GetComponent<Ether>().EtherStorage = etherStorage;
            CountEther++;
        }
    }

    public void SpawnInSpecificLocation(Transform location, int count)
    {
        StartCoroutine(SpawnInSpecificLocationEnumerator(location, count));
    }

    IEnumerator SpawnInSpecificLocationEnumerator(Transform location, int count)
    {
        float x = location.position.x - 0.9f;
        float y = location.position.y;
        int i = 0;
        while (count > 0)
        {
            
            GameObject etherObject = Instantiate(ether[2], new Vector3(x, y, transform.position.z), Quaternion.identity);
            etherObject.transform.parent = etherParent.transform;
            etherObject.GetComponent<Ocllusion>().ParentIcon = parentIcon;
            etherObject.transform.GetChild(0).GetComponent<Ether>().EtherStorage = etherStorage;
            count--;
            i++;
            x += 0.3f;
            if (i == 6)
            {
                x -= 1.8f;
                y += 0.3f;
                i = 0;
            }
            yield return new WaitForEndOfFrame();
        }
    }

    public void SpawnInCirlceLocation(Transform location, int count)
    {
        StartCoroutine(SpawnInCirlceEnumerator(location, count));
    }

    IEnumerator SpawnInCirlceEnumerator(Transform location, int count)
    {
        float x = location.position.x;
        float y = location.position.y;
        Instantiate(bonus[Random.Range(0, bonus.Count)], new Vector3(x, y, transform.position.z), Quaternion.identity);

        while (count > 0)
        {
            x += 0.3f;

            for (; x - location.position.x > 0; y += 0.3f, x -= 0.3f)
            {
                if (count > 0)
                {
                    GameObject etherObject = Instantiate(ether[2], new Vector3(x, y, transform.position.z), Quaternion.identity);
                    etherObject.transform.parent = etherParent.transform;
                    etherObject.GetComponent<Ocllusion>().ParentIcon = parentIcon;
                    etherObject.transform.GetChild(0).GetComponent<Ether>().EtherStorage = etherStorage;
                    count--;
                    
                }
                yield return new WaitForEndOfFrame();
                
            }
            for (; y - location.position.y > 0; y -= 0.3f, x -= 0.3f)
            {
                if (count > 0)
                {
                    GameObject etherObject = Instantiate(ether[2], new Vector3(x, y, transform.position.z), Quaternion.identity);
                    etherObject.transform.parent = etherParent.transform;
                    etherObject.GetComponent<Ocllusion>().ParentIcon = parentIcon;
                    etherObject.transform.GetChild(0).GetComponent<Ether>().EtherStorage = etherStorage;
                    count--;
                }
                yield return new WaitForEndOfFrame();
            }
            for (; x - location.position.x < 0; y -= 0.3f, x += 0.3f)
            {
                if (count > 0)
                {
                    GameObject etherObject = Instantiate(ether[2], new Vector3(x, y, transform.position.z), Quaternion.identity);
                    etherObject.transform.parent = etherParent.transform;
                    etherObject.GetComponent<Ocllusion>().ParentIcon = parentIcon;
                    etherObject.transform.GetChild(0).GetComponent<Ether>().EtherStorage = etherStorage;
                    count--;
                }
                yield return new WaitForEndOfFrame();
            }
            for (; y - location.position.y < 0; y += 0.3f, x += 0.3f)
            {
                if (count > 0)
                {
                    GameObject etherObject = Instantiate(ether[2], new Vector3(x, y, transform.position.z), Quaternion.identity);
                    etherObject.transform.parent = etherParent.transform;
                    etherObject.GetComponent<Ocllusion>().ParentIcon = parentIcon;
                    etherObject.transform.GetChild(0).GetComponent<Ether>().EtherStorage = etherStorage;
                    count--;
                }
                yield return new WaitForEndOfFrame();
            }

        }
    }
}
