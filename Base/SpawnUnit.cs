using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUnit : MonoBehaviour
{
    [SerializeField] private Queue<UnitData> queueUnit = new Queue<UnitData>();
    [SerializeField] private Queue<GameObject> queueButton = new Queue<GameObject>();
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject queuePanel;
    [SerializeField] private EtherStorage etherStorage;
    [SerializeField] private Trigger trigger;
    [SerializeField] private SpawnerEther spawnerEther;

    [SerializeField] private Transform parentIcon;
    [SerializeField] private RectTransform rectTransformCanvas;
    [SerializeField] private AudioSource soundClicking;
    private bool isCreate = false;

    public void CheckForValue(UnitData unitData)
    {
        if (etherStorage.ReduceEther(unitData.price))
        {
            AddUnit(unitData);
            soundClicking.Play();
        }
    }

    public void AddUnit(UnitData unitData)
    {
        queueUnit.Enqueue(unitData);
        GameObject newButton = Instantiate(unitData.buttonPrefab, queuePanel.transform);
        queueButton.Enqueue(newButton);
        if (isCreate == false)
        {
            CreateUnit();
        }
    }

    public void DeleteUnit()
    {
        queueUnit.Dequeue();
        Destroy(queueButton.Peek());
        queueButton.Dequeue();
    }

    public void CreateUnit()
    {
        if (queueUnit.Count > 0)
        {
            isCreate = true;
            StartCoroutine(ExpectProduction());
        }
        else
        {
            isCreate = false;
        }
    }

    IEnumerator ExpectProduction()
    {
        yield return new WaitForSeconds(queueUnit.Peek().timeCreation);
        bool objectIsCreate = false;
        while (objectIsCreate == false)
        {
            if (trigger.IsActive == false)
            {
                objectIsCreate = true;
                GameObject gameObject = Instantiate(queueUnit.Peek().unitPrefab, spawnPoint.position, Quaternion.identity);
                gameObject.GetComponent<MapController>().CreateIcon(parentIcon, rectTransformCanvas);
                gameObject.GetComponent<CreateObject>().SpawnerEther = spawnerEther;
                DeleteUnit();
                CreateUnit();
            }
            else
            {
                yield return new WaitForEndOfFrame();
            }
        }
    }    
}
